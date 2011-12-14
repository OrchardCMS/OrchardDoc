A _shape_ is a dynamic data model.
The purpose of a shape is to replace the static view model of ASP.NET MVC by using a model
that can be updated at run time&#151;that is, by using a dynamic shape.
You can think of shapes as the blobs of data that get handed to templates for rendering.

This article introduces the concept of shapes and explains how to work with them.
It's intended for module and theme developers who have at least a basic understanding of Orchard modules.
For information about creating modules, see [Building a Hello World Module](Building-a-hello-world-module).
For information about dynamic objects, see [Creating and Using Dynamic Objects](http://msdn.microsoft.com/en-us/library/ee461504.aspx).

# Introducing Shapes

Shapes are dynamic data models that use shape templates to make the data visible to the user in the way you want.
Shape templates are fragments of markup for rendering shapes.
Examples of shapes include menus, menu items, content items, documents, and messages.

A shape is a data model object that derives from the `Orchard.DisplayManagement.Shapes.Shape` class.
The `Shape` class is never instantiated. Instead, shapes are created at run time by a shape factory.
The default shape factory is `Orchard.DisplayManagement.Implementation.DefaultShapeFactory`.
The shapes created by the shape factory are dynamic objects.

> **Note**`
`Dynamic objects are new to the .NET Framework 4.
As a dynamic object, a shape exposes its members at run time instead of at compile time.
By contrast, an ASP.NET MVC model object is a static object that's defined at compile time.

Information about the shape is contained in the `ShapeMetadata` property of the shape itself.
This information includes the shape's type, display type, position, prefix, wrappers, alternates,
child content, and a `WasExecuted` Boolean value.

You can access the shape's metadata as shown in the following example:
    
    var shapeType = shapeName.Metadata.Type;

After the shape object is created, the shape is rendered with the help of a shape template.
A shape template is a piece of HTML markup (partial view) that is responsible for displaying the shape.
Alternatively, you can use a shape attribute (`Orchard.DisplayManagement.ShapeAttribute`)
that enables you to write code that creates and displays the shape without using a template.

# Creating Shapes

For module developers, the most common need for shapes is to transport data from a driver to a template for rendering.
A driver derives from the `Orchard.ContentManagement.Drivers.ContentPartDriver` class
and typically overrides that class's `Display` and `Editor` methods.
The `Display` and `Editor` methods return a `ContentShapeResult` object, which is analogous to
the `ActionResult` object returned by action methods in ASP.NET MVC.
The `ContentShape` method helps you create the shape and return it in a `ContentShapeResult` object.

Although the `ContentShape` method is overloaded, the most typical use is to pass it two
parameters&#151;the shape type and a dynamic function expression that defines the shape.
The shape type names the shape and binds the shape to the template that will be used to render it.
The naming conventions for shape types are discussed later in
[Naming Shapes and Templates](Accessing-and-rendering-shapes#NamingShapesandTemplates).

The function expression can be described best by using an example.
The following example shows a driver's `Display` method that returns a shape result,
which will be used to display a `Map` part.

    protected override DriverResult Display(
        MapPart part, string displayType, dynamic shapeHelper)
    {
    return ContentShape("Parts_Map",
                         () => shapeHelper.Parts_Map(
                               Longitude: part.Longitude, 
                               Latitude: part.Latitude));
    }

The expression uses a dynamic object (`shapeHelper`) to define a `Parts_Map` shape and its attributes.
The expression adds a `Longitude` property to the shape and sets it equal to the part's `Longitude` property.
The expression also adds a `Latitude` property to the shape and sets it equal to the part's `Latitude` property.
The `ContentShape` method creates the results object that is returned by the `Display` method.

The following example shows the entire driver class that sends a shape result to a template either
to be displayed or edited in a `Map` part. The `Display` method is used to display the map.
The `Editor` method marked "GET" is used to display the shape result in editing view for user input.
The `Editor` method marked "POST" is used to redisplay the editor view using the values provided by the user.
These methods use different overloads of the `Editor` method.
    
    using Maps.Models;
    using Orchard.ContentManagement;
    using Orchard.ContentManagement.Drivers;
    
    namespace Maps.Drivers
    {
        public class MapPartDriver : ContentPartDriver<MapPart>
        {
            protected override DriverResult Display(
                MapPart part, string displayType, dynamic shapeHelper)
            {
                return ContentShape("Parts_Map",
                                    () => shapeHelper.Parts_Map(
                                          Longitude: part.Longitude, 
                                          Latitude: part.Latitude));
            }
    
            //GET
            protected override DriverResult Editor(
                MapPart part, dynamic shapeHelper)
            {
                return ContentShape("Parts_Map_Edit",
                                    () => shapeHelper.EditorTemplate(
                                          TemplateName: "Parts/Map", 
                                          Model: part));
            }
    
            //POST
            protected override DriverResult Editor(
                MapPart part, IUpdateModel updater, dynamic shapeHelper)
            {
                updater.TryUpdateModel(part, Prefix, null, null);
                return Editor(part, shapeHelper);
            }
        }
    }

The `Editor` method marked "GET" uses the `ContentShape` method to create a shape for an editor template.
In this case, the type name is `Parts_Map_Edit` and the `shapeHelper` object creates an `EditorTemplate` shape.
This is a special shape that has a `TemplateName` property and a `Model` property.
The `TemplateName` property takes a partial path to the template.
In this case, `"Parts/Map"` causes Orchard to look for a template in your module at the following path: 

_Views/EditorTemplates/Parts/Map.cshtml_

The `Model` property takes the name of the part's model file, but without the file-name extension.

# Naming Shapes and Templates

As noted, the name given to a shape type binds the shape to the template that will be used to render the shape.
For example, suppose you create a part named `Map` that displays a map for the specified longitude and latitude.
The name of the shape type might be `Parts_Map`. By convention, all part shapes begin with `Parts_` followed by the name of the part (in this case `Map`). Given this name (`Parts_Map`), Orchard looks for a template in your module at the following path: 

_views/parts/Map.cshtml_

The following table summarizes the conventions that are used to name shape types and templates.

Applied To             | Shape Naming Convention                                           | Shape Type Example                                   | Template Example
---------------------- | ----------------------------------------------------------------- | ---------------------------------------------------- | ------------------------------------------
Content shapes         | Content\_\_\[ContentType\]                                        | Content\_\_BlogPost                                  | Content-BlogPost
Content shapes         | Content\_\_\[Id\]                                                 | Content\_\_42                                        | Content-42
Content shapes         | Content\_\_\[DisplayType\]                                        | Content\_\_Summary                                   | Content.Summary
Content shapes         | Content\_\[DisplayType\]\_\_\[ContentType\]                       | Content\_Summary\_\_BlogPost                         | Content-BlogPost.Summary
Content shapes         | Content\_\[DisplayType\]\_\_\[Id\]                                | Content\_Summary\_\_42                               | Content-42.Summary
Content.Edit shapes    | Content\_Edit\_\_\[DisplayType\]                                  | Content\_Edit\_\_Page                                | Content-Page.Edit
Content Part templates | \[ShapeType\]\_\_\[Id\]                                           | Parts\_Common\_Metadata\_\_42                        | Parts/Common.Metadata-42
Content Part templates | \[ShapeType\]\_\_\[ContentType\]                                  | Parts\_Common\_Metadata\_\_BlogPost                  | Parts/Common.Metadata-BlogPost
Field templates        | \[ShapeType\]\_\_\[FieldName\]                                    | Fields\_Common\_Text\_\_Teaser                       | Fields/Common.Text-Teaser
Field templates        | \[ShapeType\]\_\_\[PartName\]                                     | Fields\_Common\_Text\_\_TeaserPart                   | Fileds/Common.Text-TeaserPart
Field templates        | \[ShapeType\]\_\_\[ContentType\]\_\_\[PartName\]                  | Fields\_Common\_Text\_\_Blog\_\_TeaserPart           | Fields/Common.Text-Blog-TeaserPart
Field templates        | \[ShapeType\]\_\_\[PartName\]\_\_\[FieldName\]                    | Fields\_Common\_Text\_\_TeaserPart\_\_Teaser         | Fields/Common.Text-TeaserPart-Teaser
Field templates        | \[ShapeType\]\_\_\[ContentType\]\_\_\[FieldName\]                 | Fields\_Common\_Text\_\_Blog\_\_Teaser               | Fields/Common.Text-Blog-Teaser
Field templates        | \[ShapeType\]\_\_\[ContentType\]\_\_\[PartName\]\_\_\[FieldName\] | Fields\_Common\_Text\_\_Blog\_\_TeaserPart\_\_Teaser | Fields/Common.Text-Blog-TeaserPart-Teaser
LocalMenu              | LocalMenu\_\_\[MenuName\]                                         | LocalMenu\_\_main                                    | LocalMenu-main
LocalMenuItem          | LocalMenuItem\_\_\[MenuName\]                                     | LocalMenuItem\_\_main                                | LocalMenuItem-main
Menu                   | Menu\_\_\[MenuName\]                                              | Menu\_\_main                                         | Menu-main
MenuItem               | MenuItem\_\_\[MenuName\]                                          | MenuItem\_\_main                                     | MenuItem-main
Resource               | Resource\_\_\[FileName\]                                          | Resource\_\_flower\.gif                              | Resource-flower.gif
Style                  | Style\_\_\[FileName\]                                             | Style\_\_site\.css                                   | Style-site.css
Widget                 | Widget\_\_\[ContentType\]                                         | Widget\_\_HtmlWidget                                 | Widget-HtmlWidget
Widget                 | Widget\_\_\[ZoneName\]                                            | Widget\_\_AsideSecond                                | Widget-AsideSecond
Zone                   | Zone\_\_\[ZoneName\]                                              | Zone\_\_AsideSecond                                  | Zone-AsideSecond

You should put your templates in the project according to the following rules:

* Content item shape templates are in the _views/items_ folder.
* `Parts_` shape templates are in the _views/parts_ folder.
* `Fields_` shape templates are in the _views/fields_ folder.
* The `EditorTemplate` shape templates are in the _views/EditorTemplates/_`template` name folder.  
For example, an `EditorTemplate` with a template name of _Parts/Routable.RoutePart_ has its template
at _views/EditorTemplates/Parts/Routable.RoutePart.cshtml_.
* All other shape templates are in the _views_ folder.

> **Note**`  `The template extension can be any extension supported by an active view engine, such as _.cshtml_, _.vbhtml_, or _.ascx_.

## From Template File Name to Shape Name

More generally, the rules to map from a template file name to the corresponding shape name are the following:

* Dot (.) and backslash (\) change to underscore (_).
Note that this does not mean that an _example.cshtml_ file in a _myviews_ subdirectory of _Views_
is equivalent to a _myviews_example.chtml_ file in _Views_.
The shape templates must still be in the expected directory (see above).
* Hyphen (-) changes to a double underscore (\_\_).

For example, _Views/Hello.World.cshtml_ will be used to render a shape named `Hello_World`,
and _Views/Hello.World-85.cshtml_ will be used to render a shape named `Hello_World__85`.

## Alternate Shape Rendering

As noted, an HTML widget in the `AsideSecond` zone (for example) could be rendered
by a _widget.cshtml_ template, by a _widget-htmlwidget.cshtml_ template,
or by a _widget-asidesecond.cshtml_ if they exist in the current theme.
When various possibilities exist to render the same content,
these are referred to as _alternates_ of the shape,
and they enable rich template overriding scenarios.

Alternates form a group that corresponds to the same shape if they differ only by a double-underscore suffix.
For example, `Hello_World`, `Hello_World__85`, and `Hello_World__DarkBlue` are an alternate group
for a `Hello_World` shape. `Hello_World_Summary`, conversely, does not belong to that group
and would correspond to a `Hello_World_Shape` shape, not to a `Hello_World` shape.
(Notice the difference between "\_\_" and "\_".)

## Which Alternate Will Be Rendered?

Even if it has alternates, a shape is always created with the base name, such as `Hello_World`.
Alternates give additional template name options to the theme developer beyond the default
(such as _hello.world.cshtml_).
The system will choose the most specialized template available among the alternates,
so _hello.world-orange.cshtml_ will be preferred to _hello.world.cshtml_ if it exists.

## Built-In Content Item Alternates

The table above shows possible template names for content items.
It should now be clear that the shape name is built from `Content`
and the display type (for example `Content_Summary`).

The system also automatically adds the content type and the content ID as alternates
(for example `Content_Summary__Page` and `Content_Summary__42`).

For more information about how to use alternates, see [Alternates](Alternates).

# Rendering Shapes Using Templates

A shape template is a fragment of markup that is used to render the shape.
The default view engine in Orchard is the Razor view engine.
Therefore, shape templates use Razor syntax by default.
For an introduction to Razor syntax, see [Template File Syntax Guide](Template-file-syntax-guide).

The following example shows a template for displaying a `Map` part as an image. 

    <img alt="Location" border="1" src="http://maps.google.com/maps/api/staticmap? 
         &zoom=14
         &size=256x256
         &maptype=satellite&markers=color:blue|@Model.Latitude,@Model.Longitude
         &sensor=false" />

This example shows an `img` element in which the `src` attribute contains a URL
and a set of parameters passed as query-string values.
In this query string, `@Model` represents the shape that was passed into the template.
Therefore, `@Model.Latitude` is the `Latitude` property of the shape,
and `@Model.Longitude` is the `Longitude` property of the shape.

The following example shows the template for the editor.
This template enables the user to enter values for the latitude and longitude.
    
    @model Maps.Models.MapPart

    <fieldset>
        <legend>Map Fields</legend>
                
        <div class="editor-label">
            @Html.LabelFor(model => model.Longitude)
        </div>
        <div class="editor-field">
            @Html.TextBoxFor(model => model.Latitude)
            @Html.ValidationMessageFor(model => model.Latitude)
        </div>
                
        <div class="editor-label">
            @Html.LabelFor(model => model.Longitude)
        </div>
        <div class="editor-field">
            @Html.TextBoxFor(model => model.Longitude)
            @Html.ValidationMessageFor(model => model.Longitude)
        </div>
    </fieldset>


The `@Html.LabelFor` expressions create labels using the name of the shape properties.
The `@Html.TextBoxFor` expressions create text boxes where users enter values for the shape properties.
The `@Html.ValidationMessageFor` expressions create messages that are displayed if users enter an invalid value.

## Wrappers

Wrappers let you customize the rendering of a shape by adding markup around the shape.
For example, _Document.cshtml_ is a wrapper for the `Layout` shape, because it specifies
the markup code that  surrounds the `Layout` shape.
For more information about the relationship between `Document` and `Layout`,
see [Template File Syntax Guide](Template-file-syntax-guide).

Typically, you add a wrapper file to the _Views_ folder of  your theme.
For example, to add a wrapper for `Widget`, you add a _Widget.Wrapper.cshtml_ file to
the _Views_ folder of your theme.
If you enable the **Shape Tracing** feature, you'll see the available wrapper names for a shape.
You can also specify a wrapper in the _placement.info_ file.
For more information about how to specify  a wrapper,
see [Understanding the placement.info File](Understanding-placement-info).

# Creating a Shape Method

Another way to create and render a shape is to create a method that both defines and renders the shape.
The method must be marked with the `Shape` attribute (the `Orchard.DisplayManagement.ShapeAttribute` class).
The method returns an `IHtmlString` object instead of using a template;
the returned object contains the markup that renders the shape. 

The following example shows the `DateTimeRelative` shape.
This shape takes a `DateTime` value in the past and returns a string that relates the value to the current time.
    
    public class DateTimeShapes : IDependency {
        private readonly IClock _clock;
    
        public DateTimeShapes(IClock clock) {
            _clock = clock;
            T = NullLocalizer.Instance;
        }
    
        public Localizer T { get; set; }
    
        [Shape]
        public IHtmlString DateTimeRelative(HtmlHelper Html, DateTime dateTimeUtc) {
            var time = _clock.UtcNow - dateTimeUtc;
    
            if (time.TotalDays > 7)
                return Html.DateTime(dateTimeUtc, T("'on' MMM d yyyy 'at' h:mm tt"));
            if (time.TotalHours > 24)
                return T.Plural("1 day ago", "{0} days ago", time.Days);
            if (time.TotalMinutes > 60)
                return T.Plural("1 hour ago", "{0} hours ago", time.Hours);
            if (time.TotalSeconds > 60)
                return T.Plural("1 minute ago", "{0} minutes ago", time.Minutes);
            if (time.TotalSeconds > 10)
                return T.Plural("1 second ago", "{0} seconds ago", time.Seconds);
    
            return T("a moment ago");
        }
    }
