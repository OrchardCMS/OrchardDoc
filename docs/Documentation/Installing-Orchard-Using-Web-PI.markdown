
There are a few ways to install the latest Orchard release:

1. You can install Orchard by simply downloading and extracting the Release zip file to a local IIS directory, then launching your browser to the appropriate URL.  Make sure you download the appropriate zip for yur machine environment (32-bit or 64-bit).
2. You can also extract to a local folder, open the included Orchard.WebPI.csproj file in Visual Studio, and press Ctrl-F5 to run it under the ASP.NET Development Server (Cassini).  Make sure to download the 32-bit zip of Orchard, since Cassini runs as a 32-bit process.
3. You can install using the Web Platform Installer (Web PI).

**For options 1 and 2, download the zips from our CodePlex site: [http://orchard.codeplex.com/releases](http://orchard.codeplex.com/releases)**

**This document describes option 3 - the steps to install using Web PI.** 

First, download the Web Platform Installer from [http://www.microsoft.com/web](http://www.microsoft.com/web) Click the "Options" link to configure Web PI to use the Orchard private feed.

<img src="/docs/GetFile.aspx?File=/setup/0_Options.png" width="575" />

Type the URL to the private feed: http://www.orchardproject.net/privatedrops/orchardfeed.xml

<img src="/docs/GetFile.aspx?File=/setup/1_AddFeed.png" width="575" />

Click the "Add Feed" button to add the feed URL.

<img src="/docs/GetFile.aspx?File=/setup/2_FeedAdded.png" width="575" />

Click OK to confirm the Options dialog. A new Orchard tab appears in Web PI.

<img src="/docs/GetFile.aspx?File=/setup/3_OrchardTab.png" width="575" />

You can click the link to install recommended products to grab the latest Orchard release build. Alternatively, you can click "Customize" to view the available Orchard builds.

<img src="/docs/GetFile.aspx?File=/setup/4_OrchardLatest.png" width="575" />

Clicking the "info" icon will display details for a given release (along with the build number). To install an Orchard release build, select the checkbox and click "Install"

<img src="/docs/GetFile.aspx?File=/setup/5_OrchardDetails.png" width="575" />

Accept the license terms (New BSD) to proceed.

<img src="/docs/GetFile.aspx?File=/setup/6_LicenseAccept.png" width="575" />

Type the name of the application directory in IIS where you want Orchard to be installed (defaults to "http://localhost/orchard")

<img src="/docs/GetFile.aspx?File=/setup/7_AppName.png" width="575" />

When the installation is complete, click the "Launch Orchard CMS (Latest Build)" link

<img src="/docs/GetFile.aspx?File=/setup/8_Installing.png" width="575" />

<img src="/docs/GetFile.aspx?File=/setup/9_InstallSuccess.png" width="575" />

In your browser, you will be presented with the Orchard setup screen. Answer these questions and click "Finish Setup" when done.

<img src="/docs/GetFile.aspx?File=/setup/10_Setup.png" width="575" />

You are now on the Orchard home page and can begin configuring your site. Enjoy! 

<img src="/docs/GetFile.aspx?File=/setup/11_OrchardHome.png" width="575" />
