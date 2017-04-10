Build: 1.10.2

Published: 4/11/2017

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

You will find the files to download on our Github release page: https://github.com/OrchardCMS/Orchard/releases/tag/1.10.2

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.10.2.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
https://github.com/OrchardCMS/Orchard/archive/1.10.2.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.10.2. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

Breaking Changes
-----------

There are no known breaking changes as part of this release [compared to 1.10](Orchard-1-10.Release-Notes).

What's new?
-----------

Orchard 1.10.2 fixes bugs and introduces the following notable changes and features:

* [Feature] Custom Lucene analyzer selection
* [Feature] New workflow activity to remove a role
* [Feature] Strict Transport Security option for SSL
* [Feature] Content Picker localization
* [Feature] Filter widgets by culture
* [Improvement] Vary output cache by cookie
* [Improvement] "Publish later" tasks can be removed
* [Improvement] Default database indexes on Tags and Taxonomies
* [Improvement] Individual form submissions exports
* [Improvement] "Save" is renamed "Save Draft"
* [Improvement] C#5 validation is enforced
* [Improvement] New User.Parameter token
* [Bug] Scheduled task is not deleted when the content is published
* [Bug] Taxonomy sorting
* [Bug] User Media folder names collisions
* [Bug] Blog post permissions
* [Bug] Configured database isolation level is not respected
* [Bug] Gallery search is failing
* [Bug] CacheManager is not thread-safe
* [Bug] MySql failures on Setup
* [Bug] Exporting TextField with empty values down't work
* [Bug] Job queue is not processed in batches

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.10.2](https://github.com/OrchardCMS/Orchard/issues?utf8=%E2%9C%93&q=is%3Aclosed+is%3Aissue+milestone%3A%22Orchard+1.10.2%22+).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.
