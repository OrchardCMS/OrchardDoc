Build: 1.9

Published: 05/05/2015

How to Install Orchard
----------------------

To install Orchard using Web PI, follow these instructions:
<http://docs.orchardproject.net/Documentation/Installing-Orchard>.
Web PI will detect your hardware environment and install the application.

Alternatively, to install the release manually, download the Orchard.Web.1.9.zip file.

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

If you just want to use Orchard and don't care about the source code, Orchard.Web.1.9.zip
is what you want to use, preferably through the WebPI instructions.
Do not attempt to build the WebPI version in VS. Use the full source if you want to use VS.

If you want to take a look at the source code or want to be able to build the application in Visual Studio,
Orchard.Sources.1.9.zip is fine.

If you want to setup a development environment for patch or module development,
you should clone the repository by following the instructions here:
<http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment>

Branches are described here: <http://docs.orchardproject.net/Documentation/Developer-FAQ#Whatarethedefaultanddevbranches?WhichoneshouldIbeusing?>

Who should use this software?
-----------------------------

This software is in version 1.9. The code is in a stable state and constitutes
a solid foundation for building applications, themes and modules.
Suggestions are welcome in the discussion forums.

You are allowed to use this software in any way that is compatible with the new BSD license.
This includes commercial derivative work.

What's new?
-----------

Orchard 1.9 fixes bugs and introduces the following changes and features:

* Migration to Microsoft .NET 4.5.1
* Audit Trail module
  * Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum)) and Sipke Schoorstra ([sfmskywalker](https://www.codeplex.com/site/users/view/sfmskywalker)) own this contribution
* Draftable widgets
* Indexable drafts
* Date localization and calendar support improvements and fixes
  * Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum)) owns this contribution
  * More information here: https://orchard.codeplex.com/discussions/560347
