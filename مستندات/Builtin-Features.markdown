There are lots of features available in Orchard out of the box, and many times more from
the [gallery][1]. This topic gives a brief description of each of Orchard's first-party
features.

The list is organized alphabetically by module name, within two main sections separating
core modules from non core modules. Core features cannot be disabled and are all enabled
at all times, but there are features that are implemented in core modules that can be
enabled and disabled. Those features are simply not in the "Core" category.

Each module details its features and whether it's available from the WebPI package or
only from the gallery or the source code releases.

# Core modules

## Common

The three core content parts Body, Common, and Identity, as well as the Text field, are
implemented by this core module.

The Body part represents a block of rich text. It is
configured by default to use HTML through TinyMCE, but can be adjusted to use plain text,
Markdown or any custom flavor.

The Common part captures the creation, modification and publication dates, as well as the
owner of the content item. The container item can also be found on this part, in order
to implement parent / child metaphors of hierarchies such as blog / post or folder / file.

The Identity part is useful to provide a unique identity to a content item that doesn't
have a natural one. For example, pages are naturally identified by their relative URL
within the site, or users by their user name, but widgets have no such natural identity.
In order to enable importing and exporting of those items, the identity part can be added.
It creates GUIDs that are used as a unique identity that can reliably be exchanged between
instances of Orchard.

The Text field is very similar to the Body part, except that it is a field rather than a part,
enabling the use of multiple instances on a single item. It also has some shorter flavors
such as a single-line box of unformatted text.

## Containers

This module introduces four parts that are useful to create simple hierarchies of contents.
It is the basis for the Orchard.Lists module and has become somewhat obsolete as Lists got
deprecated in favor of better content classification models such as taxonomies and better
querying mechanisms such as projections.

The Container part can be added to a type to mark its ability to contain certain types of
content items. It also has properties specifying sort order and pagination.

The Containable part specifies that a type can be contained. It works hand-in-hand with the
Container part and enables the content editor to choose a container for the item.

The Container Widget part is similar to the Container part, except that it is made to be used
in the container widget, and it has additional filtering capabilities in order to be able to
display only a selected subset of the contained items. It is also not a container in itself,
but rather references and re-uses an existing container item.

The custom properties part exposes three custom text properties that were useful to implement custom
filtering and ordering. This part is deprecated as projections now enable filtering and sorting
on fields.

## Contents

This core module creates the infrastructure for custom content types.

### Features

* Contents (Core): the infrastructure for custom types.
* Content Control Wrapper (off by default): adds en edit button on the front-end.

## Dashboard

Implements the administration dashboard as an extensible shell.

## Feeds

The Feeds core module provides the infrastructure that modules can use to expose RSS,
Atom or other types of feeds.

## Navigation

Since Orchard 1.5, the application ships with a hierarchical and extensible navigation menu.
More than one named menu can be built using this core module. Menu items can be provided
by any number of providers. The module ships with custom items that can point to any URL,
and content menu items that point to a specific content item.
Other modules, such as taxonomies or projections, can provide their own dynamic menu item providers.
Menus can be rendered as full hierarchical menu widgets, or as breadcrumb or local menus.
A content item can be added to menus using the Navigation part. The Menu part, that was
fulfilling this role before Orchard 1.5, is deprecated but still provided for back-compatibility
with the data from previous versions of Orchard.
This core module also provides the administration menu.

## Reports

The Reports core module sets-up the infrastructure to generate and display basic reports.
It is used during setup to log the various setup operations, including datbase operations.

## Scheduling

The APIs from this core module can be used by other modules such as Publish Later to schedule
operations to be executed in the future.

## Settings

Site-wide settings in Orchard are stored in a content item. The Site content type is what is used
for this, and as any content type in Orchard, it can be extended. This enables modules to contribute
their own settings. This module is what enables that scenario.

## Shapes

Shapes in Orchard are the basic units of UI from which all HTML is built. New shapes can of course
be added by modules dynamically, but this module provides some basic and standard shapes.

Core shapes are defined in code in CoreShapes.cs. Other shapes are defined in Views as cshtml files.
Any shape, core or otherwise, can be overridden by templates in a theme.

### Core shapes

