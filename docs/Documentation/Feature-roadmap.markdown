In the near term, we'll be focused on servicing the V1 release and planning for the next version.
The feature roadmap is subject to change as the project evolves, and we welcome your input.

### Current Priorities

#### Priorities for Orchard 1.11:

This release is expected for Q4 2016

## Suggested features

### On-track

* Deployment feature (OneStop will integrate this feature)
* New admin theme ([Szymon](https://github.com/SzymonSel) owns this contribution) 
  * Customizable dashboard
  * Accessibility
* Glimpse ([Chris](https://github.com/paynecrl97) owns this contribution) 
* Improved Workflow module
  * Error/Exception branches support
  * Loop activities
  * Piotr ([pszmyd](https://www.codeplex.com/site/users/view/pszmyd)) owns this contribution
* New base theme ([Daniel](https://github.com/DanielStolt) and [Ryan](https://github.com/ryandrewburnett) own this contribution) 
* Remove Cloud Services as a supported target ([Daniel](https://github.com/DanielStolt) owns this contribution)

### Looking for owners
* New front facing website
* Owin identity providers
  * OAuth, AAD ...
* Javascript integration
  * Rules engine
  * Script activity
  * Jint
* Content tree

* REST APIs ([design notes](https://orchard.codeplex.com/discussions/560607))
* Refactor output cache module as an Owin middleware

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
* [Projections](http://orchard.codeplex.com/discussions/274915)
* [Core Field Types](http://orchard.codeplex.com/discussions/274918)
* [Admin placement](http://orchard.codeplex.com/discussions/348649)
* [Spam Protection](http://orchard.codeplex.com/discussions/348654)
* NHibernate 3 and 2nd level caching
* ASP.NET MVC 5 / WebAPI
* MySQL provider
* Workflows
* Output cache
* Tokens
* Custom forms
* Content permissions
* SSL
* .NET 4.5 support
* Lists
* Timezones and Calendars
* Jobs Queue
* Templates management 
* Business data caching 
* Configurable dashboard

### Areas of Focus for Future Iterations (Backlog, Not in Priority Order)

* REST APIs ([design notes](https://orchard.codeplex.com/discussions/560607))
* Deployment module ([design notes](https://orchard.codeplex.com/discussions/452000))
* Improved content navigation and filtering
* SEO - Semantic URLs, metas/keywords, Web standards, sitemap
* Admin - UI improvements, dashboard, notifications/email
  * Improved admin theme (Based on Bootstrap)
* Profiles - User profiles, avatars, reputation system, using the dynamic forms module
* Themes - Additional themes improvements (in-browser editing, etc)
* Performance - Caching, optimization, script combining/minification
* Analytics - Reporting, site-use statistics
* Mobile - Support for management, moderation, publishing from mobile device
* Other Domain-specific packages - Wiki, Ads, etc
* Forums 
* Commerce
