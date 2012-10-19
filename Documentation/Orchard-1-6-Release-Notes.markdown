Build: 1.6RC

Published: 10/18/2012

How to Install Orchard 1.6 RC
-----------------------------

This release candidate is only provided for testing purposes.
It is only being provided in source code form.
Simply extract the contents of the archive, then compile src\Orchard.sln from Visual Studio.
To run the application, hit CTRL+F5 from Visual Studio.

Please make sure you have a machine key
<http://docs.orchardproject.net/Documentation/Setting-up-a-machine-key>
or you may experience frequent disconnections.

Who should use this software?
-----------------------------

This software is in version 1.6RC. The code is in pre-release state and only provided for
testing purposes. The final 1.6 version will be available soon, but in the meantime we recommend
only the deployment of 1.5.1 to production.

The RC is a great way to test and prepare your existing sites for the 1.6 migration.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.6RC fixes bugs and introduces the following features:

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

The full list of more than 200 fixed bugs for this release can be found here:

* [Bugs fixed in 1.6RC](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.6&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.3 and earlier

Orchard 1.4 introduced breaking changes in the way content URLs are managed. Because of that,
and if you're migrating from version 1.3 or earlier, the UpgradeTo15 module can be used to migrate
data. If you upgrade a site to 1.6RC from 1.3 or earlier and can't
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