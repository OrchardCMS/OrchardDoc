Build: 1.9.2

Published: 10/15/2015

This release contains bug fixes and new features.

How to Install Orchard
----------------------

To install Orchard using WebPI, follow these instructions:
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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.9.2.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
https://github.com/OrchardCMS/Orchard/archive/1.9.2.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.9.2. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

Breaking Change
-----------
We unintentionally introduced a breaking change with this release. It has to do with the Content Part's **Placeable** property which was originally named **Placable** (which was a typo).

If your site uses Content Part Elements, you will need to perform the following actions *after* updating to 1.9.2:

1. Go to each Content Part definition that you placed on the layout canvas and enable *Placeable* again.

[Click here](https://github.com/OrchardCMS/Orchard/issues/5530) for more information.
 

What's new?
-----------

Orchard 1.9.2 fixes bugs and introduces the following changes and features:

* [Feature] New ManageOwnMedia permission to prevent users from modifying media they don't own
* [Feature] Ability to debug the Cloud Service locally
* [Feature] Kudu deployment scripts
* [Feature] Layout management permission
* [Feature] "Owned by me" content filter
* [Improvement] Support htmlAttributes in `ItemEditLink`
* [Improvement] Layouts doesn't require TinyMCE anymore
* [Improvement] Assets.json is global, and supports watch
* [Regression] Removed "edit inline" which was not functional
* [Bug] Too many sql connection opened
* [Bug] Widget localization throwing exception
* [Bug] Part settings are resetted when general settings are updated
* [Bug] Cannot delete spam comment
* [Bug] Default layout template is not populated automatically
* [Bug] Double encoding issues across the admin
* [Bug] Unable to translate content
* [Bug] Editing workflow recreates activity records
* [Bug] Processed images are regenerated after every restart


The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.9.2](https://github.com/OrchardCMS/Orchard/issues?utf8=%E2%9C%93&q=is%3Aclosed+is%3Aissue+milestone%3A%22Orchard+1.9.2%22+).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.