* ActionLink: uses route values to construct a HTML link.
* DisplayTemplate, EditorTemplate: internally used to build the display and editor views of content items.
* Layout: this is the outermost shape, that together with its wrapper, Document, defines the basic HTML structure to be rendered. It also defines top-level zones.
* List: a standard shape to render lists of shapes.
* Menu, MenuItem, LocalMenu, LocalMenuItem and MenuItemLink: the shapes that navigation renders.
* Pager and associated shapes and alternates: the shapes used to render pagination.
* Partial: a shape that can be used to render a template as a partial view, using the specified model. Creating a dynamic shape is often a preferrable technique.
* Resource, HeadScripts, FootScripts, Metas, HeadLinks, StyleSheetLinks, Style: shapes used to render resources such as script tags or stylesheets.
* Zone: a special shape that is made to contain other shapes, typically but not always limited to widgets.

### Templated shapes

* Breadcrumb: a breadcrumb representation of a list of menu item links.
* ErrorPage and NotFound: the pages that are rendered in case of server error or 404 not found resource. These are fun ones to override in a theme.
* Header: the header of the page (not the head tag).
* Message: this shape is used to render information, warning or error messages.
* User: displays login, logout, dashboard and change password links.

## Title

This simple module introduces the Title part that is used by most content types.

## XmlRpc

The APIs necessary to create content such as pages and blog posts from applications such as
Windows Live Writer are implemented in this core module. The Orchard.Blogs module builds
on this module to enable specifically blog post creation.

# Non-core modules

## Markdown (WebPI, off by default)

[Markdown][2] is a human-readable text format used to describe rich text without the
complexity of HTML. Some people prefer to write in Markdown rather than in a WYSYWYG
text editor such as the default TinyMCE editor that comes with Orchard.

Once you've enabled the Markdown feature, you can create new content types or edit
the existing ones to use the Markdown format instead of HTML by opening the settings
for the Body part and changing the flavor setting from "html" to "markdown". The
Markdown editor will then be shown instead of TinyMCE in the content item editor.

## Orchard.Alias (WebPI)

The Alias module sets up the infrastructure to map friendly URLs to content items
and custom routes. It is the foundation on which Autoroute is built.

### Features

* Alias: this is the core infrastructure piece for aliases to work.
* Alias UI (off by default): provides admin UI to modify, create or remove aliases.

## Orchard.AntiSpam (WebPI, off by default)

The AntiSpam module provides various spam-fighting features and infrastructure
pieces. It makes it possible to prevent spam on arbitrary contents (previous
versions of Orchard only had anti-spam services on comments). With this module,
you can add captcha, external spam-filtering or submission limits simply by adding
a few parts to your types, including custom forms.

### Features

* Anti-Spam: the core infrastructure pieces for anti-spam. Also provides the [ReCaptcha][3] part that can be added to content types to add CAPTCHA to its edit form.
* Akismet Anti-Spam Filter: enables the use of the third-party [Akismet][4] service with Orchard content types.
* TypePad Anti-Spam Filter: enables the use of the third-party [TypePad][5] service with Orchard content types.

## Orchard.ArchiveLater

Using the part provided by this module, you can schedule a content item to be archived.

This module is available from source code packages or [from the gallery][28].

## Orchard.Autoroute (WebPI)

This very powerful feature makes it possible for content type creators to specify a
token-based URL blueprint. For example, if you want the URL of your blog posts
to be of the form posts/2012/7/the-best-post-you-ll-ever-read, you can go to the
content type editor for blog posts, deploy the settings for the Autoroute part and
set the pattern to "posts/{Content.Date.Format:yyyy}/{Content.Date.Format:MM}/{Content.Slug}".

Autoroute is built on top of the Alias feature.

## Orchard.Blogs (WebPI)

The blogs module provides Orchard's blogging features. It relies heavily on Orchard's
content type composition and other features such as comments.

### See Also

* [Adding a blog to your site][6]
* [Blogging with Live Writer][7]

## Orchard.CodeGeneration

This module provides developers with scaffolding commands that help with the creation
of new modules and themes.

This module is available from source code packages or [from the gallery][29].

## Orchard.Comments (WebPI)

You can use the Comments part provided by this module on any content type, in order
to enable users of your site to provide feedback.

### See Also

* [Moderating comments][8]

## Orchard.ContentPermissions (WebPI, off by default)

