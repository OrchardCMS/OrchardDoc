> **ARCHIVED**

When building themes in Orchard, it is often desirable to make certain aspects of the theme available to the administrator to customize. 
This article describes how to add several simple theme settings to the Site Settings menu in the Orchard dashboard. 

#Creating the Theme
First thing we will need is a theme, so let's go ahead and use the codegen command to generate a theme

    feature enable Orchard.CodeGeneration

Now we can generate a theme that we will base on TheThemeMachine so that we have a basic theme to work on. We will also need to create a project file for this theme so that we can add our settings. This is the key to creating settings in our themes because by making our theme a C# project, our themes can do almost anything a module can do.

    codegen theme CleanBlog /BasedOn:TheThemeMachine /CreateProject:true

#Defining the Settings
Visual Studio should now prompt you to reload the solution so you can get started with your new theme. If it doesn't right click on your themes folder in the Solution Explorer and Add -> Existing Project then select your new themes project file (it will be located in the Themes folder).

These will be the two settings added to our theme:

- Add a custom class to the main layout <div>
- Load a custom style sheet based on the users selection

	
We are going to attach a new part to the Site content type to store these custom theme settings. So let's create a **Models** folder and add a file called *CleanBlogSettingsPart.cs*.

    using Orchard.ContentManagement;
    
    namespace CleanBlog.Models
    {
    	public class CleanBlogSettingsPart : ContentPart
        {
            public string CustomClass {
                get { return this.Retrieve(x => x.CustomClass); }
                set { this.Store(x => x.CustomClass, value); }
            }
         
            public string HoverColor {
                get { return this.Retrieve(x => x.HoverColor, "custom_blue.css"); }
                set { this.Store(x => x.HoverColor, value); }
            }
        }
    }

This example is using the InfoSet storage that was made available in 1.8 (it is perfectly possible to achieve the same in older versions of Orchard using the ContentPartRecord storage method and building the table in the migrations, see *this* for more details). The "custom_blue.css" parameter in the getter for HoverColor is the default value for that setting.

We will be offering them the option to choose from 3 different colours to have their links, so let's create three style sheets in the Styles folder of our theme:

- custom_blue.css
- custom_green.css
- custom_yellow.css

Add the following to each style sheet and adjust the colour to match the file.

    a:hover {
        color: *color*;
    }

So custom_blue.css will look like this:

    a:hover {
        color: blue;
    }

#Setting up the Editor
Now we will need an editor to select these options. Create a file in **~/Views/EditorTemplates/Parts** called *CleanBlogSettingsPart.cshtm*. 

    @model CleanBlog.Models.CleanBlogSettingsPart
               
    @{
        var colourScheme = new List<SelectListItem>();
        colourScheme.Add(new SelectListItem { Text = "Blue", Value = "custom_blue.css" });
        colourScheme.Add(new SelectListItem { Text = "Green", Value = "custom_green.css" });
        colourScheme.Add(new SelectListItem { Text = "Yellow", Value = "custom_yellow.css" });
    }
    
    <fieldset>
        <legend>Clean Blog Settings</legend>
    	<div>
    		@Html.LabelFor(m => m.CustomClass, T("Custom Class"))
    		@Html.EditorFor(m => m.CustomClass)
    	</div>
    	<div>
    		@Html.LabelFor(m => m.HoverColor, T("Hover Color"))
    		@Html.DropDownListFor(m => m.HoverColor, colourScheme.AsEnumerable())
    	</div>
    </fieldset>

To handle the display of this view and attach the settings to the Site content type, we will use a ContentHandler. So create a folder called **Handlers** in the root of your theme with a file called *CleanBlogSettingsPartHandler.cs*.

using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement;
using Orchard.Localization;
using CleanBlog.Models;

    namespace CleanBlog.Handlers
    {
    	public class CleanBlogSettingsPartHandler : ContentHandler
        {
            public CleanBlogSettingsPartHandler() {
    			Filters.Add(new ActivatingFilter<CleanBlogSettingsPart>("Site"));
                Filters.Add(new TemplateFilterForPart<CleanBlogSettingsPart>("CleanBlogSettingsPart", "Parts/CleanBlogSettingsPart", "Theme"));
                T = NullLocalizer.Instance;
            }
    
    		public Localizer T { get; set; }
    
    		protected override void GetItemMetadata(GetContentItemMetadataContext context) {
                if (context.ContentItem.ContentType != "Site")
                    return;
                base.GetItemMetadata(context);
                context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Theme")));
            }
        }
    }

There are a few things of note here. We don't want to just display our themes settings in the main settings menu, but in its own subsection called "Theme". You can name this subsection whatever you like. But if you do want your settings to be in the main settings page, just remove the 'GetItemMetadata()' method and change this line:

    Filters.Add(new TemplateFilterForPart<CleanBlogSettingsPart>("CleanBlogSettingsPart", "Parts/CleanBlogSettingsPart", "Theme"));

to:

    Filters.Add(new TemplateFilterForPart<CleanBlogSettingsPart>("CleanBlogSettingsPart", "Parts/CleanBlogSettingsPart"));

You'll also notice that this line is defining what template to use for rendering our settings editor. You may be wondering why we don’t just use a driver like we usually do for a parts editor template. This is due to the fact that to call the **Editor** method of your **Driver** and return a shape, you need to have specified in the Placement.info that you want to do that. Since this theme is not active in the admin section of Orchard, our themes **Placement.info** file is never run hence a Driver would never display anything.

Finally, the line:

    Filters.Add(new ActivatingFilter<CleanBlogSettingsPart>("Site"));

Is what attaches our part to the Site content type. 

#Accessing the Theme Settings
All that is left is to do now is to actually make use of our theme settings. Let's copy the *Layout.cshtml* file from TheThemeMachine into our CleanBlog theme. This means our theme will now use our Layout file instead of the base Layout from TheThemeMachine. Accessing our settings is as simple as:

    var settings = WorkContext.CurrentSite.As<CleanBlogSettingsPart>();

**WorkContext** is effectively an extension of the **HttpContext**, containing additional information about Orchard, such as the current user and current site (which you can see us doing above). This gives us access to the **site content item**, meaning we can access any parts that we have attached to the Site content type. We will need to add two using statements into our view to resolve the .As<> extension and our model.

    @using CleanBlog.Models
    @using Orchard.ContentManagement

So now we have our settings in the view we can actually make use of them. Anywhere after the line

    Style.Include("Site.css");

add the line

    Style.Include(settings.HoverColor);

This will load the selected stylesheet after the main sheet and apply our overriding colour scheme. Our final setting is to add a custom class to the main div element. This element is generated by the Tag method. This is an implementation of C#'s TagBuilder class. It takes a dynamic shape object and a tag name and builds that tag with all the attributes (id, classes and additional attributes) gleaned from the shape that was passed in. So we can add our class to the Model so our class will be added to the rendered tag like so:

    Model.Classes.Add(settings.CustomClass);

#Wrapping Up
The real power here is that themes in Orchard don't just have to be templates and stylesheets, they can be fully-fledged **projects** that run C# code outside of views; basically do anything a module can do. Here we saw just one way to utilize this power: modify the look and feel of your theme from the dashboard without having to change any **HTML** or **CSS**
