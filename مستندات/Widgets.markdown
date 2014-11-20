
Widgets are fragments of UI that surface specific data or features. Examples of widgets include navigation menus, image galleries, ads,  videos, tag clouds.

Widgets are typically rendered in a zone on the page. A zone can contain zero or more widgets.


# Anatomy of a widget

A widget is composed of two or more files that are placed in a /Packages/\[MyPackage\]/Widgets directory of the application.

In many ways, a widget can become a simplified mini-MVC application, with a model, a controller and one or several views.

## Widget meta-data

The meta-data is defined as part of the package.txt manifest file at the root of the widget's directory:

    
    Widgets:
        - Tag Cloud
            Author: Renaud Paquay
            Description:
                Displays available tags as a cloud where the size of each tag
                reflects the number of items that use it.
            Version: 0.1


In this example, we give the widget a display name (the name of the widget folder is used otherwise), we describe the author of the widget, give a long description and version number.

## Widget code file

The code file for a widget is named \[MyWidgetName\]\.cs by convention and is at the root of the widgets subdirectory of the package directory. This file contains the definition, settings and server code for the widget.

Here is an example of code for a simple widget:
    
    public class ProductList : Widget {
        // ... widget code


The properties will be interpreted as settings for the widget instance.

The widget class is used as the model for the widget. As we will see, the widget's views are strongly-typed to use the widget class as the model.

The widget's class name should be the same widget name that is also defined in the package manifest.

The widgets in the widgets directory are dynamically compiled by the application, but widgets may also be deployed as part of a compiled package. In that case, the discovery is made through reflection instead of file-based discovery. The manifest for compiled widgets will be deployed as part of the package (TBD).

> **Note:** dynamic compilation of widgets will be implemented during the same iteration as plug-in dynamic compilation.

### Data access

Widget instances are content items that are contained in widget groups, which are also content items. The data persistence will be handled by Orchard but might use serialization in a single widgets table that is not specialized by widget type.

## View file

The second necessary part in a widget is an ascx file must be named \[MyWidgetName\]\.ascx by convention. This file is placed in the package's display template folder. The view file is actually just the display template for the widget.

This file is a partial view that uses the widget class as its model type.

Here is an example of a widget's view code:
    
    <%@ Control Language="C#" 
        Inherits="System.Web.Mvc.ViewUserControl<ProductList>" %>
    
    <h5 class="widgetTitle"><%=Html.Encode(Model.Title)%></h5>
    <ul id="imgholder_<%=Html.Encode(Model.ID)%>" class="widgetBody">
      <%foreach (Product p in Model.Products) { %>
      <li>
        <p><a href="<%=Url.Action("show","home",new{sku=p.SKU})%>"
            title="Go to <%=Html.Encode(p.Name)%> Details Page"
            ><%=Html.Encode(p.Name)%></a><br />
           <a href="<%=Url.Action("show","home",new{sku=p.SKU})%>" 
               title="Go to <%=Html.Encode(p.Name)%> Details Page"
               ><%=Html.Encode(p.Price.ToString("C"))%></a>
        </p>
      </li>
      <%} %>
    </ul>

### CSS conventions

The widget views are built with a number of conventions that will make theme overrides and integration easier. The default view for a widget -the one that comes with the package- should be neutral, semantic markup so that it can inherit the current theme's styles without necessitating a specific view override.

We will set-up the conventions for a few class names that will make it easy to style all widgets with simple CSS:

* widgetTitle
* widgetBody

## Administration view

Optionally, a widget can provide its own UI to manage its settings.

It does so by having a \[MyWidgetName\]\.ascx (for example PageMap.ascx) partial view in the package's EditorTemplates directory. That partial view may rely on specific controller actions that may be implemented as part of the widget (see below).

If no edit view exists for the widget, Orchard will generate UI using MVC editor templates like for any other content type.

## Content and script files

Content files (resp. script files) should be placed in a "Content" (resp. "Scripts") directory under the package's directory. Content files include stylesheets and images.

If a widget includes its own script files or its own stylesheets, it should declare those by calling Html.RegisterScript and Html.RegisterStylsheet from the view. Orchard will make a double pass on views, which will enable registration API call results to be included into the head.

Implementing those methods will result in the theme's view code for the current page to remove duplicates and render the relevant script and link tags in the head of the page. For this to happen, the page view's header code must contain a call to `Html.Include("Head")` (usually in head.ascx).

Orchard will look first for overrides for those files in the current theme folder, and will then look for them in the package's content folder. URLs for script files should be relative to the Scripts subfolder and URLs for stylesheets should be relative to the Content subfolder.

If two widget instances ask for the same script or the same stylesheet, Orchard will know how to include them only once.

To include images, a widget's view can use the Html.ContentFolderUrl helper, which will resolve to the widget's content folder when used from within a widget view:
    
    <img alt="circle" src="<%= Html.ContentFolderUrl("circle.png")%>"/>


The URL returned by `ContentFolderUrl` is already HTML-encoded. If the URL contains fragments that need to be URL-encoded, that encoding needs to be done on the parameter by the calling code, before it calls into the API. The same is true of the URLs returned by GetScriptUrls and GetStyleSheetUrls.

All the content resources that the widget needs should be included in the widget package's Content folder. The widget view should not rely on global application or global theme resources to ensure that the widget is a self-contained entity that can be deployed as is. Orchard will not fallback to global resources when a resource is not found either in the current theme's widget override folder or in the widget's content folder.

Exceptions to that rule is when the widget needs scripts or stylesheets that have not been written by the widget author and that are susceptible to be used by more than one widget type. In this case, it is recommended that the widgets refers to a (preferably version-neutral) URL of the resource stored on a CDN.

To allow for the CDN scenario, the resource URLs can be specified either as local relative URLs (in which case it is interpreted relative to the Content or Script subdirectory of the widget directory), as an application-relative URL (e.g. "~/Scripts/somelibrary.js") or as an absolute URL (e.g. "http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.js").

> **Note:** Serving static files needs to be as fast as possible and the overhead of running any code on top of the web server's tends to be  high in comparison to the benefits. For this reason, the helper APIs presented here will directly generate URLs that directly map to the physical location of the resource files instead of, for example, generating a route-based URL that could be dynamically resolved later. Where that becomes problematic is that there are a few places, such as stylesheets, that are themselves static resources but that must reference other static resources (typically background images). Because the stylesheet is itself a static resource (it is possible to serve an aspx as the stylesheet but this is confusing and breaks IntelliSense), it cannot call into the helpers and must reference its dependencies using URLs that are relative to itself. This means in turn that the dependencies in question must be physically at the place the stylesheet points. This of course puts a limitation to resource fallback: you cannot override just the stylesheet, you also need to copy everything it depends on.

## Widget controllers and routes

A widget may expose its own controller to handle user interaction.

A widget's controller should be named by convention \[MyWidgetName\]Controller and should be defined in the \[MyWidgetName\]\.cs file that also contains the widget's definition class and record class. It should implement the IController interface or inherit from a class that does.

To expose custom routes, the widget provider should act like other content type provider classes.

# Widget groups

The administrator can define named widget groups at the site level. These groups consist in an ordered list of widgets and the configuration for these widgets. The scope of the configuration is the widget group.

What group of widgets goes into each zone for a given content item is handled by a specialized content part and is thus configurable at the content-item level.

> **Note:** we won't implement widget group administration in this iteration. Instead, we will code the infrastructure and will "hard-code" groups that the templates will statically include.

# Initial widgets

We will implement the following widgets as part of the first widget iteration:

* Tag cloud
* HTML

The HTML widget will be used to render the site footer.

In the first iteration, we'll inject the widgets into the views with hard code. Configuration will come in a later iteration.

In future iteration, we could look at the following widgets (in no particular order):

* Blog archives
* Recent items
* Ads
* Analytics / stats
* Xbox Live
* Twitter
* FaceBook
* Current user / login / logout
* Media
* Flickr
* Zune

Community contributions could also provide some of these widgets.

# Permissions

The owner in this context refers to the content item owner when assigning a widget group to a zone in the template, or to the site owner for other permissions.

Permission                                 | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
Create and manage widget groups            | No    | No         | Yes   | Yes    | No     | No
Assign a widget group to a zone            | No    | No         | Yes   | Yes    | Yes     | No
