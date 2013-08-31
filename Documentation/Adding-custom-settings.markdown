Sometimes you may need to persist some global settings 
(eg. license code, service login, default width etc.)
to be reused across your module. Orchard makes it really 
simple and I'll show you how to do it.

Basically, there are two scopes you can define your settings in:

1. **Site scope** - for global site settings.
2. **Content type scope** - for settings common to all items of a given type
(eg. a Page, a Blog, a BlogPost and so on).

## Defining site scope settings

This document traces the process of defining and implementing and individual site setting for a live orchard module that can be added to your site to enable the webservice known as 'AddThis' [Content Sharing](http://orchardsharing.codeplex.com/)

The specific goal being **"to store my AddThis service login cedentials so that all share bars across the site will be able to access my account"**

The first thing to understand is that our site setting is really just another form of the basic Orchard building blocks - the ContentPart/ContentPartRecord. While most ContentParts render visual elements to the site's visitor, they can also deliver non-visible chunks of data that can provide dynamic functionality to your pages. A great introduction to the construction of content types can be found 
[found here](http://www.szmyd.com.pl/blog/jumpstart-into-orchard-module-development)):
    
    public class ShareBarSettingsPart : ContentPart<ShareBarSettingsPartRecord> {
        public string AddThisAccount {
            get { return Record.AddThisAccount; }
            set { Record.AddThisAccount = value; }
            }
        }

When you create a Content Type you will almost always find yourself also creating a ContentTypeRecord which can be thought of as creating a new field in the database for storing the ContentType values.
    
    public class ShareBarSettingsPartRecord : ContentPartRecord {
        public virtual string AddThisAccount { get; set; }
    }

You can also decorate the content part AddThisAccount property with `[Required]` attribute
to make it a required field when editing site settings.

After creating the content part and record classes, you need to create appropriate
database mappings, called in Orchard - **Data Migration**.
You shouldn't do it by hand: there is a command-line,
`codegen datamigration <feature_name>`, which will create the appropriate file for you.
You can see how to use it [here](Using-the-Command-Line-Interface).

The next step is to create a corresponding driver, which will be responsible for displaying the editor that the end-user invokes when setting the posted values.
If you have already written some content parts, than this part of code should look familiar:

    [UsedImplicitly]
    public class ShareBarSettingsPartDriver :
        ContentPartDriver<ShareBarSettingsPart> {

        public ShareBarSettingsPartDriver(
            INotifier notifier,
            IOrchardServices services) {
                _notifier = notifier;
                T = NullLocalizer.Instance;
           }
    
        public Localizer T { get; set; }
        private const string TemplateName = "Parts/Share.Settings";
        private readonly INotifier _notifier;
    
        protected override DriverResult Editor(
            ShareBarSettingsPart part, dynamic shapeHelper) {

            return ContentShape("Parts_Share_Settings",
                       () => shapeHelper.EditorTemplate(
                           TemplateName: TemplateName,
                           Model: part,
                           Prefix: Prefix));
           }
    
        protected override DriverResult Editor(
            ShareBarSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {

            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                _notifier.Information(
                    T("Content sharing settings updated successfully"));
            }
            else {
                _notifier.Error(
                    T("Error during content sharing settings update!"));
            }
            return Editor(part, shapeHelper);
        }
    }

I omitted some code for checking permissions to edit the settings for better readability,
but you are free to take a look at the full source code hosted on Codeplex.

To review, so far we have our Content Part (plus it's attendant Content Part Record) and this just added driver. Two more structures are required before we can implement our new site-wide property setting:
a Handler (controller) where we define the behavior of our Content Part, and the Shape (view)
that will render the HTML markup for our form's editor. The Handler looks like:
    
    [UsedImplicitly]
    public class ShareBarSettingsPartHandler : ContentHandler {
        public ShareBarSettingsPartHandler(
            IRepository<ShareBarSettingsPartRecord> repository) {

            Filters.Add(new ActivatingFilter<ShareBarSettingsPart>("Site"));
            Filters.Add(StorageFilter.For(repository));
        }
    }


In most cases its just that simple:

1. Add an activating filter. Tells Orchard which of the existing Content Types
our **ShareBarSettingsPart** should be attached to. Because **Site** is also a Content Type,
we can attach our part to it. **Basically, this is the point that differentiates the ordinary
content parts from site settings.**
2. Add the storage filter to register our settings repository - required because we want to be storing records in the database.

So if the above handler can be thought of as a 'controller' the obvious next step is creating the 'view'. Orchard's term is 'shape' and is nothing more than a .cshtml file that combines HTML markup with razor's ability to render database elements.
First, you have to create a .cshtml file under `/Views/EditorTemplates/Parts/`.
This file, as the [naming convention](Accessing-and-rendering-shapes)
informs us, should be named `Share.Settings.cshtml`.
This name corresponds to the `Parts_Share_Settings` shape used inside the driver above.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/804b787519c9_1126C/image_thumb.png)

We've got only a single field (AddThisAccount) in our settings, so the markup inside
the `Share.Settings.cshtml` file will look like this:
    
    @model Szmyd.Orchard.Modules.Sharing.Models.ShareBarSettingsPart
    <fieldset>
        <legend>@T("Content sharing settigs")</legend>
        <div>
            @Html.LabelFor(m => m.AddThisAccount, @T("AddThis service account"))
            @Html.EditorFor(m => m.AddThisAccount)
            @Html.ValidationMessageFor(m => m.AddThisAccount, "*")
        </div>
    </fieldset>

Next, we need to tell Orchard where in the `Site -> Settings` pane our form should be displayed. 
To do this we create a `Placement.info` file in our module root:
    
    <Placement>
        <Place Parts_Share_Settings="Content:0"/>
    </Placement>

which tells Orchard to display our form field at the beginning.

Now that we've configured our settings we will look at what it takes to actaully _use_ them.

## Using site scope settings

This part is basically a one-liner:
    
    var shareSettings = _services.WorkContext.CurrentSite.As<ShareBarSettingsPart>();

Where _services is the `IOrchardServices` object (eg. injected in the constructor).
Please note that you have to include "using Orchard.ContentManagement;" on the class.
Simple, isn't it? The full (simplified for readability) example from the ShareBarDriver
from [Content Sharing](http://orchardsharing.codeplex.com/) module:

    [UsedImplicitly]
    public class ShareBarPartDriver : ContentPartDriver<ShareBarPart> {
        private readonly IOrchardServices _services;
    
        public ShareBarPartDriver(IOrchardServices services) {
            _services = services;
        }
    
        protected override DriverResult Display(
            ShareBarPart part, string displayType, dynamic shapeHelper) {

            var shareSettings = _services.WorkContext.CurrentSite
                .As<ShareBarSettingsPart>();
    
            // Prevent share bar from showing if account is not set
            if (shareSettings == null ||
                string.IsNullOrWhiteSpace(shareSettings.AddThisAccount)) {

                return null;
            }
            
            return ContentShape("Parts_Share_ShareBar",
                () => shapeHelper.Parts_Share_ShareBar(
                    Account: shareSettings.AddThisAccount));
        }
    }

We're now going to create settings and defaults wired with specific content type (like Page, User, Blog etc.).

## Defining settings for Content Types

This looks much different comparing to the previous one, but also requires less coding.
There are just two classes and one shape involved and that's all.
As before, we'll use the simplified examples taken from the
[Orchard Sharing](http://orchardsharing.codeplex.com/) project.

The goal:
> "I want all of my Blog Posts to have ShareBar with the same look."

Imagine that you're writing posts via LiveWriter (like me).
Do you want to log in and edit every post after publishing just to change the share bar?
I don't. I want to have it defined upfront.

The first thing you have to do is to create a class holding your settings:

    public class ShareBarTypePartSettings {
        public ShareBarMode Mode { get; set; }
        public IEnumerable<dynamic> AvailableModes { get; set; }
    }


This class has one property - `Mode`, which holds the default mode for all ShareBarParts
attached to some content items of a given type.
`ShareBarMode` is just an enum type defining the display modes.
For the sake of brevity, I won't paste the code here.
This could be any type you want.
The second property is just used for the display purposes (holds items for display in drop-down list),
as this class is also used as a ViewModel. It is not being persisted.

The second class can be thought of as a kind of a driver for the settings.
It's not the Orchard ContentDriver we wrote previously, but also it's responsible
for rendering the edit form and saving the posted data:
    
    public class ShareBarSettingsHooks : ContentDefinitionEditorEventsBase {
        public override IEnumerable<TemplateViewModel> TypePartEditor(
            ContentTypePartDefinition definition) {
            
            if (definition.PartDefinition.Name != "ShareBarPart") yield break;
            var model = definition.Settings.GetModel<ShareBarTypePartSettings>();
    
            model.AvailableModes = Enum.GetValues(typeof(ShareBarMode))
                .Cast<int>()
                .Select(i =>
                    new {
                        Text = Enum.GetName(typeof(ShareBarMode), i),
                        Value = i
                    });
    
            yield return DefinitionTemplate(model);
        }
    
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(
            ContentTypePartDefinitionBuilder builder,
            IUpdateModel updateModel) {
            
            if (builder.Name != "ShareBarPart") yield break;
    
            var model = new ShareBarTypePartSettings();
            updateModel.TryUpdateModel(model, "ShareBarTypePartSettings", null, null);
            builder.WithSetting("ShareBarTypePartSettings.Mode",
                ((int)model.Mode).ToString());
            yield return DefinitionTemplate(model);
        }
    }

This class overrides the `ContentDefinitionEditorEventsBase` which defines two overridable methods:
`TypePartEditor` and `TypePartEditorUpdate`.
The first one gets called when the edit form is being rendered (GET) and the second one
when the edit form data gets posted (POST).
Unlike the generic content part drivers, this class is not bound to the specific content type
(as the content types are just a list of names for a collection of parts),
so each of the methods we just defined will be called for every content type and for every part.
This is why the `yield break` statement is used - to filter only the ones containing the part we need, `ShareBarPart`.

By convention, as shown in the TypePartEditorUpdate method, settings should be named as
`<prefix>.<propertyName>` when passing to `builder.WithSetting(...)`,
where `prefix` is the string passed to the updateModel.TryUpdateModel.
`Prefix` can be anything, but has to be unique. Remember though,
when you use string other than your settings class name,
you cannot use `Settings.GetModel<Your_Settings_Type>()`
(as shown in the TypePartEditor method above).
In this case you have to use `Settings.GetModel<Your_Settings_Type>(prefix)` instead.

1. It should be considered best practice to use your settings class name as a `prefix` (as in the code above).
2. Settings are persisted within the content type definition in the db in the string form.
You have to be sure that the properties you define are convertible to and from the string representation.

> Notice the usage of `Enum.GetValues(typeof(someEnum)), Enum.GetNames(typeof(someEnum))`
and `Enum.GetName(typeof(someEnum), i)`.
This methods get very useful when you want to iterate over the names/values of an enum.

If you're done with the code above, there's only one thing left:
creating a .cshtml view (shape) to render our form.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/Using-custom-settings-in-Orchard-Part-2-_AE9C/image_thumb.png)

Shapes defining edit forms for content type settings has to be placed under
`/Views/DefinitionTemplates/` with the name `<settingsClassName>.cshtml`.
So in our case it'll look like on the picture above.
Inside, it's just like any other Razor view file:
    
    @model Szmyd.Orchard.Modules.Sharing.Settings.ShareBarTypePartSettings
    <fieldset>
        <div>
            @Html.LabelFor(m => m.Mode, T("Share bar display style"))
            @Html.DropDownListFor(m => m.Mode,
                new System.Web.Mvc.SelectList(
                    Model.AvailableModes, "Value", "Text", (int)Model.Mode))
        </div>
    </fieldset>


This renders the dropdown list so user can choose one of the predefined Modes.
`Model.AvailableModes` contains the available ones: we populated the property with appropriate
data in `TypePartEditor` method above.

Hooray, we're done!

Now you possibly wonder, where will this edit form be shown?
Orchard will render settings form when you'll try to edit the content type containing your part.
The steps are like this: `Content Types -> Edit the type you want -> Add your part -> Voila!`
There is a nice arrow image next to your part. If you click it - the form shows.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/Using-custom-settings-in-Orchard-Part-2-_AE9C/image_thumb_4.png)


## Using settings for content type

As for site-scoped settings, this section is also a one-liner.
The part below is some content part (in this case a ShareBarPart from the
[Orchard Sharing](http://orchardsharing.codeplex.com/) project).
    
    var typeSettings = part.Settings.GetModel<ShareBarTypePartSettings>();

You can retrieve and use the settings wherever you have access to your part
(particularly in the driver Display/Editor methods, but also shapes, handlers and so on).
I used it in the ShareBarPart driver Display method to change the look of a share bar part.
