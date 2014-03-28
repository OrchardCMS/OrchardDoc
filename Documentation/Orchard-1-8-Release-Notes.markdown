Build: 1.8

Published: 03/28/2014

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.8.zip file.

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.8.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
Orchard.Source.1.8.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.8. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.8 fixes bugs and introduces the following changes and features:

* Migration to Microsoft .NET 4.5
  * Upgrade project targets
  * Remove unnecessary Medium Trust support code
  * Define 4.5 framework in web.config files
  * Erik ([erik_oppedijk](https://www.codeplex.com/site/users/view/erik_oppedijk)) owns this contribution
* Upgrade ASP.NET Web Stack to newest versions
  * ASP.NET MVC 5.1
  * WebAPI 2.1
  * Razor 3.1
* Put back the List module with improved functionnalities
  * The goal is to be able to use it to mimick the Blogs module
  * Sipke ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker)) owns this contribution
* Performance improvements by unleashing the power of the document db architecture built in Orchard
  * Sebastien ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros)) owns this contribution
  * Multi-tenancy improvements
* Calendar support
  * Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum)) owns this contribution
* Jobs Queue module (done)
  * Orchard.JobsQueueing
* Templates module (done)
  * Orchard.Templates
* Business Caching modules
  * Orchard.Caching
* Orchard.Email
  * The messaging infrastructure has been deprecated and replaced by a simpler one. As part of this change you can now define the email templates directly in shapes. 
  * The SMTP settings are read from the web.config file by default if available.
* Azure Media Services has been contributed by Microsoft Open Technologies and provides a seamless integration with the Media module
  * Orchard.Azure.MediaServices
* Orchard.Azure:
  * `PlatformConfiguration` (static class to read settings from `CloudConfigurationManager`) is extended to look for settings in among the `ConnectionStrings` and the `AppSettings` too.
  * Added an injectable dependency called `IPlatformConfigurationAccessor` to provide an extensibility point for retrieving settings. The default implementation's (`DefaultPlatformConfigurationAccessor`) only purpose is to wrap `PlatformConfiguration` and is currently used by `AzureBlobStorageProvider`. IMPORTANT: Custom implementations don't have any effect on the cache-related services due to NHibernate limitations.
  * Orchard.Azure.Media now depends of Orchard.Azure.
  * Added a new setting called `Orchard.Azure.Media.StoragePublicHostName` which makes it possible to override the public host name when using Azure storage.

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.8](https://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Resolved%7CClosed&type=All&priority=All&release=Orchard%201.7.2&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.7.1 and earlier

Please follow the upgrade instruction from this document : https://github.com/OrchardCMS/OrchardDoc/blob/1.8/Documentation/Orchard-1-7-2-Release-Notes.markdown

Then proceed with the upgrade steps from 1.7.2.

### Upgrading from Orchard 1.7.2

__BEFORE DOING ANYTHING PLEASE FOLLOW THIS STEPS:__
* Backup your database and your website content
* __Assign the `Administrator` role to your current Super User account__. 
  * You will need an account with the _Site Owner_ permission before you update your website with the new release. Without this step you won't be able to access the dashboard.

In case you are discovering this notice too late, here is the manual operation to apply. In your database table Orchard_Framework_ContentItemRecord, on the record with `id=1` (the site content item), update the value with this content `<Data><SiteSettingsPart SuperUser="admin"/></Data>`

* Enable the Upgrade module

#### Migrating Email activities

In Orchard 1.8 the Send Email workflow activity has been replaced by a new one which is able to send emails asynchronously using the Jobs Queue.

* Click on Upgrade To 1.8 from the menu
* Select the Messaging tab and click **Migrate**

#### Migrating Infoset

In Orchard 1.8 a new data storage technique is introduced saving some of the content in the infoset document of content items instead of records. This way some records are obsolete and can be deleted. The data it contained needs to be migrated though.

* Click on Upgrade To 1.8 from the menu
* Select the Infoset tab and click on all the **Migrate** buttons one at a time

If you are not sure if one button was clicked you can try again and it will just be ignored if it was already processed.


Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:

- Antoine Griffard ([agriffard](http://www.codeplex.com/site/users/view/agriffard))
- Benedek Farkas ([nightwolf226](https://www.codeplex.com/site/users/view/nightwolf226))
- Benjamin Grabkowitz ([bgrabkowitz](https://www.codeplex.com/site/users/view/bgrabkowitz))
- Bertrand Le Roy ([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy))
- Brett Morrison ([morrisonbrett](https://www.codeplex.com/site/users/view/morrisonbrett))
- Claire Botman ([planetClaire](https://www.codeplex.com/site/users/view/planetClaire))
- Daniel Dabrowski ([rodpl](https://www.codeplex.com/site/users/view/rodpl)) 
- Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum))
- Erik Oppedijk ([erik_oppedijk](https://www.codeplex.com/site/users/view/erik_oppedijk))
- Eric Schultz ([wwahammy](https://www.codeplex.com/site/users/view/wwahammy))
- ([fassetar](https://www.codeplex.com/site/users/view/fassetar))
- Gilian Keulens ([Walance](http://www.codeplex.com/site/users/view/Walance))
- ([Gorizon47](http://www.codeplex.com/site/users/view/Gorizon47))
- Henry Kuijpers ([hkui](https://www.codeplex.com/site/users/view/hkui))
- Jay Harris ([jayharris](https://www.codeplex.com/site/users/view/jayharris))
- Jasper Dunker ([jasperd](http://www.codeplex.com/site/users/view/jasperd))
- Jean-Thierry Kéchichian ([jtkech](https://www.codeplex.com/site/users/view/jtkech))
- Jeff Olmstead ([jao28](https://www.codeplex.com/site/users/view/jao28))
- Jim Macdonald ([Jimasp](http://www.codeplex.com/site/users/view/Jimasp))
- Josh Berry ([joshby](https://www.codeplex.com/site/users/view/joshby))
- kassobasi ([kassobasi](https://www.codeplex.com/site/users/view/kassobasi))
- Michael Yates ([mjy78](http://www.codeplex.com/site/users/view/mjy78))
- Piotr Szmyd ([pszmyd](https://www.codeplex.com/site/users/view/pszmyd))
- Sebastien Ros ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros))
- Sipke Schoorstra ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker))
- Stanley Goldman ([StanleyGoldman](http://www.codeplex.com/site/users/view/StanleyGoldman))
- Thierry Fleury ([Codinlab](https://www.codeplex.com/site/users/view/Codinlab))
- Tony Mackay ([toneuk](https://www.codeplex.com/site/users/view/toneuk))
- Zoltán Lehóczky ([Piedone](http://www.codeplex.com/site/users/view/Piedone))

Special Thanks to Christian Surieux ([csadnt](http://www.codeplex.com/site/users/view/csadnt)) for his active participation on the forums.
