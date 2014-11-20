
If you do not want to use the Microsoft Web Platform Installer to install Orchard, you can download a .zip file that contains everything you need to in order use Orchard. This topic shows the steps you need to perform to install Orchard using the .zip file. For information about using the Web Platform Installer, see [Installing Orchard](Installing-Orchard).

> **Note**: If you plan to use Visual Studio 2010 to develop your Orchard site, we recommend that you install Visual Studio, and the ASP.NET MVC 3 Tool Update, before installing Orchard. If you plan to use WebMatrix to develop your site, you may want to see the topic [Installing Orchard](Installing-Orchard), which installs Orchard from the Web Platform Installer and includes WebMatrix in the installation. Also, if you previously installed pre-release versions of WebMatrix, ASP.NET Web Pages, or ASP.NET MVC 3, you must uninstall those or upgrade those products to the final release of each before Orchard will run correctly on your computer.



# Downloading the .zip File

Download the Orchard [.zip file](http://orchard.codeplex.com/releases/view/90325) from CodePlex. Select the **Orchard.Web.1.x.xx.zip** file for the latest build of Orchard, as shown in the following illustration:

![](../Upload/screenshots/Install_downloadzip.png)

The website is in the "Orchard" folder that's included in the .zip file.

You can run your downloaded Orchard site using IIS, WebMatrix and IIS Express, or Visual Studio and the Visual Studio Development Server. The site has already been built and can be run without additional compilation.
//Orchard 1.6 - Running the Site Using IIS section still needs to be verified 11/12/2012
# Running the Site Using IIS

To use IIS, extract the contents of the _Orchard_ folder from the .zip file to an IIS virtual directory (or site root), and then view the site using a browser. If you are using IIS 7, configure it to run in integrated mode, and configure the application pool to run the .NET Framework version 4.

You might have to set read/write permissions for the account that is configured as the identity for the IIS application pool on the following folders:

* _Modules_. This is required if you want to install modules from the gallery. (We recommend that you remove the read/write permissions for production sites.)
* _Themes_. This is required if you want to install themes from the gallery. (We recommend that you remove the read/write permissions for production sites.)
* _App_Data_. This folder is where Orchard stores site settings.  
* _Media_. This folder is where Orchard stores media files (images, etc.).

If you want to completely reset an Orchard site configuration to its default settings, you can delete the _App_Data_ directory. This removes all your custom settings, users, and configuration, as well as any custom data you have added to the site. If you delete the _App_Data_ folder, and if you want to remove custom images that you have added to the site, you can delete the _Media_ folder as well.

# Running the Site Using WebMatrix and IIS Express

To use WebMatrix and IIS Express, extract the Orchard .zip file to a local folder. Launch WebMatrix, and in the **Quick Start** screen, click **Open Site** and then **Folder as Site**.

![](../Upload/screenshots_675/webmatrix_sitefromfolder_675.png)

 Navigate to the folder where you extracted the .zip file, select the folder named **Orchard**, and then click **Select Folder** to open the site.

![](../Upload/screenshots_675/webmatrix_selectfolder_675.png)

To run the site, in the WebMatrix **Files** workspace, select the root **Orchard** folder. Click the drop-down list in the **Run** button and then select a browser.

![](../Upload/screenshots_675/webmatrix_run_orchard_675.png)

# Running the Site Using Visual Studio and the Visual Studio Development Server

To run the site in Visual Studio, extract the full source code .zip file to a local folder.

![](../Upload/screenshots_675/contents_of_source_zip_file_675.png)

 Launch Visual Studio and select **File** > **Open** > **Project/Solution**. Navigate to the folder where you extracted the .zip and open the folder named **src**. Select the **Orchard.sln** solution file.

![](../Attachments/Manually-installing-Orchard-zip-file/OpenSolution.PNG)

To run the site, press Ctrl+F5.

# Setting Up a Site

When you first launch the Orchard site, you are presented with the Orchard setup screen: 

![](../Upload/screenshots/get_started_dialog_1.png)

By default, Orchard includes a built-in database that you can use without installing a separate database server. However, if you are running SQL Server or SQL Server Express, you can configure Orchard to use either of those products instead by specifying a connection string. The database and user specified in the connection string must be created before you start the Orchard setup.  Optionally, you can enter a table prefix so that multiple Orchard installations can share the same database but keep their data separate.

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
* Updates for Orchard 1.6
	* 11-07-12:  Updated screens for 1.6 installation.
	* 4-12-11: Updated screens for 1.1 installation.
    * 3-14-11:  Added section on using WebMatrix and IIS Express.
    * 3-14-11:  Added information about recipes in the setup screen.
    * 3-15-11:  Fixed the IIS section to use the Orchard subfolder from the zip.

