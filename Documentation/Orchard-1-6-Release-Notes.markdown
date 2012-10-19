Build: 1.6 RC

Published: 10/18/2012

How to Install Orchard 1.6 RC
-----------------------------

This release candidate is only provided for testing purposes.

To install the release manually, download the Orchard.Web.1.6.rc.zip file and follow the instructions at this url
<http://docs.orchardproject.net/Documentation/Manually-installing-Orchard-zip-file>
You might then require the updated version of the gallery distributed modules, which are available as a standalone 
download during the RC phase <http://orchard.codeplex.com/downloads/get/515753> . 

It is also being provided in source code form.
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

* *ASP.NET MVC 4:*  We upgraded the MVC library to the latest available verion.
* *Razor 2:* The brand new version of the Razor view engine which simplifies many parts of your views. 
Details here <http://vibrantcode.com/blog/2012/4/10/whats-new-in-razor-v2.html/> 
and here <http://vibrantcode.com/blog/2012/4/13/what-else-is-new-in-razor-v2.html/>.
* *Web API:* The rest-enabled web framework which lets you create API from Orchard modules
* *MySQL:* There is now a third option in the setup screen to use MySQL as the database.
* *NHibernate 3.3:* We upgraded the NHibernate library to the latest available verion, allowing module developers 
to leverage database caching.
* *SysCache:* A default implementation of a database cache provider.
* *Performance:* Some work as been done to improve performance in different places like Widgets/Layers and Blog archives.

The full list of more than 200 fixed bugs for this release can be found here:

* [Bugs fixed in 1.6RC](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.6&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.3 and earlier

Orchard 1.4 introduced breaking changes in the way content URLs are managed. Because of that,
and if you're migrating from version 1.3 or earlier, the UpgradeTo16 module can be used to migrate
data. If you upgrade a site to 1.6RC from 1.3 or earlier and can't
see your contents, you probably need to run this module. In order to do that, go to the admin
section of the site (by appending /admin to the URL where the home page should be), then go
to Modules and enable the feature.

The feature, once enabled, adds a new entry to the admin menu: "Upgrade to 1.6", that can
migrate the Route data of your content items as well as field data from older field modules, and menu items.

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


* Antoine Griffard (agriffard)
* Benedek Farkas (nightwolf226)
* Bertrand Le Roy (bertrandleroy)
* David Cornish (davidcornish)
* David Hayden (davidhayden)
* Jeff Bullock (j3ffb)
* Martin Skinner (filetek)
* Matt Melling (kobowi)
* ??? (mjy78)
* Nathan Swenson (nswenson)
* Nicholas Mayne (Jetski5822)
* Pedro Costa (pnmcosta)
* Piotr Szmyd (pszmyd)
* Rebecca Pleshaw (Rebecca)
* Rickard Pettersson (RickardP)
* Sebastien Ros (sebastienros)
* Sergey Ermakovich (yermakovich)
* Sipke Schoorstra (sfmskywalker)
* ??? (TheMonarch)
* Thomas Bolon (styx31)
* Tim Mylemans (AimOrchard)
* Zoltán Lehóczky (Piedone)
