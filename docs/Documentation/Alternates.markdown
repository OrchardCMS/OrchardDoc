Alternates are optional variations of a shape that you can implement in a theme in order to customize
the rendering of the shape for specific cases.
By using alternates, you can override which template is used to render content,
based on the type (or other characteristic) of that content.
For example, you can use alternates to apply one layout file for the home page but another layout file for subpages.
Or you can use alternates to render tags one way when the tags are in a page but
a different way when the tags are in a blog post.
Alternates are particularly useful when you have different types of content and
you want to customize the appearance of these different types of content. 

The Orchard framework uses a naming convention to determine whether an alternate template
is used for rendering content.
The naming convention enables you to add template files that are used automatically,
without requiring you to modify any code.


## Naming Convention for Alternates

Alternate shapes are named using the name of the base shape followed by a double underscore (`__`)
and an ending that is specific to the alternate shape.
For example, a `Parts_Tags_ShowTags` shape can have alternates with names such as
`Parts_Tags_ShowTags__BlogPost` and `Parts_Tags_ShowTags__Page`.
The part of the alternate name after the double underscore reflects when the shape is used,
such as the current content type. (For more information about how shapes are named,
see [Accessing and Rendering Shapes](Accessing-and-rendering-shapes).)

## Mapping a Template File to an Alternate

To create a template file that maps to the corresponding shape name,
you must name the template according to the  following naming convention:

* Convert an underscore (`_`) in the shape name to either a dot (`.`) or backslash (`\ `) in the template name.
  A backslash indicates that the template resides in a subfolder.
* Convert a double underscore (`__`) in the shape name to a hyphen (`-`).
* For any Display type value in the shape name, place the type name after a dot (`.`)
  at the end of the template name, such as `Content-BlogPost.Summary`.

All templates for alternates must reside in the `Views` folder.
The `Views` folder can be located either in the theme or in the module.
The following table shows which subfolders of `Views` to use for different types of templates.

Shape type     | Template Folder
-------------- | ----------------
Content item   | `Views\Items`
Parts          | `Views\Parts`
Fields         | `Views\Fields`
EditorTemplate | `Views\EditorTemplates\[template type folder]` (For example, an `EditorTemplate` for a part is located at `Views\EditorTemplates\Parts`.)
All other      | `Views`

For example, to create an alternate template for the `Tags` part, you can add a template
to the `MyTheme\Views\Parts` folder.
However, because the underscore can be converted to either a dot (`.`) or backslash (`\ `),
you can also create a template in the `Views` folder and add `Parts.` to the beginning of the name.
A template at either `Views\Parts\Tags.ShowTags-BlogPost.cshtml` or
`Views\Parts.Tags.ShowTags-BlogPost.cshtml` will map to a shape named `Parts_Tags_ShowTags__BlogPost`.

If the Orchard framework cannot locate an alternate template that has the expected name,
the default template will be used for those shapes.
For example, if you do not create an alternate for showing tags, the default template for tags
(located at `Views\Parts\Tags.ShowTags.cshtml`) is used.

The Orchard framework automatically creates many alternates that you can use in your application.
However, you can create templates for these alternate shapes.
The patterns for creating alternates are shown below, with examples of matching templates in parenthesis.

For **Content** shapes:

* `Content__[DisplayType]`. (Example template: `Content.Summary`)
* `Content__[ContentType]`. (Example template: `Content-BlogPost`)
* `Content__[Id]`. (Example template: `Content-42`)
* `Content_[DisplayType]__[ContentType]`. (Example template: `Content-BlogPost.Summary`)
* `Content_[DisplayType]__[Id]`. (Example template: `Content-42.Summary`)

For **Zone** shapes:

* `Zone__[ZoneName]`. (Example template: `Zone-SideBar`)

For **Navigation** shapes (the new menu system since version 1.5):

* `MenuItemLink__[MenuName]`. (Example template: `MenuItemLink-main-menu`)
* `MenuItemLink__[ContentType]`. (Examples template: `MenuItemLink-ContentMenuItem`, `MenuItemLink-HtmlMenuItem`, `MenuItemLink-Blog`)

