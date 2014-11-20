Build: 1.5.1

Published: 7/18/2012

Updated for version 1.5.1: 7/20/2012

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.5.1.zip file.

<http://docs.orchardproject.net/Documentation/Manually-installing-Orchard-zip-file>

The zip contents are pre-built and ready-to-run. Simply extract the contents of the Orchard
folder from the zip contents to an IIS virtual directory (or site root) and then point your
browser to the site. You can also just extract to a local folder and open the Orchard
folder in Visual Studio or WebMatrix as a web site.
Please make sure you have a machine key
<http://docs.orchardproject.net/Documentation/Setting-up-a-machine-key>
or you may experience frequent disconnections.

What file to download?
----------------------

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.5.1.zip
is what you want to use, preferably through the WebPI instructions.

If you want to take a look at the source code, OrchardSource.1.5.1.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.5.1. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.5.1 fixes bugs and introduces the following features:

* *Admin Search:* Enables search from the content screen of the admin dashboard.
* *Admin-based Placement:* the editor placement of parts and fields can now be overridden from
the content type editor.
* *AntiSpam:* The AntiSpam module provides various spam-fighting features and infrastructure pieces.
It makes it possible to prevent spam on arbitrary contents (previous versions of Orchard only had
anti-spam services on comments). With this module, you can add ReCaptcha, external spam-filtering using
the Akismet or TypePad external services or submission limits simply by adding a few parts to your types,
including custom forms.
* *Content Permissions:*  This module provides a part that can be added to any content type to restrict
viewing permissions per content item instead of per content type.
* *Content Picker:* This module provides an extensible content item picker that can be used to build
relationships between content items.
* *Custom Forms:* Custom forms are built as content types, typically using fields. Once you've built
the content type for your custom form, you can enable its instances to be created from the front-end
by anonymous users. This is useful, for example, to create contact forms.
* *Navigation:* The navigation module now supports hierarchical menus and breadcrumbs. The navigation
system is also now pluggable. Existing applications should replace the Menu part with the new Navigation
part.
* *Layout placement*: `Placement.info` files can now use the '/' character to specify Layout zone targets likes this: "/AsideSecond:10"

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.5](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed%7cClosed&type=All&priority=All&release=Orchard%2b1.5&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).
* [Bugs fixed in 1.5.1](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed%7cClosed&type=All&priority=All&release=Orchard%2b1.5.1&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Navigation module

You will need to enable the Content Picker feature before you can edit the navigation.

- In Dashboard -> Modules, search for Content Picker and enable it

In Orchard 1.5.1 the navigation is no more injected automatically in the Navigation zone. 
Because of this change you will need to add a widget to render the main menu.

- In Dashboard -> Navigation, search for the Navigation zone and click Add
- Select Menu Widget
- In Title type "Main Menu"
- Uncheck the "Show title" checkbox
- In Menu select "Main Menu"
- Click the Save button

### Upgrading from Orchard 1.3 and earlier

Orchard 1.4 introduced breaking changes in the way content URLs are managed. Because of that,
and if you're migrating from version 1.3 or earlier, the UpgradeTo15 module can be used to migrate
data. If you upgrade a site to 1.5.1 from 1.3 or earlier and can't
see your contents, you probably need to run this module. In order to do that, go to the admin
section of the site (by appending /admin to the URL where the home page should be), then go
to Modules and enable the feature.

The feature, once enabled, adds a new entry to the admin menu: "Migrate to 1.5", that can
migrate the Route data of your content items as well as field data from older field modules.

See [Orchard 1.4 release notes](/Documentation/Orchard-1-4-Release-Notes) for more details.

How to Reset Your Site Data
---------------------------

The App_Data directory contains database and settings documents produced during setup.  
The contents of this directory are protected from download by visitors to your site. 

*To completely reset your site* (destroy all data, starting from the setup screen again), 
you can delete the contents of this directory.  This action is irreversible so backup first!


For other known issues, please refer to <http://orchard.codeplex.com/workitem/list/basic>.

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:


* Benedek Farkas (nightwolf226)
* Bertrand Le Roy (bertrandleroy)
* Martin Skinner (filetek)
* Geert Doornbos (geertdoornbos)
* Jonas Ledel (JLedel)
* John Murdoch (jrmurdoch)
* Nicholas Mayne (Jetski5822)
* Piotr Szmyd (pszmyd)
* Sebastien Ros (sebastienros)
* Sean Farrow (SeanFarrow)
* Thomas Bolon (styx31)
* Zoltán Lehóczky (piedone)