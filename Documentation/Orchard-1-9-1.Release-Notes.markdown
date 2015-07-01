Build: 1.9.1

Published: 06/30/2015

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, look for the release files on 
https://github.com/OrchardCMS/Orchard/releases

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.9.1.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
https://github.com/OrchardCMS/Orchard/archive/1.9.1.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.9.1. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.9.1 fixes bugs and introduces the following changes and features:

* Tokens are evaluated by layout elements
* Fixed performance regression for widgets
* Fixed localization string encoding
* Improved native clipboard support in layout editor
* New heading, fieldset and break elements for the layout editor
* Upgraded to ASP.NET 5.2.3 and Razor 3.2.3
* Improved performance of output cache key generation
* Added the ability to set the SSL setting for cookies in the SSL module
* Added support for Visual Studio 2015
* New sticky toolbox in the layout editor
* Improved logging for recipe execution
* Jobs queue is now used to trigger indexing
* Added import/export for projections
* New ItemDisplayText extension to manage encoding options

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.9.1](https://github.com/OrchardCMS/Orchard/issues?utf8=%E2%9C%93&q=is%3Aclosed+is%3Aissue+milestone%3A%22Orchard+1.9.1%22+).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.
