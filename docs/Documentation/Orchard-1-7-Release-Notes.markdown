Build: 1.7

Published: 7/17/2013

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.7.zip file.

<http://docs.orchardproject.net/Documentation/Manually-installing-Orchard-zip-file>

The zip contents are pre-built and ready-to-run. Simply extract the contents of the Orchard
folder from the zip contents to an IIS virtual directory (or site root) and then point your
browser to the site. You can also just extract to a local folder and open the Orchard
folder in Visual Studio or WebMatrix as a web site (but not as a web application).
Please make sure you have a machine key
<http://docs.orchardproject.net/Documentation/Setting-up-a-machine-key>
or you may experience frequent disconnections.

What file to download?
----------------------

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.7.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
Orchard.Source.1.7.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.7. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.7 fixes bugs and introduces the following features:

* *Clay*: This version doesn't use Clay anymore and improves memory and raw performance.
* Better performance for the event bus.
* Better performance for the Import/Export module.
* *Search*: Possibility to create multiple search indexes.
* *Module recipes*: In the Modules page, a new Recipes tab lets you run custom recipes to automate tedious tasks.
* *Tokens*: A new tokens syntax is added on top of the current one. The preferred syntax is now `#{token}`.
* *Shape Menu Items*: You can create menu items which will be rendered using shapes.
* *Comments*: The whole comments module has been rewritten to provide a more Orchard friendly implementation, and also
provides an option for threaded comments.
* *Anti Spam*: The anti spam module has been updated to be reusable by any module, and also provides custom Content Parts 
for reCaptcha, spam filters and submission limits.
* *Media Library*: This new module lets you manage Media as content items and also import any media from external services.
* *Image Editor*: Provides a web based image editor for cropping, resizing and applying filters to raw images.
* *Media Processing*: Can create custom image filters and resize image automatically.
* *Workflows*: This new module lets you create content workflows and long running workflows.
* *C# Scripting*: Provides an execution environment for custom C# code in content item validation and in Workflows.
* *Orchard.Taxonomies*: This is the Contrib.Taxonomies module integrated into Core.
* *Orchard.OutputCache*: This is the Contrib.Cache module integrated into Core.

The full list of more than 280 fixed bugs for this release can be found here:

* [Bugs fixed in 1.7](https://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Resolved|Closed&type=All&priority=All&release=Orchard%201.7&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.3 and earlier

Orchard 1.4 introduced breaking changes in the way content URLs are managed. Because of that,
and if you're migrating from version 1.3 or earlier, the Upgrade module can be used to migrate
data. If you upgrade a site to 1.7 from 1.3 or earlier and can't
see your contents, you probably need to run this module. In order to do that, go to the admin
section of the site (by appending /admin to the URL where the home page should be), then go
to Modules and enable the feature.

The feature, once enabled, adds a new entry to the admin menu: "Upgrade to 1.7", that can
migrate the Route data of your content items as well as field data from older field modules, and menu items.

### Upgrading from Orchard 1.6 and earlier

* Enable the Upgrade module

#### Migrating Content Item Picker Field contents

In Orchard 1.7 this field has been moved to a more appropriate module, and thus needs it definitions to be migrated
in order to reflect this change.

* Click on Upgrade To 1.7 from the menu
* Select the Content Picker tab and click **Migrate**

#### Migrating Contrib.Taxonomies module

In Orchard 1.7 the Contrib.Taxonomies module has been integrated into the core modules as the Orchard.Taxonomies module.
If you want to use the new module then you need to follow these steps. It will convert all your content and metadata
which were associated with Contrib.Taxonomies.

* Disable the module Contrib.Taxonomies
* Enable the module Orchard.Taxonomies
* Click on Upgrade To 1.7 from the menu
* Select the Taxonomies tab and click **Migrate**
* Finally, update any template which was previously using the Contrib.Taxonomies templates

#### Importing Media files into the Media Library

In Orchard 1.7 a new media management module is provided. In order to use it you will have to import all your media files
to this new module. It will create a dedicated content item for each of your files. Ultimately it will also convert
all the current usage of Media Picker Fields to the new Media Library Picker Field.

* Disable the module Media
* Enable the module Media Library
* Click on Upgrade To 1.7 from the menu
* Select the Media Library tab and click **Migrate**
* In the Media Picker Field section click **Migrate**
* Finally, update any template which was previously using the Media Picker Field directly

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:


- Andrew Connell ([andrewconnell](http://www.codeplex.com/site/users/view/andrewconnell))
- Antoine Griffard ([agriffard](http://www.codeplex.com/site/users/view/agriffard))
- Benedek Farkas ([nightwolf226](https://www.codeplex.com/site/users/view/nightwolf226))
- Bertrand Le Roy ([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy))
- Damien Clarke ([damoclarke](http://www.codeplex.com/site/users/view/damoclarke))
- Jacky Hsu ([twomeetings](http://www.codeplex.com/site/users/view/twomeetings))
- Jasper Dunker ([jasperd](http://www.codeplex.com/site/users/view/jasperd))
- Jeff Bullock ([j3ffb](http://www.codeplex.com/site/users/view/j3ffb))
- Jorge Gamba ([jorgegamba](http://www.codeplex.com/site/users/view/jorgegamba))
- ([Jimasp](http://www.codeplex.com/site/users/view/Jimasp))
- Kees Schouten ([Znowman](http://www.codeplex.com/site/users/view/Znowman))
- Ken Wilkinson ([wilk](http://www.codeplex.com/site/users/view/wilk))
- Matt Melling ([kobowi](http://www.codeplex.com/site/users/view/kobowi))
- Michael Petrinolis ([Redbyron](http://www.codeplex.com/site/users/view/Redbyron))
- Mirza Dervišević ([Mirza](http://www.codeplex.com/site/users/view/Mirza))
- Nicholas Mayne ([Jetski5822](http://www.codeplex.com/site/users/view/Jetski5822))
- Piotr Szmyd ([pszmyd](https://www.codeplex.com/site/users/view/pszmyd))
- Rafael Medeiros ([rafaelmedeiros](http://www.codeplex.com/site/users/view/rafaelmedeiros))
- Sebastien Ros ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros))
- Sergey Romanchuk ([Rezet](http://www.codeplex.com/site/users/view/Rezet))
- Sipke Schoorstra ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker))
- Stanley Goldman ([StanleyGoldman](http://www.codeplex.com/site/users/view/StanleyGoldman))
- Travis James ([GQAdonis](http://www.codeplex.com/site/users/view/GQAdonis))
- Zoltán Lehóczky ([Piedone](http://www.codeplex.com/site/users/view/Piedone))
