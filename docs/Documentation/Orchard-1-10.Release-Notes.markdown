Build: 1.10

Published: 3/18/2016

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.zip
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

Orchard 1.10 includes all the changes from version 1.9.3 <http://docs.orchardproject.net/Documentation/Orchard-1-9-3.Release-Notes> and introduces the following changes and features:

#### Features
* Default values for content fields
* Configurable locations for Modules and Themes ([see this documentation page on how to configure them](http://docs.orchardproject.net/en/latest/Documentation/Orchard-module-loader-and-dynamic-compilation/#custom-folders))
* Parameterized snippets
* Orchard.Resources now contains common assets to be reused across core modules
* Layer rules have been moved to Orchard.Conditions for reusability
* Orchard.TaskLease has been deprecated in favor of distributed locks
* Orchard.jQuery has been deprecated in favor of Orchard.Resources
* Editor tabs support

#### Improvements
* Use of Nuget packages instead of the /lib folder
* New extension methods for migrations
* Upgraded to .NET 4.5.2
* Recipes and Import/Export improvements
* Orchard.exe help command enhancement

#### Bugs

Bug fixes are listed in the [1.9.3 release notes](http://docs.orchardproject.net/Documentation/Orchard-1-9-3.Release-Notes).
The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.10](https://github.com/OrchardCMS/Orchard/issues?q=is%3Aissue+milestone%3A%22Orchard+1.10%22+is%3Aclosed).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your site and database first.

### Upgrading from Orchard 1.9 and earlier

Please follow the upgrade instruction from this document: <http://docs.orchardproject.net/en/latest/Documentation/Orchard-1-9.Release-Notes/>

#### Disabled modules

Some modules are not loaded automatically and need to be enabled manually if you are using them:

 - Orchard.Workflows.Timer
 - Orchard.Email.Workflow
 - Orchard.Users.Workflows
 - Orchard.Roles.Workflows

#### Themes & Layouts

If you are using the Orchard.Layouts module you might need to integrate a custom css file to support the grid system.
Layouts is using some default classes like `span-4`, which was added automatically by the module but could conflict with the ones in other grid frameworks.

It's no more added by default. TheThemeMachine is importing it by itself. Most Bootstrap theme should already override the Layout's tagging to incorporate its custom classes.

If this file is necessary for your theme you will need to add it back to it:
`https://github.com/OrchardCMS/Orchard/blob/dev/src/Orchard.Web/Modules/Orchard.Layouts/Styles/default-grid.css`

#### Deprecated modules

If your modules were using files or resources from Orchard.jQuery you will need to point to the ones defined in Orchard.Resources.

If your modules were using services from Orchard.TaskLease you will need to use `IDistributedLock` instead.

#### JetBrains annotations has been removed

If your modules were using some of these attributes you will need to remove them or to [include them](https://github.com/OrchardCMS/Orchard/blob/1.9.3/src/Orchard/Validation/JetBrains.Annotations.cs) back into your projects.

#### Nuget packages

Because we have moved to using Nuget packages instead of the /lib folder, you will need to point to the same Nuget packages if you were using the /lib folder.

@qt1 has created a script to help with the migration to Nuget here: https://github.com/OrchardCMS/Orchard/issues/6529

#### Database constraints

Orchard 1.10 contains new database contraints to prevent corrupted data. One of them might fail if you already have duplicated content item versions.

To check if you have some you can run this query and delete the duplicated entries.

```
SELECT [Number], [ContentItemRecord_id], COUNT(*) 
FROM [Orchard_Framework_ContentItemVersionRecord]
GROUP BY [Number], [ContentItemRecord_id]
HAVING ( COUNT(*) > 1 )
```

#### Warning on Workflows localization fixes

Due to a fix on how Workflows activity outcomes (e.g. "Done") are localized, after upgrading to Orchard 1.10 part of the connections between Workflows activities will get lost on a site that uses a localized (non-English) admin area and you'll have to re-connect activities. How many connections get lost depends on the completeness of the localization package for the Workflows module.

Thus make sure to take notes of the structure of your workflows **before** upgrading if your site's admin area is using a culture other than an English one and has a localization package installed. If your site doesn't make use of Workflows, uses and English-speaking culture or doesn't have a localization package installed then it's not affected.

#### Warning on Email Workflows Activities

If you use the Send Email activity in Workflows to send emails you may want to check whether you have the Email Workflows Activities feature enabled. Due to a bug you could use the Send Email activity even if you had the feature disabled, but this was fixed and now you have to enable Email Workflows Activities to be able to send emails.

#### Warning on Dynamic Forms feature relocation

There are two new features in the Dynamic Forms module, Dynamic Forms Validation Activities and Dynamic Forms User Bindings. These contain the C# form submission validator and bindings for `UserPart`, respectively. Since these were moved to their own features from the root feature (to avoid the root feature depend on the Orchard.Scripting.CSharp and Orchard.Users modules) if you make use of these services you have to enable the new features.

#### .NET 4.5.2 breaks module compilation 

Because the Orchard.Framework project now targets .NET 4.5.2, all modules that are downloaded from the gallery during development will need to be retargetd to .NET 4.5.2 too.

Not doing this will prevent the module from compiling and appearing in the modules list.

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:

- Alex Petryakov ([neTp9c](https://github.com/neTp9c))
- Alexey Ryazhskikh ([musukvl](https://github.com/musukvl))
- Arman Forghani ([armanforghani](https://github.com/armanforghani))
- Baruch Nissenbaum ([qt1](https://github.com/qt1))
- Benedek Farkas ([Lombiq](https://github.com/Lombiq))
- Bertrand Le Roy	([bleroy](https://github.com/bleroy))
- Chris Payne ([paynecrl97](https://github.com/paynecrl97))
- Connor Smallman ([connorsmallman](https://github.com/connorsmallman))
- Daniel Lackenby ([DanielLackenbyBede](https://github.com/DanielLackenbyBede))
- Daniel Stolt ([DanielStolt](https://github.com/DanielStolt))
- Gustavo Tandeciarz ([dcinzona](https://github.com/dcinzona))
- Hannan Azam ([hannan-azam](https://github.com/hannan-azam))
- Jamie Philips ([phillipsjs](https://github.com/phillipsjs))
- Jean-Thierry Kéchichian ([jtkech](https://github.com/jtkech))
- Jerome van den Heuvel ([Jwheuvel](https://github.com/Jwheuvel))
- Katsuyuki Ohmuro ([harmony7](https://github.com/harmony7))
- Kexy Biscuit ([KexyBiscuit](https://github.com/KexyBiscuit))
- Levent Esen ([leventesen](https://github.com/leventesen))
- Marek Dzikiewicz ([MpDzik](https://github.com/MpDzik))
- Matthew Harris ([rtpHarry](https://github.com/rtpHarry))
- Matt Varblow ([mvarblow](https://github.com/mvarblow))
- Mohammed Kinawy ([mkinawy](https://github.com/mkinawy))
- Nicholas Mayne ([Jetski5822](https://github.com/Jetski5822))
- Paul Devenney ([PaulDevenney](https://github.com/PaulDevenney))
- Piotr Szmyd ([pszmyd](https://github.com/pszmyd))
- Rob King ([gcsuk](https://github.com/gcsuk))
- Ryan Drew Burnett ([ryandrewburnett](https://github.com/ryandrewburnett))
- Sebastien Ros ([sebastienros](https://github.com/sebastienros))
- Sipke Schoorstra ([sfmskywalker](https://github.com/sfmskywalker))
- Szymon Seliga ([SzymonSel](https://github.com/SzymonSel))
- Thierry Fleury ([TFleury](https://github.com/TFleury))
- Titus Anderson ([flew2bits](https://github.com/flew2bits))
- Westley Harris ([wharri220](https://github.com/wharri220))
- Zhi Sun ([sunz7](https://github.com/sunz7))
- Zoltán Lehóczky ([Lombiq](https://github.com/Lombiq))
