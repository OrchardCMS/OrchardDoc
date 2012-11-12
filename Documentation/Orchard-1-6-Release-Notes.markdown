Build: 1.6

Published: 10/27/2012

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.6.zip file.

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.6.zip
is what you want to use, preferably through the WebPI instructions.

If you want to take a look at the source code, Orchard.Source.1.6.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.6. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.6 fixes bugs and introduces the following features:

* *ASP.NET MVC 4:*  We upgraded the MVC library to the latest available version.
* *Razor 2:* The brand new version of the Razor view engine which simplifies many parts of your views. 
Details here <http://vibrantcode.com/blog/2012/4/10/whats-new-in-razor-v2.html/> 
and here <http://vibrantcode.com/blog/2012/4/13/what-else-is-new-in-razor-v2.html/>.
* *Web API:* The rest-enabled web framework which lets you create API from Orchard modules
* *MySQL:* There is now a third option in the setup screen to use MySQL as the database.
* *NHibernate 3.3:* We upgraded the NHibernate library to the latest available version, allowing module developers 
to leverage database caching.
* *SysCache:* A default implementation of a database cache provider.
* *Performance:* Some work as been done to improve performance in different places like Widgets/Layers and Blog archives.
* *Precompiled target*: There is a new "Precompiled" build target which generates a build without any source code
* *File monitoring is off by default*: When building the website using a build script - usually for deployment - files won't be monitored by default.
* *Session configuration*: Sessions behavior can be defined per module and per route, and are on by default
The full list of more than 200 fixed bugs for this release can be found here:

* [Bugs fixed in 1.6](http://orchard.codeplex.com/workitem/list/advanced?keyword=&status=Fixed|Closed&type=All&priority=All&release=Orchard%201.6&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0).

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

#### Themes

If you are using a custom theme, the new Razor parser might fail on the previous version of the LogOn.cshtml 
template. If you have such a file in your theme then you will need to change lines 2 and 3 accordingly:

    @{
        var userCanRegister = WorkContext.CurrentSite.As<Orchard.Users.Models.RegistrationSettingsPart>().UsersCanRegister;
        var enableLostPassword = WorkContext.CurrentSite.As<Orchard.Users.Models.RegistrationSettingsPart>().EnableLostPassword;
    }

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


* Antoine Griffard ([agriffard](http://www.codeplex.com/site/users/view/agriffard))
* Benedek Farkas ([nightwolf226](http://www.codeplex.com/site/users/view/nightwolf226))
* Bertrand Le Roy ([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy))
* David Cornish ([davidcornish](http://www.codeplex.com/site/users/view/davidcornish))
* David Hayden ([davidhayden](http://www.codeplex.com/site/users/view/davidhayden))
* Giscard Biamby ([TheMonarch](http://www.codeplex.com/site/users/view/TheMonarch))
* Jeff Bullock ([j3ffb](http://www.codeplex.com/site/users/view/j3ffb))
* Martin Skinner ([filetek](http://www.codeplex.com/site/users/view/filetek))
* Matt Melling ([kobowi](http://www.codeplex.com/site/users/view/kobowi))
* Michael Yates ([mjy78](http://www.codeplex.com/site/users/view/mjy78))
* Nathan Swenson ([nswenson](http://www.codeplex.com/site/users/view/nswenson))
* Nicholas Mayne ([Jetski5822](http://www.codeplex.com/site/users/view/Jetski5822))
* Pedro Costa ([pnmcosta](http://www.codeplex.com/site/users/view/pnmcosta))
* Piotr Szmyd ([pszmyd](http://www.codeplex.com/site/users/view/pszmyd))
* Rebecca Pleshaw ([Rebecca](http://www.codeplex.com/site/users/view/Rebecca))
* Rickard Pettersson ([RickardP](http://www.codeplex.com/site/users/view/RickardP))
* Sebastien Ros ([sebastienros](http://www.codeplex.com/site/users/view/sebastienros))
* Sergey Ermakovich ([yermakovich](http://www.codeplex.com/site/users/view/yermakovich))
* Sipke Schoorstra ([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker))
* Thomas Bolon ([styx31](http://www.codeplex.com/site/users/view/styx31))
* Tim Mylemans ([AimOrchard](http://www.codeplex.com/site/users/view/AimOrchard))
* Zoltán Lehóczky ([Piedone](http://www.codeplex.com/site/users/view/Piedone))
