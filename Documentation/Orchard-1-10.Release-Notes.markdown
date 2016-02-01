Build: 1.10

Published: 2/1/2015

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.10.zip file.

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.10.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
Orchard.Sources.1.10.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.10. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.10 includes all the changes from version 1.9.3 (http://docs.orchardproject.net/Documentation/Orchard-1-9-3.Release-Notes) and introduces the following changes and features:

#### Features
* Default values for content fields
* Configurable location of Modules and Themes
* Parameterized snippets
* Orchard.Resources now contains common assets to be reused across core modules
* Layer rules have been moved to Orchard.Conditions for reusability
* Orchard.TaskLease has been deprecated in favor or distributed locks
* Orchard.jQuery has been deprecated in favor of Orchard.Resources
* Editor tabs support


#### Improvements
* Use of Nuget packages instead of the /lib folder
* New extension methods for migrations
* Upgraded to .NET 4.5.2
* Recipees and Import/Export improvements

#### Bugs

Bug fixes are listed in the [1.9.3 release notes](http://docs.orchardproject.net/Documentation/Orchard-1-9-3.Release-Notes).
The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.10](https://github.com/OrchardCMS/Orchard/issues?q=is%3Aissue+milestone%3A%22Orchard+1.10%22+is%3Aclosed).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your site and database first.

### Upgrading from Orchard 1.9 and earlier

Please follow the upgrade instruction from this document: <http://docs.orchardproject.net/Documentation/orchard-1-9.Release-Notes>

#### Warning on Workflows localization fixes

Due to a fix on how Workflows activity outcomes (e.g. "Done") are localized, after upgrading to Orchard 1.10 part of the connections between Workflows activities will get lost on a site that uses a localized (non-English) admin area and you'll have to re-connect activities. How many connections get lost depends on the completeness of the localization package for the Workflows module.

Thus make sure to take notes of the structure of your workflows **before** upgrading if your site's admin area is using a culture other than an English one and has a localization package installed. If your site doesn't make use of Workflows, uses and English-speaking culture or doesn't have a localization package installed then it's not affected.

#### Warning on Email Workflows Activities

If you use the Send Email activity in Workflows to send emails you may want to check whether you have the Email Workflows Activities feature enabled. Due to a bug you could use the Send Email activity even if you had the feature disabled, but this was fixed and now you have to enable Email Workflows Activities to be able to send emails.

#### Warning on Dynamic Forms feature relocation

There are two new features in the Dynamic Forms module, Dynamic Forms Validation Activities and Dynamic Forms User Bindings. These contain the C# form submission validator and bindings for `UserPart`, respectively. Since these were moved to their own features from the root feature (to avoid the root feature depend on the Orchard.Scripting.CSharp and Orchard.Users modules) if you make use of these services you have to enable the new features.

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:

- ...