* Dynamic Layout module
  * Sipke Schoorstra ([sfmskywalker](https://www.codeplex.com/site/users/view/sfmskywalker)) and Daniel Stolt ([Decorum](https://www.codeplex.com/site/users/view/Decorum)) own this contribution
* Dynamic Forms module
  * Sipke Schoorstra ([sfmskywalker](https://www.codeplex.com/site/users/view/sfmskywalker)) owns this contribution
* Integrate OWIN middlewares support
  * Nick ([Jetski5822](https://www.codeplex.com/site/users/view/Jetski5822)) is responsible for this feature
* Upgrading to ASP.NET MVC 5.2
* Upgrading to .NET Framework 4.5.1
* Adding Azure Redis Cache support
  * Add business cache implementation
* Upgrading to TinyMCe 4
* Localization improvements
  * Nick ([Jetski5822](https://www.codeplex.com/site/users/view/Jetski5822)) is responsible for this feature
  * RTL support in Admin
  * Culture selector (admin and front end)
* Message Bus
* Search widgets
* Improved caching features
* PBKDF2 is now the default password hashing algorithm


The full list of fixed bugs for this release can be found here:

* [Bugs fixed in 1.9](https://github.com/OrchardCMS/Orchard/issues?q=is%3Aissue+milestone%3A%22Orchard+1.9%22+is%3Aclosed).

How to upgrade from a previous version
--------------------------------------

You can find migration instructions here: <http://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard>.

No matter what migration path you take, please take the precaution of making a backup of your
site and database first.

### Upgrading from Orchard 1.8.2 and earlier

Please follow the upgrade instruction from this document: <http://docs.orchardproject.net/Documentation/orchard-1-8-2.release-Notes>

#### Upgrading modules

Orchard 1.9 bumps up the .NET Framework version it depends on from 4.5 to 4.5.1. You may need to perform the same upgrade in your module's project properties before it successfully compiles.

#### Note on the change of the default password hash algorithm

As per the [work item #21036](https://orchard.codeplex.com/workitem/21036) the hash algorithm used by default to hash user passwords for storage was changed from SHA1 to PBKDF2 (more precisely the `System.Web.Helpers.Crypto.HashPassword()` implementation).

By default all existing user passwords will be migrated to the new hash when the user successfully logs in next time. If you want to prevent this migration and force every existing password hashes to stay SHA1 then add an appSettings or connectionString configuration to the Web.config (or equivalent) with the name `"Orchard.Users.KeepOldPasswordHash"` and value `"true"`.

#### Note on improved handling of setup recipes

Setup recipes are now [automatically harvested](https://orchard.codeplex.com/workitem/20942) from all modules for the setup screen. This means that you don't have to add your setup recipes to the Orchard.Setup module any more, you can keep them in your own modules.

Keep in mind however that recipes intended for setup now should possess the IsSetupRecipe metadata (see the recipes in Orchard.Setup), otherwise they won't show up on the setup screen.

Contributors
------------

This software would not exist without the community. In particular, for this release,
we should all be grateful to the following people who contributed patches and features:

- Abhishek Luv	([abhishekluv](http://www.codeplex.com/site/users/view/abhishekluv))
- 	([anoordende](http://www.codeplex.com/site/users/view/anoordende))
- Antoine Griffard	([agriffard](http://www.codeplex.com/site/users/view/agriffard))
- Benedek Farkas	([nightwolf226](https://www.codeplex.com/site/users/view/nightwolf226))
- Benjamin Grabkowitz	([bgrabkowitz](https://www.codeplex.com/site/users/view/bgrabkowitz))
- Bertrand Le Roy	([bertrandleroy](http://www.codeplex.com/site/users/view/bertrandleroy))
- Bill Cooper	([bill_cooper](http://www.codeplex.com/site/users/view/bill_cooper))
- Brett Morrison	([morrisonbrett](https://www.codeplex.com/site/users/view/morrisonbrett))
- Bryan Porter	([brporter](https://www.codeplex.com/site/users/view/brporter))
- Christian Surieux	([csadnt](http://www.codeplex.com/site/users/view/csadnt))
- Claire Botman	([planetClaire](https://www.codeplex.com/site/users/view/planetClaire))
- Dain Kaplan	
- Daniel Dabrowski	([rodpl](https://www.codeplex.com/site/users/view/rodpl))
- Daniel Stolt	([Decorum](https://www.codeplex.com/site/users/view/Decorum))
- Denis Besic	([besicdenis](https://www.codeplex.com/site/users/view/besicdenis))
- Eric Perez	
- Gilian Keulens	([Walance](http://www.codeplex.com/site/users/view/Walance))
- Jack Cheng	([jchenga](https://www.codeplex.com/site/users/view/jchenga))
- Jay Harris	([jayharris](https://www.codeplex.com/site/users/view/jayharris))
- Jason Burgard	([jburgard](https://www.codeplex.com/site/users/view/jburgard))
- Jasper Dunker	([jasperd](http://www.codeplex.com/site/users/view/jasperd))
- 	([jcastillopino](http://www.codeplex.com/site/users/view/jcastillopino))
- Jean-Thierry Kéchichian	([jtkech](https://www.codeplex.com/site/users/view/jtkech))
- Jeff Bullock	([j3ffb](https://www.codeplex.com/site/users/view/j3ffb))
- Josh Berry	([joshby](https://www.codeplex.com/site/users/view/joshby))
- Katsuyuki Ohmuro	([kohmuro](https://www.codeplex.com/site/users/view/kohmuro))
- Kegan Maher	([thekaveman](https://www.codeplex.com/site/users/view/thekaveman))
- Mark Loveland-Armour	([forsvarir](https://www.codeplex.com/site/users/view/forsvarir))
- Matt Varblow	([mvarblow](https://www.codeplex.com/site/users/view/mvarblow))
- Michael Yates	([mjy78](http://www.codeplex.com/site/users/view/mjy78))
- Nicholas Mayne	([Jetski5822](http://www.codeplex.com/site/users/view/Jetski5822))
- Paul Devenney	
- Piotr Szmyd	([pszmyd](https://www.codeplex.com/site/users/view/pszmyd))
- Sebastien Ros	([sebastienros](http://www.codeplex.com/site/users/view/sebastienros))
- Sotirios Roussos	([urbanit](http://www.codeplex.com/site/users/view/urbanit)
- Sipke Schoorstra	([sfmskywalker](http://www.codeplex.com/site/users/view/sfmskywalker))
- Stanley Goldman	([StanleyGoldman](http://www.codeplex.com/site/users/view/StanleyGoldman))
- Thierry Fleury	([Codinlab](https://www.codeplex.com/site/users/view/Codinlab))
- Wojciech Gadzinski	([toneuk](https://www.codeplex.com/site/users/view/Ermesx))
- 	([Xeevis](https://www.codeplex.com/site/users/view/Xeevis))
- Zoltán Lehóczky	([Piedone](http://www.codeplex.com/site/users/view/Piedone))
- Baruch Nissenbaum	([qt1](http://www.codeplex.com/site/users/view/qt1))
