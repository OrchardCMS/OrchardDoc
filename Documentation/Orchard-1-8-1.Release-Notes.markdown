Build: 1.8.1

Published: 06/19/2014

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.8.1.zip file.

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
Orchard.Source.1.8.1.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.8.1. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.8.1 fixes bugs and introduces the following changes and features:

* Url tokens not working in background tasks
* Decision Activity doesn't work
* Jobs queue don't use the correct priority when created
* Unable to use HasTerms multiple times on the same query
* Media library does not display thumbnail if the urls contains special chars
* Upgraded JSON.NET
* Razor Template Processor is now a separate feature
* Missing Microsoft.Data.Edm dependency
* PublishOwnBlogPost and PublishBlogPost permissions are ignored	
* Output cache improvements
* Changing Site owner doesn't work

The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.8.1](https://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Resolved%7CClosed&type=All&priority=All&release=Orchard%201.8.1&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.7.1 and earlier

Please follow the upgrade instruction from this document: <http://docs.orchardproject.net/Documentation/Orchard-1-7-2-Release-Notes>

Then proceed with the upgrade steps from 1.7.2.

### Upgrading from Orchard 1.7.2

__BEFORE DOING ANYTHING PLEASE FOLLOW THIS STEPS:__

* Backup your database and your website content
* __Assign the `Administrator` role to your current Super User account__. 

You will need an account with the `Site Owner` permission before you update your website with the new release. Without this step you won't be able to access the dashboard.

In case you are discovering this notice too late, here is the manual operation to apply. In your database table `Orchard_Framework_ContentItemRecord`, on the record with `id=1` (the site content item), update the value with this content `<Data><SiteSettingsPart SuperUser="admin"/></Data>`

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
- Bertrand Le Roy ([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy))
- Claire Botman ([planetClaire](https://www.codeplex.com/site/users/view/planetClaire))
- Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum))
- Jeff Bullock ([j3ffb](http://www.codeplex.com/site/users/view/j3ffb))
- Nicholas Mayne ([Jetski5822](http://www.codeplex.com/site/users/view/Jetski5822))
- Sebastien Ros ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros))
- Sipke Schoorstra ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker))
- Stanley Goldman ([StanleyGoldman](http://www.codeplex.com/site/users/view/StanleyGoldman))
- Wojciech Gadziński ([Ermesx](https://www.codeplex.com/site/users/view/Ermesx))
- Zoltán Lehóczky ([Piedone](http://www.codeplex.com/site/users/view/Piedone))
