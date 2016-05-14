This design proposal outlines enhancements to the Themes feature to support the following:

1. The ability for the application to function independently of the Themes feature, by having default Views, Content, Scripts, Packages and Widgets folders
2. The ability for an applied Theme to override the default files in the application for Views, Content, Scripts, Packages and Widgets
3. The ability for an applied Theme to “fall back” to default files when they are not overridden by the Theme
4. An include-style helper method syntax for composition of View-related files (either in the applied Theme or in the default Views folder)



## Theme Overrides

The application defines top-level Content, Views, Scripts, Packages and Widgets folders, which are not related to the applied Theme and allow the application to function independently of the Themes feature.

In the absence of the Themes feature (or an applied Theme), the application will use the files in these directories to serve the UI for the application. 

Themes override the default files in the application by specifying files for Content, Views, Scripts and Widgets under the Theme folder.  For example, if the application contains a ~/Views/Login.aspx page, the Blue Theme may override the rendering for this page by specifying a custom ~/Themes/Blue/Views/Login.aspx page.

The View Engine will look to the currently applied Theme to resolve files before ”falling back” to the default Views folder.  Overrides allow a theme to only specify the files that require customization by the Theme, instead of requiring Themes to duplicate every file in the application.

The override feature can dramatically simplify some theme definitions - a simple Theme may only need to override the header and style sheet for the application, so it would only need to specify ~/Views/Header.aspx and ~/Styles/Site.css.

The override feature can also simplify upgrading the application to a newer version, since it allows the default files of the application to be independently updated, while preserving Theme customizations.

> **Note:** Serving static files needs to be as fast as possible and the overhead of running any code on top of the web server's tends to be prohibitively high in comparison to the benefits. For this reason, the helper APIs presented here will directly generate URLs that directly map to the physical location of the resource files instead of, for example, generating a route-based URL that could be dynamically resolved later. Where that becomes problematic is that there are a few places, such as stylesheets, that are themselves static resources but that must reference other static resources (typically background images). Because the stylesheet is itself a static resource (it is possible to serve an aspx as the stylesheet but this is confusing and breaks IntelliSense), it cannot call into the helpers and must reference its dependencies using URLs that are relative to itself. This means in turn that the dependencies in question must be physically at the place the stylesheet points. This of course puts a limitation to resource fallback: you cannot override just the stylesheet, you also need to copy everything it depends on.
> **Issue**: In cases where the page is output-cached, adding or removing a file in the theme might not have immediate effect as the cached page is still pointing at the previously resolved resource. This could be fixed by "touching" the page or by doing more elaborate management of cache dependencies.
## Display template overrides

Display and editor templates are typically defined in a module under ~/Packages/\[PackageName\]/Views/DisplayTemplates/\[items|parts\]/\[PackageName\]\.\[ItemOrPartName\]\.ascx.

Overriding such a specialized display template is possible and sometimes useful, but it is discouraged, because the theme author can't possibly handle all existing modules. Whenever possible, the markup in the module view should be generic enough to be efficiently styled through CSS.

For those cases where the theme author or the person who customizes the application needs to override one of the display templates from a core or extension module, he should do so in the current theme under ~/Themes/\[ThemeName\]/Views/DisplayTemplates/\[items|parts\]/\[PackageName\]\.\[ItemOrPartName\]\.ascx. Notice that the only change in the path was to replace ~/Packages/\[PackageName\] with ~/Themes/\[ThemeName\].

## Widget Overrides

> Preliminary: widgets are not yet implemented.
In order to allow a Theme to override the complete rendering for the application, it is necessary to support the ability for a Theme to override an individual widget's rendering.

This assumes that the Theme author has foreknowledge of which widgets are installed to the application, but in many cases an application will include a default set of widgets that can be assumed to exist.

An override for a widget is specified by adding a Widgets folder underneath the named folder for the Theme, creating a subfolder for the Widget to override, and copying the widget's view file (.ascx) to the folder.

This file can be customized any way the Theme author sees fit, and the widget engine will use this file instead of the default one supplied with the widget.

## Include Methods

To enable the override feature to work properly, it is necessary to introduce an indirection for composing View files and including dependent references such as scripts, images, and style sheets.

This allows the Theme to reference files in a way that allows the application to resolve dependent file references without depending on a hard-coded physical path.

This is achieved using helper methods to generate URLs, as described below.  It should be noted that an include-style model for composition is decidedly different from the built-in ASP.NET Master Page feature, but is more tailored to the desired audience for Theme developers, namely HTML designers that may not be familiar with the intricacies of the ASP.NET programming model.  The assumption is that includes are likely to be more immediately understandable by this audience.

View composition relies on an Html.Zone helper method that defines named zones in the views. Several providers can take advantage of the named zones, for example an include provider that resolves the appropriate View file (either local to the Theme or one of the default application files) and includes it, or a widget provider that injects widgets into zones.