Without this module, Orchard only provides configurable permissions for whole content types.
This module provides a part that can be added to any content type to restrict viewing
permissions per content item instead of per content type.

## Orchard.ContentPicker

This module provides an extensible content item picker that can be used to build
relationships between content items.

This module is available from source code packages or [from the gallery][30].

## Orchard.ContentTypes (WebPI, off by default)

Enable this module to enable the creation and modification of content types from the admin UI.

### See Also

* [Creating custom content types][9]

## Orchard.CustomForms (WebPI, off by default)

Custom forms are built as content types, typically using fields. Once you've built the content
type for your custom form, you can enable its instances to be created from the front-end by
anonymous users.

This is useful, for example, to create contact forms: enable the feature, create a "Contact Form"
content type, add name, e-mail and message text fields (select TextArea as the display option in the
field's settings), click on "Forms" in the admin menu, click "Add a new  Custom Form", 
select "Contact Us" as the content type for the form and publish. If you enable the Rules feature,
you can then create a rule that sends an e-mail when an item of the "Contact Us" type is
published. You should also grant the "Submit Contact Form" permission to the anonymous role
from the Users/Roles admin screen under "Custom Forms" in order to allow anonymous users to post contact forms.

## Orchard.DesignerTools

This module contains a few features that help with the development of themes.

### Features

* Shape Tracing: provides a Firebug-like tool that can be used to explore the server-side shape structure of the page, generate alternates, and inspect the model, placement and templates for any shape.
* URL Alternates: adds alternates for all shapes based on the current URL, of the form "someshape-url-thecurrenturl" or "someshape-url-homepage".
* Widget Alternates: adds alternates for specific widgets and layers.

### See Also:

* [Customizing Orchard using designer helper tools][31]

This module is available from source code packages or [from the gallery][32].

## Orchard.Email

This module implements an email messaging channel that can be used for example to send
email notifications from rules.

This module is available from source code packages or [from the gallery][38].

## Orchard.Fields (WebPI)

Orchard.Fields provides Input, Boolean, DateTime, Numeric, Link, Enumeration, and Media Picker fields
that can be used in custom content types.

## Orchard.Forms (WebPI)

This developer-targeted module provides shapes that are useful to dynamically build forms from code.

This module is used as a dependency by Projector and Rules.

## Orchard.ImportExport

The definition for content types, as well as the content itself, can be exported from one Orchard
instance, and imported into another using this module. The format that is used for the transfer
is the same XML format that is used in recipes.

This module is available from source code packages or [from the gallery][33].

## Orchard.Indexing, Orchard.Search and Lucene

Those three modules constitute the default full-text search infrastructure for Orchard.
The indexing module populates the index from content items. The Lucene module provides
the specific index implementation that indexing populates and that search queries.
The search index queries the index and formats results.

This module is available from source code packages or from the gallery: [search][34],
[indexing][35] and [Lucene][36].

## Orchard.jQuery (WebPI)

Used as a dependency by other modules, this provides jQuery and jQueryUI scripts.

## Orchard.Lists (deprecated)

This module provides a simple implementation for lists of content items, following
a folder/file metaphor where a content item can belong to only one list.

This module is deprecated and we recommend users switch to Taxonomies and Projections,
which enable much richer scenarios.

## Orchard.Localization

This module provides a part that can be added to a content type to make it localizable.
The items of the modified types can have several versions that differ by culture.

This module is available from source code packages or [from the gallery][37].

## Orchard.Media (WebPI)

Orchard.Media manages the contents of the /media folder.

### See Also

* [Adding and managing media content][10]

## Orchard.MediaPicker (WebPI)

MediaPicker adds the media picker to the content body editor.

## Orchard.Messaging

This module provides the messaging infrastructure that module such as Rules can
use. It is only useful as a dependency for other modules that implement
specific channels, such as e-mail or Twitter.

This module is available from source code packages or [from the gallery][39].

## Orchard.Modules (WebPI)

This is the module that provides the admin UI to enable and disable features.

### See Also

* [Installing and upgrading modules][11]

## Orchard.MultiTenancy

Hosting multiple Orchard sites on separate applications means duplicating everything
for each site. The multi-tenancy module enables the hosting of multiple Orchard sites
within a single IIS application, thus saving a lot of resources, and reducing maintenance
costs. Each site's data is strictly segregated from the others through a table prefix
or complete database separation.

### See Also

* [Setting up a multi-tenant Orchard site][40]

This module is available from source code packages or [from the gallery][41].

## Orchard.Packaging (WebPI)

This module handles the packaging of themes and modules.

### Features

* Packaging commands: core services and command-line commands to package and install modules.
* Gallery: integrates the [gallery][1] into Orchard.
* Package Updates: enables module updates from the admin dashboard.

### See Also

* [Installing modules and themes from the gallery][12]

## Orchard.Pages (WebPI)

The Pages modules adds the Page content type, and associated commands.

### See Also

* [Adding pages to your site][13]

## Orchard.Projections (WebPI)

This tremendously useful module enables the creation of arbitrary queries over
the contents of the site, and then to present the results in flexible layouts,
without leaving the admin dashboard.

### See Also

* [Presentation video on Projections][14]

## Orchard.PublishLater (WebPI, off by default)

The PublishLater part can be added to draftable content types and allows scheduled
publication of contents.

### See Also

* [Saving, scheduling and publishing drafts][15]

## Orchard.Recipes (WebPI)

Recipes are XML files that describe a set of operations on the contents and configuration
of the site. Recipes are used at setup to describe predefined initial configurations
(Orchard comes with default, blog and core recipes). They can also be included with
modules to specify additional operations that get executed after installation.
Finally, the import/export feature uses this same recipe format to transfer contents.

### See Also

* [Making a web site recipe][16]

## Orchard.Roles (WebPI)

Security APIs in Orchard do not make many presuppositions about authentication, membership
and permissions, but we do ship role-based security as a default security implementation.
Users can belong to one or many groups, and permissions are granted to groups rather than
users.

### See Also

* [Managing users and roles][17]
* [Understanding permissions][18]

## Orchard.Rules (WebPI, off by default)

Orchard events can be picked up by rules and trigger actions. For example, the publication
event on the comment content type can be picked-up by a user-defined rule and trigger
the action of sending an e-mail to the owner of the blog.
The Rules module provides simple admin UI to create and manage rules.

## Orchard.Scripting (WebPI)

In order to enable simple programmability of the application without requiring the
development of a whole module, certain key areas of Orchard expose extensibility through
scripting. For example, widget layer visibility is defined by rules that are written
as simple script expressions. The scripting infrastructure is language-agnostic, and
new languages could be added by a module. Orchard comes with one implementation that
is a simple expression language whose syntax is a subset of Ruby.

### Features

* Scripting: the scripting infrastructure.
* Lightweight Scripting: a simple expression language that is a subset of Ruby.
* Scripting Rules: makes it possible for rules to be triggered by arbitrary scripted expressions.

## Orchard.Scripting.DLR

This module, built on Orchard.Scripting, enables the possibility to use DLR languages
such as Ruby and Python as scripting languages.

## Orchard.Setup (WebPI, off after setup)

This module is always disabled except before the application has been setup. It is responsible
for implementing the setup mechanism. It contains the original recipes in its Recipes subfolder.

### See Also

* [Installing Orchard][20]
* [Making a web site recipe][16]

## Orchard.Tags (WebPI)

Tags are a very simple way to categorize contents. It is a flat and easily extensible structure.
For more elaborate classifications, we strongly recommend the use of the [Contrib.Taxonomies][21]
module.

### See Also

* [Organizing content with tags][22]

## Orchard.TaskLease

In web farm environments, it's often useful to send messages across all servers in the farm. This
module implements a way for code to communicate tasks to the whole server farm.

This module is available from source code packages or [from the gallery][42].

## Orchard.Themes (WebPI)

This module provides the infrastructure for easy customization of the look and feel of the site
through the definition of themes, which are a set of scripts, stylesheets and template overrides.

### See Also

* [Installing themes][23]
* [Previewing and applying a theme][24]
* [Customizing the default theme][25]

## Orchard.Tokens (WebPI, off by default)

Tokens are contextual environment variables that are used in dynamic expressions. For example,
the Autoroute feature makes it possible to define URL patterns for content items of a given
type. Those patterns rely on tokens that will be dynamically evaluated in a specific context.
The "{Content.Date.Format:yyyy}/{Content.Slug}" would be evaluated for the specific content item
it applies to and would be resolved to something like "2012/the-title".

## Orchard.Users (WebPI)

This is the module that implements the default user management in Orchard.

### See Also

* [Managing users and roles][17]

## Orchard.Warmup (WebPI, off by default)

Cold starts in ASP.NET applications can be slow, and shared hosting environments create the
conditions for frequent such cold starts. In order to mitigate this situation, the warmup
feature can prepare static versions of the most common pages of the site so those can be served
as soon as possible even if the application is not entirely done warming up.

## Orchard.Widgets (WebPI)

Widgets are reusable pieces of UI that can be positioned on any page of the site. Which widgets
get displayed on what pages is determined by layer rules.

### Features

* Widgets: the core widget feature and admin UI.
* Page Layer Hinting: adds a message when publishing a new page that prompts the user to create a new layer for that page.
* Widget Control Wrapper: Adds an edit button on the front-end for easier modification.

### See Also

* [Managing widgets][26]
* [Writing a widget][27]

## TinyMCE (WebPI)

Used as a dependency by other features, this provides the scripts necessary to implement the TinyMCE WYSYWYG HTML editor.

## UpgradeTo15 / UpgradeTo14 (WebPI, off by default)

Orchard 1.4 brought breaking changes in the way URLs and titles are managed. 1.3 and previous versions
were using the Route part to handle a static URL and title. 1.4 deprecated this in favor of the new
alias, autoroute and title part. The upgrade module contains special scripts that upgrade old content
to the new way of doing things.
Orchard 1.4 also introduced new field types (see Orchard.Fields), and because some users may have
used equivalent Contrib.* fields from gallery modules, the upgrade module provides an upgrade path
to the new fields.

  [1]: http://gallery.orchardproject.net
  [2]: http://daringfireball.net/projects/markdown/
  [3]: http://www.google.com/recaptcha
  [4]: http://akismet.com/
  [5]: http://antispam.typepad.com/
  [6]: http://docs.orchardproject.net/Documentation/Adding-a-Blog-to-Your-Site
  [7]: http://docs.orchardproject.net/Documentation/Blogging-with-LiveWriter
  [8]: http://docs.orchardproject.net/Documentation/Moderating-comments
  [9]: http://docs.orchardproject.net/Documentation/Creating-custom-content-types
  [10]: http://docs.orchardproject.net/Documentation/Adding-and-managing-media-content
  [11]: http://docs.orchardproject.net/Documentation/Installing-and-upgrading-modules
  [12]: http://docs.orchardproject.net/Documentation/Installing-modules-and-themes-from-the-gallery
  [13]: http://docs.orchardproject.net/Documentation/Adding-Pages-to-Your-Site
  [14]: http://www.youtube.com/watch?feature=player_embedded&v=SP912eWoOoo
  [15]: http://docs.orchardproject.net/Documentation/Saving-scheduling-and-publishing-drafts
  [16]: http://docs.orchardproject.net/Documentation/Making-a-Web-Site-Recipe
  [17]: http://docs.orchardproject.net/Documentation/Managing-users-and-roles
  [18]: http://docs.orchardproject.net/Documentation/Understanding-permissions
  [20]: http://docs.orchardproject.net/Documentation/Installing-Orchard
  [21]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Contrib.Taxonomies
  [22]: http://docs.orchardproject.net/Documentation/Organizing-content-with-tags
  [23]: http://docs.orchardproject.net/Documentation/Installing-themes
  [24]: http://docs.orchardproject.net/Documentation/Previewing-and-applying-a-theme
  [25]: http://docs.orchardproject.net/Documentation/Customizing-the-default-theme
  [26]: http://docs.orchardproject.net/Documentation/Managing-widgets
  [27]: http://docs.orchardproject.net/Documentation/Writing-a-widget
  [28]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.ArchiveLater
  [29]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.CodeGeneration
  [30]: http://gallery.orchardproject.net
  [31]: http://docs.orchardproject.net/Documentation/Customizing-Orchard-using-Designer-Helper-Tools
  [32]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.DesignerTools
  [33]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.ImportExport
  [34]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.Search
  [35]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.Indexing
  [36]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Lucene
  [37]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.Localization
  [38]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.Email
  [39]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.Messaging
  [40]: http://docs.orchardproject.net/Documentation/Setting-up-a-multi-tenant-Orchard-site
  [41]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.MultiTenancy
  [42]: http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.TaskLease
