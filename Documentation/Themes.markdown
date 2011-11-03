
## Context
Many applications owe their success in part to the availability of a large number of themes, which is in turn due to the simplicity of building new themes. An MVC type of framework where the view to use can be dynamically determined instead of being mapped 1:1 from url to file system like in WebForms certainly helps building a theming engine.

## Audience
The audiences for this feature are:
* Application administrators and users: users with little to no technical skills. These users will typically upload a theme to their application or choose one of the pre-installed ones, configure it and use it.
* Designers: users with little to no knowledge of programming concepts but with design, CSS and HTML skills. Might create a new theme by modifying an existing one.

## Goals

* Simplicity of the theme model, enabling the designer audience to create themes.
* Enable theme development using notepad and an FTP client.
* Enable users to change themes on the fly.
* Enable users to easily discover and install new themes.
* Enable users to customize the look of their site without having writing rights to the site file system.

## Scenarios

#### Installation

The installation experience for a theme must be extremely simple.

It should be possible to choose a theme from our online repository and just add it to the site. In that scenario, the user goes to the themes section of the admin tool, clicks "Search for themes online", navigates through categories or does a text search in the catalog. He then chooses a theme, clicks "install". The theme is then downloaded and installed. The user may then configure, preview and use the theme.

Ideally, the online repository of themes and the installed list of themes are one and the same (with the ability to filter by installed or online).

In another scenario, the user unzips the theme on his local hard drive and uploads its contents to the server using FTP.

In another scenario, the user connects to his dedicated server using Terminal Services, copies the zip into the server's file system, directly under the application's themes folder and unzips the theme. Once this is done, the theme can be configured from the admin UI. The zip file can remain in the themes directory.

In another scenario, the user uploads the zipped theme through the admin UI. The application then unzips and installs it.

#### Switching between themes

A user wants to switch from the current theme to one of the other themes installed on the box. He goes to the themes section of the admin UI, browses the list of installed themes (including thumbnail previews), chooses the new theme he wants. The admin UI shows an overlay that shows a live preview of the theme with the actual user's data, providing a faithful glimpse at what the site will look like with this theme. He can even navigate within that preview to check other pages look OK with the new theme. Once he has decided whether the new theme should be applied, he can revert the changes (which never affected other users of the site) or apply the changes for other users to enjoy.

#### Configuration

A user adds a new theme to his site. He goes to the admin tool, goes to the themes section and chooses the new theme. He is then taken to the theme's admin applet where he chooses a different color palette that fits his company's design guidelines. He also uploads a new logo that replaces the default logo that came with the theme.

#### Theme Creation

A user downloads an existing two-column theme. He opens its files in a text editor and modifies them by adding a third sidebar and tweaking the CSS to give it a completely new look. He tests the theme locally and checks everything works. He then packages the theme files into a zip file and uploads it to the Orchard theme repository.

#### Uninstallation

