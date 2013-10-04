In the near term, we'll be focused on servicing the V1 release and planning for the next version.
The feature roadmap is subject to change as the project evolves, and we welcome your input.

### Current Priorities

Priorities for Orchard 1.8:

This release is expected to be released for November 2013

* Migration to Microsoft .NET 4.5 (on track)
  * Upgrade project targets
  * Remove unnecessary Medium Trust support code
  * Define 4.5 framework in web.config files
  * Erik ([erik_oppedijk](https://www.codeplex.com/site/users/view/erik_oppedijk)) owns this contribution
* Upgrade ASP.NET Web Stack to newest versions (not started)
  * ASP.NET MVC5
  * WebAPI 2
  * Razor 3
  * Identity
* Put back the List module with improved functionnalities
  * The goal is to be able to use it to mimick the Blogs module (on track)
  * Sipke ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker)) owns this contribution
* Performance improvements by unleashing the power of the document db architecture built in Orchard (started)
  * Sebastien ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros)) owns this contribution
* Integrate OWIN middlewares suppport (started)
* Improved
  * Search support (on track)
  * Custom media types support (on track)
  * Media updates (started) 
* Improved Wrofklow module (on track)
  * Error/Exception branches support
  * Loop activities
  * Piotr ([pszmyd](https://www.codeplex.com/site/users/view/pszmyd)) owns this contribution

Priorities for Orchard 1.7.2

This release might not be necessary if 1.8 is progressing fast enough.

* New SSL module integrated into Core
  * Bertrand ([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy)) owns this contribution
* Bug fixes

### Currently Implemented (Partially or in Full)

* Basic admin panel and login
* CMS page creation and management
* Content zones within pages
* Content - Different content types/metadata, viewers and editors for content 
* Content editing and publication (drafts, scheduling, preview)
* Extensibility - Initial content type and composability infrastructure (based on MVC areas)
* Media management (support for any media type, extensibility, thumbnails, online image editor)
* Users, roles, membership and profile data (Users/Roles/Permissions, Mgmt)
* XML-RPC (Live Writer, MetaWebBlog) support for blogs
* Basic blog (create and manage blogs and posts, RSS/Atom, draft/publish, archives)
* Comments - Associate comments with content types, manage comments, spam protection
* Tags - Associate tags with content types, browse by tag
* Settings - App-level, extension-level settings definition and UI/management
* Themes - Theming model, UI to install/remove themes, preview themes
* Setup
* Simple navigation
* Multi-tenancy
* Azure support (Blob Storage, Cache, Database Cache)
* Command-line tooling
* Event model (a.k.a. plugins)
* App Localization (of admin panel, modules, themes)
* Content Localization (multi-lingual sites)
* Search and Indexing (with search API)
* Module extensibility API and packaging
* Scaffolding of Modules (cmd-line)
* Creation of arbitrary content types and items - fields, parts
* Define content types, parts, and fields using the admin panel or code
* Add fields to content types using the admin panel or code
* Associate content parts to types using the admin panel or code
* Add fields or parts to existing content types using the admin panel or code
* Command-line support (bin/orchard.exe)
* Enabling features of modules
* Data migrations on module activation/upgrade
* Reporting (event logs)
* Search (based on Lucene)
* Module packaging
* Dynamic compilation of modules
* Theme re-foundation: Razor integration, Page Object Model, naming conventions and helpers
* Script and stylesheet registration
* Theme packaging
* Content item lists
* Medium trust
* Email notifications
* Widgets - Admin UI and management for widgets, widget groups, mapping to zones
* Marketplace - Ability to browse/install extensions from online gallery
* Editor-integrated media picker
* Setup recipes
* Module Recipes
* Import/Export
* Tokens
* Rules
* Forms API
* [Autoroute](http://orchard.codeplex.com/discussions/274916)
* [Projector](http://orchard.codeplex.com/discussions/274915)
* [Core Field Types](http://orchard.codeplex.com/discussions/274918)
* [Admin placement](http://orchard.codeplex.com/discussions/348649)
* [Spam Protection](http://orchard.codeplex.com/discussions/348654)
* NHibernate 3 and 2nd level caching
* ASP.NET MVC 4 / WebAPI
* MySQL provider
* Workflows
* Output cache
* Tokens
* Custom forms
* Content permissions

### Areas of Focus for Future Iterations (Backlog, Not in Priority Order)

* Multiple templates for pages
* SEO - Semantic URLs, metas/keywords, Web standards, sitemap
* Navigation - Navigation management, front-end UI (menus, breadcrumbs)
* Admin - UI improvements, dashboard, notifications/email
* Profiles - User profiles, avatars, reputation system
* Themes - Additional themes improvements (in-browser editing, etc)
* Performance - Caching, optimization, script combining/minification
* Analytics - Reporting, site-use statistics
* Mobile - Support for management, moderation, publishing from mobile device
* Audit Trail
* Other Domain-specific packages - Commerce, Wiki, Forums, Ads, etc