For menu and menu item shapes:

* `Menu__[MenuName]`. (Example template: `Menu-main`)
* `MenuItem__[MenuName]`. (Example template: `MenuItem-main`)

For local menu and local menu item shapes:

* `LocalMenu__[MenuName]`. (Example template: `LocalMenu-main`)
* `LocalMenuItem__[MenuName]`. (Example template: `LocalMenuItem-main`)

For styles and resources:

* `Style__[FileName]`
* `Resource__[FileName]`

For widget shapes:

* `Widget__[ZoneName]`. (Example template: `Widget-SideBar`)
* `Widget__[ContentType]`. (Example template: `Widget-BlogArchive`)

For fields:

* `[ShapeType__FieldName]`. (Example template: `Fields\Common.Text-Teaser`)
* `[ShapeType__PartName]`. (Example template: `Fields\Common.Text-TeaserPart`)
* `[ShapeType]__[ContentType]__[PartName]`. (Example template: `Fields\Common.Text-Blog-TeaserPart`)
* `[ShapeType]__[PartName]__[FieldName]`. (Example template: `Fields\Common.Text-TeaserPart-Teaser`)
* `[ShapeType]__[ContentType]__[FieldName]`. (Example template: `Fields\Common.Text-Blog-Teaser`)
* `[ShapeType]__[ContentType]__[PartName]__[FieldName]`. (Example template: `Fields\Common.Text-Blog-TeaserPart-Teaser`)

For content parts:

* `[ShapeType]__[Id]`. (Example template: `Parts\Common.Metadata-42`)
* `[ShapeType]__[ContentType]`. (Example template: `Parts\Common.Metadata-BlogPost`)

You can use the **Shape Tracing** module to generate alternate templates through the **Shape Tracing** user interface. For more information, see [Customizing Orchard using Designer Helper Tools](Customizing-Orchard-using-Designer-Helper-Tools).

## URL and Widget Alternates

The **URL Alternates** module enables you to create templates for specific URLs,
and the **Widget Alternates** enables additional alternates for widgets of certain types and in specific zones.
You must enable the **URL Alternates** and **Widget Alternates** modules in order to use their features.
When enabled, alternate shapes are created based on the URL or the zone.
These URL alternates are combined with the alternate patterns defined above.

For example, the URL `/my-blog/post-1` has alternates available for a `MenuItem` object
with the following template names:

`MenuItem-main`  
`MenuItem-main-url-my-blog`  
`MenuItem-main-url-my-blog-post-1`

For the homepage, the following alternate is available:

`MenuItem-main-url-homepage`

Using this module, you can add URL-specific alternates to the **Layout** shape, such as the following: 
`Layout-url-homepage`. This adds a specific layout for your About page of your site.

Creating a new layout file in your `Themes/ThemeName/Views` named `Layout-url-About.cshtml`
would be picked up and used when viewing the `/About` page in your site.

> **Note:** if the changes are only small, perhaps using alternate URL naming to the zone would be more appropriate.

You can enable URL Alternates by downloading the Designer Tools module from the Orchard Team
in the Orchard Modules Gallery:
[Orchard Designer Tools](http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.DesignerTools)

Similarly, widget alternates add new templates names that you can use to change the rendering
of content parts when they are rendered as part of a specific widget type or inside of a
specific zone. [Shape Tracing](Customizing-Orchard-using-Designer-Helper-Tools)
(another feature of the [Orchard Designer Tools](http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.DesignerTools)
module) is a great way to discover what alternates are available for any shape template on the page.

Here are some examples of widget alternate template names:

- `Parts.Common.Body-HtmlWidget-TripelSecond`  
- `Parts.Common.Body-TripelSecond`

## Explicitly Designating an Alternate Template

