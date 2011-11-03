
Orchard uses templates and shapes to build views. Templates are conceptually similar to partial views in ASP.NET MVC, and they provide the basic structure for rendering shape data in a page. A template can contain web page content such as HTML markup, CSS styles, and JavaScript code to help render shape data. In addition, a template can contain server-code blocks so that you can access and render shape data in a web page. Shapes are dynamic data models that represent content structures such as menus, menu items, content items, documents, and messages. Shapes provide the data for dynamic views (as opposed to the static ASP.NET views in MVC) that templates render at run time. For more information about working with shapes, see [Accessing and Rendering Shapes](Accessing-and-rendering-shapes). 

The view engine is responsible for parsing the template and rendering the shape data into a web page. The default view engine for Orchard is the Razor view engine, which is installed with [ASP.NET MVC 3](http://www.asp.net/mvc/mvc3). In order for the Razor view engine to correctly parse a template, you must write the template using the Razor syntax, which defines a small set of rules for writing web page templates that contain a mixture of static web page content (such as HTML markup) and programming code. 

This topic gives an overview of the Razor syntax used in templates and layout pages. It then shows you how to create your own shape template.


# Razor Syntax Primer
Using the simple rules of the Razor syntax, you can embed server-based code (in C# or Visual Basic) into web page markup. Like server code in other ASP.NET web applications, the server code that you embed in a web page using the Razor syntax runs on the server before the page is sent to the browser. The server code in ASP.NET web pages can dynamically generate client content such as HTML markup, CSS, or JavaScript, and then send it to the browser along with any static HTML that the page contains.

The most commonly used language for writing server code with the Razor syntax is C#, and the examples in this article are all written in C#. For an introduction to web page programming using the Razor syntax with C#, see [Coding with the Razor Syntax](http://go.microsoft.com/fwlink/?LinkId=202890). For a Visual Basic version of the introduction, see [ASP.NET Web Pages Visual Basic](http://go.microsoft.com/fwlink/?LinkId=202908).

Web pages that contain Razor content have a special file extension (_.cshtml_ for C#, _.vbhtml_ for Visual Basic). The Microsoft feature name for these pages is ASP.NET Web Pages with Razor Syntax. These pages contain the full functionality of the ASP.NET MVC page framework, with the added capability of the Razor syntax for writing page templates. The server recognizes these file extensions, runs the code that's marked with Razor syntax, and sends the resulting page to the browser.

## Experimenting with Razor Syntax
If you want to experiment with Razor syntax, you might want to start with WebMatrix. WebMatrix is a free programming environment for creating ASP.NET Web Pages with Razor syntax. It includes IIS Express (a development web server), ASP.NET, and SQL Server Compact (an embedded database also used by Orchard).

WebMatrix gives you productivity features that support Razor syntax, such as syntax highlighting for code and IntelliSense for HTML markup and CSS. You can also work with Razor syntax in Visual Studio 2010, which provides the added features of full IntelliSense for your server code, and also lets you use the Visual Studio debugger. For more information, see [Program ASP.NET Web Pages in Visual Studio](http://go.microsoft.com/fwlink/?LinkId=205854). However, you can use any text editor to experiment with Razor syntax. 

To download and install WebMatrix, go to the [WebMatrix downloads page](http://www.microsoft.com/web/downloads/) and click the link for the Microsoft Web Platform Installer to start your download.

## Code Blocks and Inline Expressions
You add code to a web page using the `@` character. Braces ({ }) are used to mark a code block. For example, the following expression assigns the string "Hello World" to a variable named `myMessage`.

    
    @{ var myMessage = "Hello World"; }


Code blocks can be inserted in the web page interspersed with HTML markup. The following code defines a greeting message that includes the current day of the week and embeds the message in the page markup.

    
    @{
        var greeting = "Welcome to our site!";
        var weekDay = DateTime.Now.DayOfWeek;
        var greetingMessage = greeting + " Today is: " + weekDay;
    }
    <p>The greeting is: @greetingMessage</p>


![](../Upload/screenshots/Razor_welcome.png)

When the code block consists of a single expression, such as a `for` loop, you can place the `@` character in front of a language keyword. In this case, the `for` loop serves as the entire code block, so you do not need an outer `@` character and braces to enclose the block. You can use the same approach with other block coding structures in C#:  `if-then` statements, `foreach` and `while` loops, `case` statements, and so on. In the following expression, the `@` character is placed in front of the keyword `for`. The loop prints a set of numbered lines from 10 to 20. 

    
    @for(var i = 10; i < 21; i++)
    {
        <p>Line #: @i</p>
    }


![](../Upload/screenshots/razorsyntax_forloop.png)

The following example shows how to embed server-side comments in your web pages. These comments are stripped from the markup before the web page is sent to the browser, so users cannot see them. In contrast, client markup comments (`&lt;!-- --&gt;`) are not stripped from the markup, so users can see them.

    
    @* This is a one-line comment. *@
    
    @*
       This is a multi-line comment.
       It can continue for any number of lines.
    *@


Comments within a Razor syntax code block can also use the standard C# commenting syntax (`//`).

## Accessing Orchard Objects in Code
Orchard 1.1 provides simplified access to objects in code, because you can directly access content part objects without having to use casting or extension methods.  

The following examples show how to access a `Title` property on a widget part. The first code example shows the older way of access the property from Orchard version 1.0.20, found in the _~\Modules\Orchard.Widgets\Views\Widget.Wrapper.cshtml_ file. Note that the code casts the returned object to the `IContent` interface and uses an `As` extension method to access the property.

    var title = ((IContent)Model.ContentItem).As<WidgetPart>().Title;


Here is the updated and simplified way that you can access the property in Orchard 1.1:

    var title = Model.ContentItem.WidgetPart.Title;


Here is a second example of Orchard object access that has been simplified in version 1.1. The following code is in Orchard version 1.0.02 to access the fields for a content item. This example is from a content shape, so the `ContentItem` object is accessed directly on the `Model` object. The first line of code casts to `ContentItem`, and then the second line uses an `As()` extension method to access the collection of fields on the content part. The return value of the code is the picture width.

    
    var contentItem = (ContentItem)Model.ContentItem;
    var picture = (ImageField)contentItem.As<ProfilePart>().Fields.First(f => f.Name == "Picture");
    @picture.Width


Here is an approach you can use in Orchard 1.1, with the amount of code required to get the picture width reduced from three lines to just one:

    @Model.ContentItem.ProfilePart.Picture.Width


# Creating Shape Templates
Shape templates are fragments of HTML markup for rendering shapes. To demonstrate how shape templates are used, suppose you want display a map on your web page. The shapes that will contain the map settings for display and edit are defined in the following driver code.

    
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


The `Display` method is used to display the map. The `Editor` method marked `//GET` is used to display the shape result in editing view for user input. The `Editor` method marked `//POST` is used to redisplay the editor view using the values provided by the user. These methods use different overloads of the `Editor` method.

For more information about how to define shapes, see [Accessing and Rendering Shapes](Accessing-and-rendering-shapes).

The following example shows a simple template that is used to display the map. 

    
    <img alt="Location" border="1" src="http://maps.google.com/maps/api/staticmap? 
         &zoom=14
         &size=256x256
         &maptype=satellite&markers=color:blue|@Model.Latitude,@Model.Longitude
         &sensor=false" />


This example shows an `img` element in which the `src` attribute contains a URL and a set of parameters passed as query-string values. In this query string, `@Model` represents the shape that was passed into the template. Therefore, `@Model.Latitude` is the `Latitude` property of the shape, and `@Model.Longitude` is the `Longitude` property of the shape.

The following example shows the template for the editor. This template enables the user to enter values for latitude and longitude.

    
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


The `@Html.LabelFor` expressions create labels using the name of the shape properties. The `@Html.TextBoxFor` expressions create text boxes where users enter values for the shape properties. The `@Html.ValidationMessageFor` expressions create messages that are displayed if users enter an invalid value.

# Layout and Document Templates
The layout and document templates are special template types that define the structure of a web page. These templates are most often used in themes for laying out a web page. Each web page has a `Layout` shape (dynamic object) associated with it. The `Layout` shape defines the zones that are available to hold web page contents. The layout and document templates determine how the zones defined in the `Layout` shape will be laid out on the web page.

The layout template (_Layout.cshtml_) lays out the zones for the body of the web page. The document template (_Document.cshtml_) wraps around the layout template and lays out the remainder of the web page.

By default, the `Layout` shape defines three zones for use in the document template (`Head`, `Body`, and `Tail`) and one shape for the layout template (`Content`). In the document template, the `Head` zone is used to define the header of the web page, the `Body` zone is where the layout template is inserted, and the `Tail` zone is used for the footer of the web page.

The following example shows a typical document template. 

    
    @using Orchard.Mvc.Html;
    @using Orchard.UI.Resources;
    @{
        RegisterLink(new LinkEntry {Type = "image/x-icon", Rel = "shortcut icon", 
           Href = Url.Content("~/modules/orchard.themes/Content/orchard.ico")});
        Script.Include("html5.js").AtLocation(ResourceLocation.Head);
    
        var title = (Request.Path != Request.ApplicationPath && !string.IsNullOrWhiteSpace((string)Model.Title)
                        ? Model.Title + WorkContext.CurrentSite.PageTitleSeparator
                        : "") +
            WorkContext.CurrentSite.SiteName;
    }
    <!DOCTYPE html> 
    <html lang="en" class="static @Html.ClassForPage()"> 
    <head> 
        <meta charset="utf-8" />
        <title>@title</title> 
        @Display(Model.Head)
        < script>(function(d){d.className="dyn"+d.className.substring(6,d.className.length);})(document.documentElement);</script>
    </head> 
    <body>
    @* Layout (template) is in the Body zone at the default position *@
    @Display(Model.Body)
    @Display(Model.Tail)
    </body>
    </html>


This document template contains a code block that links to an icon and formats the page title. It also contains the basic HTML structure for the web page, and it determines placement of the `Head`, `Body`, and `Tail` zones.

The following example shows a typical layout template. Notice that the layout template references zones in addition to the `Content` zone. These new zones are added to the `Layout` shape if content is added to the zone.  

    
    @* Html.RegisterStyle("site.css"); *@
    @{ 
        Model.Header.Add(Display.Header(), "5");
        Model.Header.Add(Display.User(), "10");
        Model.Header.Add(Model.Navigation, "15");
    }
    <div id="page">
        <header>
            @Display(Model.Header)
        </header>
        <div id="main">
            <div id="messages">
                @Display(Model.Messages)
            </div>
            <div id="content-wrapper">
                <div id="content">
                    @Display(Model.Content)
                </div>
            </div>
            <div id="sidebar-wrapper">
                <div id="sidebar">
                    @Display(Model.Sidebar)
                </div>
            </div>
        </div>
        <div id="footer-wrapper">
            <footer>
                @Display(Model.Footer)
            </footer>
        </div>
    </div>


This layout template contains a code block that adds subzones to the `Header` zone. It also refers to the following new zones: `Messages`, `Sidebar`, and `Footer`.

In order for these zones to appear in the Orchard UI so you can add content to them, you must reference the zones in the theme's _Theme.txt_ file, as shown in the following example.

    
    Name: SimpleTheme
    Author: 
    Description: Simple example theme.
    Version: 1.0
    Tags: Simple
    Website: http://www.orchardproject.net
    Zones: Header, User, Navigation, Messages, Content, Sidebar, Footer

  
  
  

# Change History
* Updates for Orchard 1.1
    * 4-4-11: Updated introduction to the Razor syntax. Added new section on accessing Orchard objects in code. 
