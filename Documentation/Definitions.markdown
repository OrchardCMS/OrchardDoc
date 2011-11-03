

## Application
An application is a packaged and ready to use specialized web site.
 
#### Examples
Our CMS application is one example of an application. Other examples include Blog, Wiki, Forum or Media Gallery.

#### Contents
An application can be downloaded as source code by developers, but the most common form will include a precompiled dll, images, stylesheets, theme files and possibly a selection of plug-ins.

An application typically includes one or several packages (see definition below).

#### Packaging
Orchard applications can be deployed using WebPI, i.e. as MS-Deploy packages. They can also be xcopied into a web site.

## Package
A package is the deployment vehicle for all extensions. It is a versioned zip archive.

## Theme
A theme is a packaged look and feel for the front-end of the application.

![](../Upload/definitions%2fThemeDefinedStyles.PNG)
Themes are also sometimes called skins.
The most obvious way to personalize an application, themes provide a simple way to modify the structure and styling of the application markup. They should be easy to create, modify, install and switch. They should enable radical changes in presentation to the point where it would be difficult to tell what application technology is powering the site by looking at its UI or its markup.
 
#### Contents
A theme usually consists of a file that contains the meta-data and possibly some helpers, a CSS file, images and markup files. Some if not most of the markup files are templates.

#### Packaging
The theme can either be exploded into its constituent files or can be uploaded under zipped form.

## Template
A template is a file that contains only structural markup, but no content-specific markup. For example, a template file may describe a two-column layout. In that case, it would contain a place holder for each of the two columns but it does not specify what contents goes into them. This enables templates to be used to display a wide variety of contents. It enables the separation of layout from contents.

#### Contents
A template is usually one aspx file that defines the markup for the template and the meta-data of the template (author, available zones, etc.). It can have stylesheet, image or other dependencies.

#### Packaging
A template is deployed as part of the views of the application, or as part of a theme or package.

## Widget
A widget is a self-contained piece of UI that can be injected into specific placeholders in application pages.

![](../Upload/definitions%2fWidgets.PNG)Widgets are similar to WebParts, and like WebParts can be added to predefined zones on the page but they are much simpler in implementation.
Widgets may surface the features of a plug-in or other feature of the application, and in many cases depend on underlying application or extended features.

#### Examples
Examples of widgets include:
* category list
* latest posts
* ads
* blogroll
* search field
* rating UI

#### Contents
A widget is implemented as a code file (containing meta-data and code), a manifest and at least one user control (also sometimes called partial view in the context of MVC), and optionally an admin user control and resources such as CSS and image files. A widget may have its own controller and routes.

#### Packaging
A widget can be either exploded into its different constituent files or packaged into a zip file and uploaded to the application under this form.
A widget may be packaged together with its dependencies (such as a plug-in or other type of extension).

## Plug-in
A Plug-in is a piece of code that hooks into a specific extensibility point of the application to add new features.

Plug-ins are sometimes called add-ons, extensions or modules in other CMS platforms.

Plug-ins do not typically expose UI of their own, but may come with one or several specialized widgets whose purpose is to surface their features.

#### Examples
Examples of plug-ins include:
* replacing emoticon character sequences with images
* spam protection
* profanity filters
* order validation rules
* comments
* ratings
* search
* payment
* shipping

#### Code
The code of a simple plug-in looks like this:
    
    public class LiberalBiasPlugin {
        public string ProcessHTML(string input) {
            return input.Replace("fox", "NPR");
        }
    }


#### Contents
A plug-in is typically a single file written in C# (or in another .NET language). Other plug-in managers than the default reflection-based plug-in manager will be able to handle plug-ins written in IronPython or IronRuby, as well as plug-ins that are deployed as precompiled dlls.

#### Packaging
A plug-in may be deployed as a simple code file into app_code or as a class in a compiled dll deployed in bin or even in the GAC (although that last option is somewhat unlikely).

A plug-in's code file or dll may be distributed and installed as part of a packaged zip file that may contain one or several widgets and corresponding resources.

## Content-type
A content-type is a top-level feature of the application such as blog or wiki, a collection of top-level content entities..

#### Examples
Examples of content-types include:
* Blog
* Wiki
* Forum
* Product
* Media

#### Packaging
A content-type is typically deployed as part of a package.

## Content Item
A content item is a unit of contents in a content-type.

An item is a concept that is close to an entity but more centered around the idea of contents (as in contents management). An item can appear in a list but will also typically have its own page in the site.

#### Examples
Examples of items include:
* Blog post
* Product
* Photo
* Video
* CMS page

#### Contents and packaging
Items cannot be dissociated from their type.

## Content part
A content part is a feature that can enrich any existing content-types without prior knowledge of the content part by the content-type or by the content-type from the content part.

#### Examples
Examples of content parts include:
* Search
* Tagging
* Comments