Zones can include named subsections that enable the insertion of positioned contents. By default, all zones come with two subsections, before and after, that enable the insertion of contents at the beginning and end of the zone. An example of a zone with named subsections is:

    <head>
        <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
        <title><%=Html.Title() %></title><%
        Html.Zone("head", ":metas :styles :scripts"); %>
    </head>

In this example, a head zone is injected into the head tag, and it defines a subsection for metas, stylesheets and scripts. This is used to inject meta-tags, registered styles and scripts.

Example document and layout files follow:

    document.aspx:
    <%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BaseViewModel>" %>
    <%@ Import Namespace="Orchard.Mvc.ViewModels"%>
    <%@ Import Namespace="Orchard.Mvc.Html"
    %><!DOCTYPE html>
    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
        <title><%=Html.Title() %></title><%
        Html.Zone("head", ":metas :styles :scripts"); %>
    </head>
    <body><%
        Html.ZoneBody("body"); %>
    </body>
    </html>

Note: The document file is almost never overridden by the theme.

    layout.ascx:
    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<BaseViewModel>" %>
    <%@ Import Namespace="Orchard.Mvc.ViewModels"%>
    <%--
    name: Sample layout template
    zones: Head, Header, Content, Right sidebar, Footer
    --%><%
    Html.RegisterStyle("site.css");
    Html.RegisterScript("MyScript.js");
    Model.Zones.AddRenderPartial("header");
    Model.Zones.AddRenderPartial("footer");
    %>
    <div class="page">
        <img src="<%= Html.ContentFolderUrl("images/banner.jpg") %>" alt="Banner"/>
        <img src="<%= Html.Theme("Logo") %>" alt="Logo"/>
        <div id="header"><%
            Html.Zone("header");
            Html.Zone("menu"); %>
        </div>
        <div id="main"><%
            Html.ZoneBody("content");
        %></div>
        <div id="rightSidebar"><%
            Html.Zone("right sidebar", "UnorderedListLayout")
        %></div>
        <div id="footer"><%
            Html.Zone("footer");
        %></div>
    </div>

> **Note**: in this example, some contents are inlined but in a real template those would really be in partial views.
In this example, the calls to Html.Zone declare zones on the page where components will be able to inject contents and widgets.

For the header and footer zones, calls to AddRenderPartial will try to find a partial view with the same name (without its extension) as the zone (first in the theme, then in the top views) and will include it if it's found.

The included files can themselves contain calls to Html.Zone() for nested composition.

> **Issue:** when new zones are being added by included partial view, how will the admin UI discover them?
The page also contains specialized calls to other APIs that will be detailed below.

> **Open Issue**: Do we need a version of Html.Zone that accepts a model?

How many overloads of RenderPartial do we want to repeat?
> **Question:** includes will be so common that we could consider having a shortcut like we have for localization. Zone("Content") or Z("Content")?
The contents of each include file should be semantically complete HTML. No separation of opening and closing tags into separate file should exist. When this looks necessary, the surrounding markup should be moved to the parent file.

#### Html.Title
A special helper that injects the page title.

#### Html.RegisterScript

Registers a JavaScript file for inclusion by Html.Zone("head", ":metas :styles :scripts").  This helper method accepts as input a path that is relative to the root Scripts directory (of either the theme or root application).

It registers the script to include but does not render anything immediately. The actual rendering of the script tag will happen when the view calls Html.Zone("head", ":metas :styles :scripts").

The actual URL that will be rendered into the page will be mapped by the web server directly to either the theme or root application Scripts directory without having to run application code.

The system will search for the correct physical file to serve  in the following order:

1. ~/Themes/ThemeName/Scripts
2. ~/Scripts


**Example:**

    Html.RegisterScript(�myscript.js�)

...registers a URL to the first physical file that exists in these locations (in order):

* /ApplicationName/Themes/ThemeName/Scripts/myscript.js
* /ApplicationName/Scripts/myscript.js


**Parameters:**

_scriptPath_ \[String\] - the path to the script file, relative to the root of the Scripts directory.

**Return Value:**

None

#### Html.RegisterStyleSheet

Registers a CSS file for inclusion by Html.Zone("head", ":metas :styles :scripts"). This helper method accepts as input a path that is relative to the root Content directory (of either the theme or root application).

It registers the stylesheet to include but does not render anything immediately. The actual rendering of the link tag will happen when the view calls Html.Zone("head", ":metas :styles :scripts").

The actual URL that will be rendered into the page will be mapped by the web server directly to either the theme or root application Scripts directory without having to run application code.

The system will search for the correct physical file to serve  in the following order:

1. ~/Themes/ThemeName
2. ~/Themes/ThemeName/Content
3. ~/
4. ~/Content


**Note:** It is not correct (and might result in an exception) to include stylesheets from widgets using this API, since these stylesheets belong in the <head> of the document. Refer to the section entitled “Widget Scripts and Stylesheets” below.

**Example:**

    Html.RegisterStyleSheet("mystylesheet.css")