In addition to using the automatically generated alternates, you can manually specify an alternate.
In a `Placement.info` file, you can specify which alternates are available for a content type.
For example, to specify a different template (identified as `Parts_Tags_ShowTags_BlogPost`)
for rendering the tags for blog posts, you can revise the `Placement.info` file for the
**Orchard.Tags** module to include an element that matches `BlogPost` types.
The following example shows the revised file.
    
    <Placement>
        <Place Parts_Tags_Edit="Content:7"/>
        <Match ContentType="BlogPost">
            <Place Parts_Tags_ShowTags="Header:after.7;Alternate=ShowTags_BlogPost"/>
        </Match>  
        <Match DisplayType="Detail">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
        <Match DisplayType="Summary">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
    </Placement>

The ordering of the `Match` elements is significant.
Only the first matched element is used to render the item.
In the example, placing the element for `BlogPost` below `Detail` and `Summary` means
that `ShowTags_BlogPost` will not be used, even for `BlogPost` items,
because the earlier elements match the item.
For more information about the `Placement.info` file, see
[Understanding placement.info](Understanding-placement-info).

## Alternates for MVC views
Some modules in Orchard use regular MVC views to render the results of an action that was invoked on a custom controller. To customize the look of the pages produced by custom MVC controllers in Orchard, you need to add a version of the view file in your theme's `Views` folder.

For example, if you want to customize the search results page of the Orchard Search module (`Orchard.Search`) you need to add a file in the following folder of your theme:

    /Themes/{Your theme}/Views/Orchard.Search/Search/Index.cshtml

This file will override the default view used by the `Orchard.Search` module. 
The `ViewEngine` used by Orchard will look for the following pattern when resolving MVC views.

- `~/Themes/[Active theme]/Views/[Area]/[Controller]/[View].cshtml`
- `~/Themes/[Active theme]/Views/[Controller]/[View].cshtml`
- `~/Themes/[Active theme]/[Partial].cshtml`
- `~/Themes/[Active theme]/DisplayTemplates/[TemplateName].cshtml`
- `~/Themes/[Active theme]/EditorTemplates/[TemplateName].cshtml`

Please be aware, any other convention that is normally supported in MVC is not supported within a theme, unless specified in the list above. 

## Adding Alternates Through Code

In addition to methods described above for adding alternates, you can add alternates through code.
To designate an alternate through code, you create a class that implements the `IShapeTableProvider` interface.
Then, you add a handler for `OnDisplaying` for each type of shape that needs an alternate.
You specify the shape name as the parameter for the `Describe` method on the `ShapeTableBuilder` class.
Within the handler, you add any logic that you need to specify when the alternate is used.
The following example first shows how to specify an alternate for shape named `Content`,
but only when the user is on the home page.
It also shows how to specify an alternate for a shape named `Parts_Tags_ShowTags`
when the `DisplayType` is `Summary`.

    using Orchard;
    using Orchard.ContentManagement;
    using Orchard.DisplayManagement.Descriptors;
    
    namespace MyTheme.ShapeProviders
    {
        public class ExampleShapeProvider : IShapeTableProvider
        {
            private readonly IWorkContextAccessor _workContextAccessor;
    
            public ExampleShapeProvider(IWorkContextAccessor workContextAccessor)
            {
                _workContextAccessor = workContextAccessor;
            }
    
            public void Discover(ShapeTableBuilder builder)
            {
                builder.Describe("Content")
                    .OnDisplaying(displaying =>
                    {
                        if (displaying.ShapeMetadata.DisplayType == "Detail")
                        {
                            ContentItem contentItem = displaying.Shape.ContentItem;
                            if (_workContextAccessor.GetContext().CurrentSite.HomePage
                                .EndsWith(';' + contentItem.Id.ToString())) {

                                displaying.ShapeMetadata.Alternates
                                    .Add("Content__HomePage");
                            }
                        }
                    });
    
                builder.Describe("Parts_Tags_ShowTags")
                    .OnDisplaying(displaying =>
                    {
                        if (displaying.ShapeMetadata.DisplayType == "Summary")
                        {
                            displaying.ShapeMetadata.Alternates
                                .Add("Tags_ShowTags_Summary");
                        }
                    });
            }
        }
    }

