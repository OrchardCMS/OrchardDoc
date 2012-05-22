Build: 1.4.2

Published: 2/29/2012

Updated 5/4/2012 for version 1.4.1

Updated 5/21/2012 for version 1.4.2

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions: <http://docs.orchardproject.net/Documentation/Installing-Orchard>. Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.4.2.zip file.

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.4.2.zip
is what you want to use, preferably through the WebPI instructions.

If you want to take a look at the source code, OrchardSource.1.4.2.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.4.2. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

Compatibility with ASP.NET WebPages and ASP.NET MVC
---------------------------------------------------

The 1.4.2 release of Orchard is only compatible with ASP.NET MVC 3.
If you have installed WebMatrix Betas or RCs, you need to uninstall them from the
machine where you run Orchard.

Note: if you don't have ASP.NET MVC or WebMatrix installed, you are fine and you don't
need to install them first as Orchard will then use its own copy.

What's new?
-----------

Orchard 1.4.2 fixes bugs, improves performance and introduces the following features:

* *Autoroute:* Set-up token-based patterns for your URLs.
  David Hayden has a good post describing the feature: 
  <http://www.davidhayden.me/blog/autoroute-custom-patterns-and-route-regeneration-in-orchard-1.4>
* *Projector:* Create arbitrary queries on your site contents, then display the results in projection pages and widgets.
* *Fields:* Orchard now comes with new field types for Boolean, Date/Time, Enumeration, HTML5 Input,
  Links, Media Picker and Numeric. The text field has a new setting for the flavor which adds
  html, markdown and textarea to the default text box.

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.4](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.4&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).
* [Bugs fixed in 1.4.1](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.4.1&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).
* [Bugs fixed in 1.4.2](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.4.2&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0)

Breaking Changes
----------------

Orchard 1.4 introduces a breaking change with the Autoroute and Alias features by removing
the Route part that was previously handling URLs and titles for content items.

Migrating existing content items can be done with a special module (see next section), but
it may also happen that some modules that were relying on the presence of Route may stop working.

We've asked all module developers to review their code with the new version, but there may
still be incompatible ones out there. If a module misbehaves, please check whether a new version
is available. If there isn't one, please contact its author through the contact form on the
[Orchard Gallery](http://gallery.orchardproject.net/).

You may also attempt to fix the modules you need: we have a set of instructions on this thread:
<http://orchard.codeplex.com/discussions/311109>

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

Orchard 1.4 introduces breaking changes in the way content URLs are managed. Because of that,
the source code version comes with a special module, UpgradeTo14, that can be used to migrate
data from a previous version of Orchard to 1.4. If you upgrade a site to 1.4 code and can't
see your contents, you probably need to run this module. In order to do that, go to the admin
section of the site (by appending /admin to the URL where the home page should be), then go
to Modules and enable the feature.

The feature, once enabled, adds a new entry to the admin menu: "Migrate to 1.4", that can
migrate the Route data of your content items as well as field data from older field modules.

To migrate route data, check the types to migrate, then click the Migrate button. This will
move all your route data to the new alias and autoroute feature, it will move your titles
to the Title part, and it will remove the Route part from your content type definition,
replacing it with the newer Autoroute and Title parts.

To migrate field values from existing field features such as Contrib.DateTimeField, click
on the "Migrate Fields" tab on the "Migrate to 1.4" screen. Check the types you want to
migrate, then click the Migrate button.

All your contents should now be restored ad functioning like it was in the previous version
of Orchard that you were using.

How to Reset Your Site Data
---------------------------

The App_Data directory contains database and settings documents produced during setup.  
The contents of this directory are protected from download by visitors to your site. 

*To completely reset your site* (destroy all data, starting from the setup screen again), 
you can delete the contents of this directory.  This action is irreversible so backup first!


For other known issues, please refer to [url:http://orchard.codeplex.com/workitem/list/basic].

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:

* JLedel
* TheMonarch (Giscard Biamby)
* Kevin Kuebler
* sberry3057
* miguelerm
* styx31
* piedone
* EddieDesk
* ldhertert
* martijnl
* Steve@raptor
* randompete (Pete Hurst)
* agriffard (Antoine Griffard)
* planetClaire (Claire Botman)
* Sebastien Ros
* Bertrand Le Roy
* Nicholas Mayne

For 1.4.1:

* piedone
* filetek
* pszmyd
* rdobson
* Nicholas Mayne
* Laere

For 1.4.2:

* jao28
* Claire Botman