...registers a URL to the first physical file that exists in these locations (in order):

* /ApplicationName/Themes/ThemeName/mystylesheet.css
* /ApplicationName/Themes/ThemeName/Content/mystylesheet.css
* /ApplicationName/mystylesheet.css
* /ApplicationName/Content/mystylesheet.css


**Parameters:**

_styleSheetPath_ \[String\] - the path to the CSS file, relative to the root of the Content or theme directory.

**Return Value:**

None

#### Html.Zone("head", ":metas :styles :scripts")
We'll have a special provider that recognizes the "Head" zone and generates the script, style and link tags resulting from previous registration by widgets and views. In particular, Html.RegisterScript and Html.RegisterStyleSheet calls result in Html.Include("Head") generating the relevant tags.

This special provider is also the one that will inject style overrides.

The widgets can also participate in what gets rendered by this API by exposing their list of scripts and stylesheets (see [Widgets](widgets)).

The list of stylesheets and scripts to be included is first processed to remove duplicates, and then the helpers proceeds to rendering the relevant tags.

**Parameters:**

_name_ \[string\] - the name of the zone. May correspond to the name of a partial view, minus the file extension.

_subsections_ \[string\] - a space-separated list of subsections for the zone. Each subsection name begins with a colon. The ":before" and ":after" subsections always exist no matter what is specified in this parameter.

_layout_ \[String\] - Optional: the name of the view file that defines the chrome to render between the different items of the zone (to surround individual contents). The chrome template file looks like this:

> Preliminary
    UnorderedListLayout.ascx:
    
    <@Control language="C#" inherits="System.Web.Mvc.ViewUserControl<List<object>>" %>
    <% if (Model.Length > 0) { %>
      <% if (Model.Length == 1) { %>
      <%= Html.DisplayFor(Model[0]) %>
      <% } else {
      <ul class="layoutList">
        <% foreach(var item in Model) { %>
        <li><%= Html.DisplayFor(item) %></li>
        <% } %>
      </ul>
      <% } %>
    <% } %>

If no layout file with that name is found, a default layout is used, that is looked for in the template directory, then in the fallback theme.

#### Html.Theme
Includes a theme setting.

**Parameters:**

_settingName_ \[String\] - the name of the setting to include.

**Return Value:**

A string that contains the value of the setting, or an empty string if it not found.

## Default Includes
By convention, the pages of the Orchard Commerce application are divided into the following includes.

Specific Themes may override and/or define additional include files.  

#### Head.ascx
Contains meta tags, styles, and scripts that should be included in every page of the application. In the example above, the contents of the head file has been inlined so that the file contains examples of each include method. In a real template, this contents would be in head, and the template itself would have a simple Html.Include("head").

#### Header.ascx
Contains header content that is common all pages (site name banner image, navigation menus, login/logout link, etc).

Note: in the example above, the banner has been put in the template itself but it shouldn't be in a real template.

#### Footer.ascx
Contains footer content that is common to all pages.
The overall composition of views might result in something like this:

![View composition](../Upload/cms/cms-template-hierarchy.png)
## Content and Script Includes

Supporting Theme overrides for Views, Scripts, and Content enables Theme authors to simply copy files from the default application's top-level folders into the Theme's folder structure.

However, a given View page might have references to other files - in particular, content such as images and stylesheets, and scripts.

In order to keep these references intact when copying files to the Theme, it is necessary to support helper methods for referencing files from the Content and Scripts directories, namely Html.ContentFolderUrl, Html.RegisterStylesheet and Html.RegisterScript.

These methods take as input a path relative to the local Content or Scripts folder for the Theme (or Widget) and return a resolved URL.

For example, in a Theme, a particular View page might have code as follows:

    <a href="<%=Url.Action("Show", "Cart") %>"><img
      src="<%=Html.ContentFolderUrl("images/cart.gif") %>"
      alt="Cart" /></a>

The Html.ContentFolderUrl returns a path to /ApplicationName/Themes/MyCurrentTheme/images/cart.gif, /ApplicationName/Themes/MyCurrentTheme/Content/images/cart.gif, /ApplicationName/images/cart.gif or /ApplicationName/Content/images/cart.gif, whichever is found first when the API is called. This relies on IIS static file handling to serve the content, for performance reasons.

    <a href="/Cart/Show"><img src="/ContentFiles/images/cart.gif" alt="Your cart" /></a>

A similar Html.RegisterScriptUrl is supported for script file references, which searches under the appropriate Scripts folder (first in the Theme, then in the top-level Scripts folder for the application).  

In general, if a content or script file is meant to be Theme-overridable, these Include methods should be used to reference the file path.

In the example above, the View page might be in the top-level Views folder and the Theme overrides the cart.gif image in the Theme's Content/images folder.

Conversely, the View page might be overridden by the Theme, but the cart.gif image remains in the top-level Content/images folder.

In either case, the references will resolve correctly at runtime.
