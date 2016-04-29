*This topic targets, and was tested with, the Orchard 1.8 release.*

This topic shows the steps you need to perform to install Orchard using the .zip file.

We will use three different approaches:

  * IIS.
  * WebMatrix and IIS Express
  * Visual Studio and the Visual Studio Development Server.

> **Note**: If you prefer using the Web Platform Installer, or if you plan to use WebMatrix to develop your site, you may want to see the topic [Installing Orchard](Installing-Orchard), which installs Orchard from the Web Platform Installer and includes WebMatrix in the installation.


# Downloading the .zip File

Navigate to the [Releases Section of Orchard in GitHub](https://github.com/OrchardCMS/Orchard/releases). 

You will find two .zip files.

* _Orchard.Web.1.x.xx.zip_ : In this file the site has already been built and can be run without additional compilation. It does not includes all the source code.
* _Orchard.Source.1.x.xx.zip_ : This file includes the source code. If you plan to develop modules you probably prefer this one. It is easier to use with Visual Studio and you have plenty of source files to see how everything is done.


# Running the Site Using IIS
*This procedure was tested with a clean installation of Windows 8.1 Enterprise Edition.*

First let's setup the server. Search for "Add or Remove Programs" in your system. And execute it.

![](/Attachments/Manually-installing-Orchard-zip-file/IISSearchForAddRemovePrograms.png)

Click **Turn Windows features on or off**.

![](/Attachments/Manually-installing-Orchard-zip-file/IISTurnOnWindowsFeatures.png)

Click **Internet Information Services** and then **ASP.NET 4.5**. Click **OK**.

![](/Attachments/Manually-installing-Orchard-zip-file/IISEnableIISAndASP45.png)

At this point we recommend rebooting your system. This way you will be sure that all the required services are started from scratch.

When the system restarts, download the _Orchard.Web.1.x.xx.zip_ file from [here](https://github.com/OrchardCMS/Orchard/releases/latest). Extract the .zip file to your Desktop. The extracted folder contains several files and an *Orchard* folder.

Copy the *Orchard* Folder to *C:\inetpub\wwwroot\\*.

In Windows Explorer go inside the *Orchard* Folder.Let's start with *App\_Data* folder.

This folder is where Orchard stores site settings. Right-click *App\_Data* folder, click **Properties** and using the **Security** tab set modify and read permissions for the *IIS\_IUSRS* user.

Then repeat the same procedure for the following folders:

* _Modules_. This is required if you want to install modules from the gallery. (We recommend that you remove the read/write permissions for production sites.)
* _Themes_. This is required if you want to install themes from the gallery. (We recommend that you remove the read/write permissions for production sites.)
* _Media_. This folder is where Orchard stores media files (images, etc.).


![](/Attachments/Manually-installing-Orchard-zip-file/IISSetFolderPermissions.png)

> **Tip**: If you want to completely reset an Orchard site configuration to its default settings, you can delete the contents of the App\_Data directory. This removes all your custom settings, users, and configuration, as well as any custom data you have added to the site. 
If you delete the contents of the App\_Data folder, and if you want to remove custom images that you have added to the site, you can delete the contents of the Media folder as well. The required files will be recreated the next time Orchard is started.


Now you can create your new website. Search your system for **Internet Information Services (IIS) Manager**, and execute it.

![](/Attachments/Manually-installing-Orchard-zip-file/IISOpenIISManager.png)

Click in **Default Web Site** and **stop**. This will free port 80 for our site.

![](/Attachments/Manually-installing-Orchard-zip-file/IISStopDefaultWebSite.png)


Right-click **Sites** and **Add Website**.

![](/Attachments/Manually-installing-Orchard-zip-file/IISAddANewWebsite.png)

Write your site name and point **Physical path** to your *Orchard* folder. Click **Ok**.

![](/Attachments/Manually-installing-Orchard-zip-file/IISAddWebsiteScreen.png)

Click **Yes** in the warning dialog about two sites using port 80.

![](/Attachments/Manually-installing-Orchard-zip-file/IISPort80Conflict.png)

Your website is running now. Click **browse** to navigate to it.

![](/Attachments/Manually-installing-Orchard-zip-file/IISBrowseToSite.png)

You should see the Orchard setup screen in your browser.

# Running the Site Using WebMatrix and IIS Express

Download the _Orchard.Web.1.x.xx.zip_ file from [here](https://github.com/OrchardCMS/Orchard/releases/latest). Extract the Orchard .zip file to a local folder. Launch WebMatrix, and in the **Quick Start** screen, click **Open** and then **Folder**.

![](/Attachments/Manually-installing-Orchard-zip-file/IISWMOpenFolder.png)

 Navigate to the folder where you extracted the .zip file, select the folder named **Orchard**, and then click **Select Folder** to open the site.

![](/Attachments/Manually-installing-Orchard-zip-file/IISWMSelectFolder.png)

To run the site, in the WebMatrix **Files** workspace, select the root **Orchard** folder. Click the drop-down list in the **Run** button and then select a browser.

![](/Attachments/Manually-installing-Orchard-zip-file/IISWMRun.png)

You should see the Orchard setup screen in your browser.

# Running the Site Using Visual Studio and the Visual Studio Development Server
*This procedure was tested with Visual Studio 2013 Update 1.*

Altough you can run the precompiled version of Orchard in Visual Studio, you will find much easier to work in Visual Studio with the full source code version. 
Download the full source code from [here](https://github.com/OrchardCMS/Orchard/releases/latest). Extract the .zip file to a local folder.

![](/Attachments/Manually-installing-Orchard-zip-file/contents_of_source_zip_file.png)

 Launch Visual Studio and select **File** > **Open** > **Project/Solution**. Navigate to the folder where you extracted the .zip and open the folder named **src**. Select the **Orchard.sln** solution file.

![](/Attachments/Manually-installing-Orchard-zip-file/VSOpenSolution.PNG)

To run the site, press Ctrl+F5. You should see the Orchard setup screen in your browser.

# Setting Up a Site

When you first launch the Orchard site, you are presented with the Orchard setup screen: 

![](../Upload/screenshots/get_started_dialog_1.png)

By default, Orchard includes a built-in database that you can use without installing a separate database server. If you choose this option then you don't need to configure the database at all. A mini version of SQL Server called SQL Server CE will be automatically run with your site. It keeps its data inside a database file that lives inside `App_Data`.  

However, if you are running SQL Server or SQL Server Express, you can configure Orchard to use either of those products instead by specifying a connection string. The database and user specified in the connection string must be created before you start the Orchard setup. Just create an empty database on your database server, create the user and that's it. Orchard will set up all of the tables and data automatically for you during the setup process.
 
Optionally, you can enter a table prefix so that multiple Orchard installations can share the same database but keep their data separate.

![](../Upload/screenshots_85/setup_sqlserver.png)

The Orchard setup screen includes a section where you can choose an Orchard recipe. You can choose from the following Orchard recipes:

* **Default**. Sets up a site with frequently used Orchard features.
* **Blog**. Sets up a site as a personal blog.
* **Core**. Sets up a site that has only the Orchard framework for development use.

![](../Upload/screenshots/get_started_recipe.png)

For information about recipes and how to make a custom recipe, see [Making a Web Site Recipe](http://orchardproject.net/docs/Making-a-Web-Site-Recipe.ashx). 

After you've entered the required information on the setup screen, click **Finish Setup**. When the setup process is complete, your new site's home page is displayed.

![](../Upload/screenshots_675/Install_finished.png)

You are now on the Orchard home page and can begin configuring your site.


# Change History
* Updates for Orchard 1.8
    * 4-9-14: Added screenshots and more detail to the IIS section. Updated Webmatrix screenshots. Changed a bit the structure of some paragraphs to make them clearer. Updated some links.
* Updates for Orchard 1.6
    * 11-07-12: Updated screens for 1.6 installation.
	* 4-12-11: Updated screens for 1.1 installation.
    * 3-14-11: Added section on using WebMatrix and IIS Express.
    * 3-14-11: Added information about recipes in the setup screen.
    * 3-15-11: Fixed the IIS section to use the Orchard subfolder from the zip.
	