A user decides not to use the "pretty in pink" theme anymore and wants it out of the system. He goes into the admin tool, selects the theme and clicks "uninstall". After confirming the operation, the theme is removed from the system. If the site was configured to still use that theme, it automatically reverts to the default theme (which can't be uninstalled).

#### Local themes

In some cases such as when the site contains several blogs, it will be desirable to apply different themes to different parts of the site.

To enable this scenario, we will provide the extensibility points for the theme to be determined dynamically, and will make the "apply theme" UI re-usable.

## Choices

There are a number of choices a theme engine has to make that are impacting both its simplicity and its power.

#### Should themes define a hierarchy and should there be a fallback from a theme to its parent when a file is absent?

Creating a fallback mechanism between themes enables theme authors to create derived themes that contain only the difference with the parent. For example, a theme might contain only a stylesheet.

On the other hand, the penalty of copying all files is relatively low and it removes the kind of confusion where it's difficult to understand in which file to look when something goes wrong or when one wants to modify something that is not part of the theme but that can only be found in one of the parents.

This also greatly simplifies both the theme engine and the development of the actual themes as dependencies of the theme can be referenced directly, without the need to dynamically resolve them relatively to anything but the current view itself.
Without fallback, themes are self-contained and can be copied around without having to also copy parent themes with them. It is also avoiding the issue where the parent theme is uninstalled and its descendants stop working or change behavior.

In summary, the added complexity and potential confusion that cross-theme fallback introduces does not seem to be justified by the marginal benefit it brings. Without fallback, all the views and their dependencies that might be used to display any data will always be found within the current theme's directory.

An intermediate solution is to have one minimalist default theme that must always be present and have this be the only fallback mechanism that works across themes. This enables a theme author to only override the stylesheet for example without having to copy all files, and it avoids the issues associated with deleting the parent theme for example.

Having a default or system theme also makes it easier to add or remove theming from an application. One could consider that the default theme is the application itself and that themes are just a way to override parts or all of the default rendering of the application. This plays very well with the architecture of view engines in ASP.NET MVC.

The theme engine will be developed as a package that could be de-activated or uninstalled. When that is the case, the application would revert to the "safe mode"'s default views.

#### Should themes handle multiple content types?

Having themes that can be applied to any content type seems quite compelling. Still, on first analysis, themes that are too general might be too much of a constraint and might impair the ability of each application to provide an experience that is unique and well adapted to the problem it's addressing.

The approach of having a fallback within the themes from the most specific view to more generic views allows for both specialized and generic themes.

In Orchard, the same thing opens the door for even a theme that is specialized for e-commerce, for example, to be used with a blogging content-type unmodified, or to be modified to adapt to another type of contents. A theme could also have specialized views available for more than one content type.

The separation of layout templates from specialized partial views is also a way to make it easier to obtain more universal themes.

The default theme should include very basic and semantic markup, with a stylesheet that is easy to modify and override. Packages will typically add new partial views to that default theme, and those should have the same semantic qualities so that themes can get good results even if they only override CSS and have no knowledge of the installed packages. Most themes will do most of their work through CSS, but the theme author or the site administrator should be able to get into the theme and add specialized overrides for any view, including the ones that are added by packages.

#### Should themes be customizable from the admin tool?

It is debatable on first analysis whether themes should expose any sort of configuration as they can easily be modified using simple text editors. On closer look, when one considers the end user's point of view as well as multi-tenant scenarios, the ability for themes to expose settings such as a logo or a color palette becomes much more important.

When a user just installed an e-commerce package, for example, the first thing he will want to do, before even starting to populate the product catalog, will be to brand the application with his logo and colors. If the experience to do that is to go into a code editor, we probably already failed him.

In multi-tenant scenarios (which we don't explicitly support as a goal today but want to keep in our sights for the relatively near future), the user won't have access to any modifications of the site's physical files. One solution that is adopted by many applications is to expose "CSS overrides" which are a secondary, database-bound CSS stylesheet that the application can add to the theme's default CSS at runtime. This clearly works and we will support it, but exposing the most common settings directly in the admin with an adapted UI would be friendlier.

#### Should themes use master pages?

Master pages are a great feature of ASP.NET but also one that is virtually unseen on other platforms that seem content with a simpler include mechanism.

They constitute an inversion of the concept of an include or user control: it's the contents that "include" the master instead of the more familiar case where the main files includes the contents.

This inversion works really well once it's understood and removes some repetition but it definitely is a concept that can be hard to grasp, especially for non-developers. Theme development will precisely be done by designers that are not necessarily familiar with such concepts. In the context of themes, master pages don't seem to bring enough value to justify introducing the new concept.

Some themes might very well use master pages, but the default ones that we ship should probably avoid them.

#### Should themes contain code files?

A code file may be the place where theme authors can write reusable helpers that are specific to the theme. This is also where themes could define specialized plug-ins and widgets. One example of a theme-specific plugin might be specific view resolution logic.

While not strictly necessary, it is an interesting addition, similar to an app_code local to the theme. On the other hand, having code in a theme goes against separation of concerns as the theme should be specialized purely in customizing the rendering. The view resolution scenario for example could be handled by having the theme depend on a package that contains the view resolution plug-in.

This might also be the place to define the theme's configuration settings as properties, but this scenario can also be handled through a YAML description similar to the ones we use for meta-data.

If a theme introduces a setting that has a specific editor, it could make sense to deploy the code for the editor with the theme, although it could also be argued that that editor, to be reusable by other themes, should be separated into a package rather than deployed with the theme.

In the absence of a compelling scenario that couldn't be handled in another way, we won't allow for code files in themes for now.

#### Where and how should meta-data be defined?

The way we define meta-data for themes should preferably be consistent with the way we define it for packages, i.e. a YAML file at the root of the theme. This will make it easy for the application to reflect on the theme to display the meta-data.

## Feature description

#### Sample themes

We will design several themes that will be delivered with the application.

One of these themes will be designed to exercise all the features of the theme engine, including overrides for specific display templates and widgets.

Another theme will be designed to be a minimal theme, consisting simply of a manifest and a stylesheet (and associated images).

#### Templates

The list of templates that we will deliver initially is:

* One-column: a header, a large content zone and a footer
* Two-column: a header, a sidebar (positioned on the left in safe mode templates), a large content zone and a footer.
* Three-column: a header, a left sidebar, a large central content zone, a right sidebar and a footer.

Those templates, in the safe mode default rendering, must have minimal markup.

#### Packaging

A theme is essentially a collection of files. In order to make the creation and deployment of themes as easy as possible, they should be packaged using the most common packaging format: zip. Packaging a theme should be as simple as right-clicking the folder and choosing "compress".

While Virtual Path Providers in theory would enable us to serve the contents inside the zip without physically unpacking it, this won't work in medium trust with .NET 3.5 SP1. This is fixed in 4.0 but we decided we would run on 3.5 SP1 to help adoption.
An alternative option is to unzip the package when it is uploaded, which can be done in medium trust and might be less confusing to users.

The zip file containing a theme contains at its root a single folder named like the theme that contains the theme files.

The name of the zip itself can include version information but the root folder inside it should not: Skyblue-1.0.1.zip/skyblue/.

What we should focus on is that a single entity such as a theme is kept entirely in a single location so that it can be easily found, modified or deleted.

#### Structure

The contents of a theme are images, stylesheets, pages, user controls and code. The files a theme can contain are:

* Theme.txt: the manifest of the theme, where the meta-data for the theme is defined. If the manifest file is missing from a theme or if it can't be read, the admin UI will display the theme disabled (this is debatable) with a warning message explaining the problem: "This theme is missing a valid theme.txt manifest file."
* Theme.png: the thumbnail that will appear in the theme galleries. This thumbnail should be relatively high resolution to enable JavaScript enhancements in the admin UI to show the higher resolution on hover. The high resolution thumbnail will be resized by the style of the img tag to a standard width when displayed in the list of themes.
* Site.css: this is where most of the styles for the theme are defined. To enable settings to be inserted dynamically, a theme might have a dynamic style section in the master page or the template pages, in addition to the static link to the stylesheet.
* Views/Templates/Default.aspx: this is the default layout template. It typically contains a main zone where the application will insert a partial view depending on the nature of the contents being displayed (list of posts or details of a post for the home page of a blog, details of a product, etc.).
* Images: a directory containing the images used by the theme.
* Scripts: a directory containing the client scripts used by the theme.

Other, more specialized views and partial views may be optionally included into a theme, following a naming convention as described in the next section.

A typical organization for the templates in a package, and the corresponding organization for theme overrides of the templates of the same package could look like this:

* Views
    * Admin
        * Blog
            * DisplayTemplates
            * EditorTemplates
        * BlogPost
            * DisplayTemplates
            * EditorTemplates
    * Blog
        * DisplayTemplates
        * EditorTemplates
    * BlogPost
        * DisplayTemplates
        * EditorTemplates

Optionally, a theme may also be localizable. For that purpose, it may contain a resources directory following the same resource definition convention as the rest of the site (TBD).

If a folder in the theme folder starts with a non-alphanumerical character, it is not seen as a theme.

The theme directory by default is called "themes" and is at the root of the application. A site-level setting could enable users to relocate that folder, if they want for example to shorten file paths.

#### View selection

> **Note**:This section is speculative and depends on future decisions on the extensibility model of the application.

The selection of the most specialized view is done dynamically and is delegated to a plug-in. A default plug-in is provided by the Orchard framework but that can be overridden or completed by plug-ins.

The plug-in has the following signature:
    
    string ResolveView(
         string viewName, Theme theme, ControllerContext context)


A view resolution plug-in should return null if it can't find a relevant view. If no plug-in exists or if all returned null, the framework will use default.aspx or default.ascx (depending on whether a full or partial view is necessary in the calling context). As soon as any enabled plug-in returns something other than null, empty string or "default", the framework stops the call loop and uses that value as the name of the physical view to use. This implies that the order in which plug-ins run may be important. This order can be determined from the plug-in admin UI.

The view name that is getting passed into the plug-in is typically just what the controller action asked for. The plug-in system allows for arbitrary flexibility in selecting a physical view from what the action is asking for, depending on any convention and keeping the end result within what the current theme is able to display.

The default view selection plug-in will try to find a view with \[viewName\]\.aspx as the name within the theme and return this if it is found. If not, it will assume that the view name is built using the following convention: `viewName = [ContentType]-[ItemSlug]`

The default view resolver will split the file name on the first dash character, will remove what comes after and try to find a physical view with that name.

Here's a possible implementation of the default view resolution plug-in:

    
    public string ResolveView(
        string viewName, Theme theme, ControllerContext context) {
        
        // look for the specific view in the theme.
        if (theme.HasView(viewName)) {
            return viewName;
        }
        else {
            // fallback to generic view in the theme.
            viewName = GetGenericView(viewName);
            if (viewName != null && theme.HasView(viewName)){
                    return viewName;
                }
            }
            // fallback to default view.
            return null;
        }
    }
    
    private static string GetGenericView(string viewName) {
        if (String.IsNullOrEmpty(viewName)) {
            return null;
        }
        int index = viewName.IndexOf("-");
        if (index == -1)
            return null;
        return viewName.Substring(0, index);
    }


Of course, implementing any other convention to resolve the controller action-provided view name to a physical view name is just a matter of implementing a plug-in.
 
In the example of displaying a blog post, one can see that the controller would ask for a view named for example "post-my-first-post". The default view resolver would ask the current theme for a view named "post-my-first-post". If it doesn't find it (which is quite likely), it will look for a view named "post". If the current theme has been built for the blog application, it will most likely have it and that's what will be used, otherwise the engine will ask other plug-ins and ultimately fall back to "default".

In the example of a commerce package, the controller could ask for "category-boots". The theme could contain that view but if it doesn't the default implementation will try to find "category" and then revert to default.

But we can also look at other patterns to resolve views.
For example, here's the code for a plug-in that implements the page branch of a resolution tree:

    
    public string ResolveView(
        string viewName, Theme theme, ControllerContext context) {
        
        if (viewName.StartsWith("page-") {
            var pageName = viewName.Substring(5);
            if (theme.HasView(pageName)) {
                return pageName;
            } else if (theme.HasView("page") {
                return "page";
            }
        }
        return null;
    }


One thing to note is that the application does not need in any case to have pre-determined knowledge of the content types. Those are just a matter of establishing a convention between a controller and its associated view resolution plug-in (if I there is one). This makes the theme engine very extensible while remaining simple for the end user and theme developer.

#### Localization

Localization of a theme can be done using the same conventions as in the application itself. Insertion of localized strings can be done using special helpers for resource strings (TBD).

#### Declaring meta-data

Meta-data about themes can be specified through a simple YAML manifest (Theme.txt). This enables an expressive declaration of the meta-data:

    
    Name: Pretty in pink
    Author: Bertrand Le Roy
    Description:
        This theme is full of butterflies, hearts
        and unicorns.
    Version: 1.0
    Tags: pink, butterfly, heart, unicorn, pony, rainbow
    Url: http://orchardproject.net/themegallery/prettyinpink
    Website: http://weblogs.asp.net/bleroy


These attributes are used in the admin tool to display rich details about the theme, and are also used to populate the description of themes in the online gallery.

It is possible to define custom meta-data attributes beyond those that are provided out of the box. 

Localization of the meta-data is not supported at this point. Our default themes will eventually provide an example of a localized theme description.

The license can be specified using a License meta-data property in the manifest.

The Orchard framework defines the following meta-data attributes out of the box:

* Name (the default value for this is the theme's type name, "uncameled")
* Author (can take a comma-separated list)
* Description
* Category
* Tags (comma-separated list)
* Version
* License
* Url (the URL where the latest version of the theme can be found)
* Website
* Settings (this is detailed in the next section)

#### Settings

Some themes can expose settings so that simple customization of a theme can be done without opening a text editor. Typically, a theme can expose settings for a color palette or a logo.

The way themes can expose settings in through the YAML meta-data manifest:

    
    Settings:
      - Palette:
        - Description: A dominant color for the theme.
        - Default: Pink
        - Editor: ColorEditor
      - Logo:
        - Description: The site's logo.
        - Default: images/logo.png
        - Editor: MediaPicker


The description for each setting can have a description and an editor hint. This tells the system how to build the admin UI to handle that setting by finding a partial view with the same name.

There is no type information associated with a setting because the intended audience for theme authoring shouldn't be required to understand such coding concepts. Instead, seen from the theme views, all theme settings are strings and can be injected easily.

It's the editor that is responsible for translating the value of a setting back and forth between the string representation and any internal representation it may need in order to provide a good editing experience. For example, a color setting would be represented in a "#RRGGBB" format that is immediately usable in HTML, but the editor would transform that representation into an instance of the Color type internally, and would surface color picker UI in the admin view to edit it. When it's done, it would persist the string representation back to the theme engine.

The editor is also responsible for validation of setting values.

Theme settings can be injected into a view using the Html.Theme helper (see [Theme Includes and Overrides](themes-includes)).

There is a set of setting values per theme so that switching to a new theme switches to a new set of values, and going back to the original theme restores the corresponding values.

Each setting can expose a default value in the meta-data.

#### Stylesheet overrides

Stylesheet overrides are a special kind of setting that enables more arbitrary customization of a theme even when the user doesn't have direct access to the theme directory's files.

Stylesheet overrides are a large string of CSS that can be set for each site. It is stored in the database like other theme settings but doesn't need to be declared explicitly by the theme's manifest. There is a set of overrides per theme so that switching to a new theme switches to a new set of overrides, and going back to the original theme restores the corresponding overrides.

The stylesheet overrides will be served by a special action. The views will include stylesheet overrides in the head of the page after the other stylesheets.

#### The themes directory

Each theme is found as a subdirectory under the "themes" subdirectory of the root of the application. The name of the theme's directory should be the same as the name of the class in theme.cs if there is one.

#### Stylesheet overrides

All themes should contain a call to a helper, `Html.IncludeRegisteredHeaders()`, right after the inclusion of the theme's stylesheet.aspx that can include database-bound CSS that is specific to the current tenant, as well as script and css that may be added dynamically by extensions such as widgets.

#### Setup

Themes can be uploaded (unzipped) through FTP into the themes directory of the application, and that is enough to set them up.
Alternatively, the zipped theme can be uploaded through the admin tool, which will unzip the file into the themes directory.
Finally, the theme can be chosen from the online catalog of themes that we will host on our servers and directly installed. Installing an online theme will directly transfer the zipped theme from our server to the application's server and then unzip it into the themes directory.

> **Note:** The online catalog scenario won't be immediately implemented as it is dependent on the existence of this catalog, which is not yet planned.

Themes can also be uninstalled. When the currently used theme is uninstalled, the site will revert to the "safe mode" built-in theme (no theme at all).

#### Themes and widgets

The design of themes will be coupled to the widget infrastructure. The widgets specification can be found here:

[Widgets](widgets)

# Permissions

Here, owner means the site owner.

Permission                                 | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
Change current theme                       | No    | No         | Yes   | Yes    | No     | No
Edit theme                                 | No    | No         | Yes   | Yes    | No     | No
Install and uninstall themes               | No    | No         | Yes   | Yes    | No     | No

Additional permissions may apply to local themes when they get implemented.

