
When installing Orchard using the Web Platform Installer v3, you have the option to install to [WebMatrix](http://www.microsoft.com/web/webmatrix/) instead of IIS. WebMatrix, Microsoft's new one-stop web development tool, lets you create, edit, and publish websites with unprecedented ease. WebMatrix includes a built-in web server (IIS Express), along with a simple editor for editing and customizing applications like Orchard. 


## Installing and Launching WebMatrix

To install WebMatrix, download and launch the Microsoft Web Platform Installer. Then click the **Add** button for **Microsoft WebMatrix** and click **Install**.

![](../Upload/screenshots/Install_selectorWebMatrix.png)

Accept the license terms and launch WebMatrix when the installation finishes.

![](../Upload/screenshots_675/webmatrix_start_675.png)

## Installing Orchard within WebMatrix

To run Orchard from within WebMatrix, click **Site From Web Gallery** on the WebMatrix startup page (shown previously).  Scroll down and select **Orchard CMS**. Then click **Next**.

![](../Upload/screenshots_675/webmatrix_select_orchard_675.png)

Click **I Accept** to accept the EULA agreement.

![](../Upload/screenshots_675/webmatrix_orchard_eula_675.png)

Orchard is installed and a message is displayed saying the you have successfully installed Orchard. Click **OK**, and your Orchard site is opened in WebMatrix.

![](../Upload/screenshots_675/webmatrix_orchard_project_675.png)

## Launching Orchard for the First Time

The first time you launch your website, Orchard prompts you to enter some basic information about the site.

To launch Orchard, select the Orchard project node and then click **Run**.

![](../Upload/screenshots/webmatrix_run.png)

Orchard starts and prompts you for the name of the site, the name of a user, a password, and what kind of a database to use for site data.

![](../Upload/screenshots/setup_new_site.png)

Enter the information and click **Finish Setup**. Orchard sets up your initial site and opens the site's home page.

![](../Upload/screenshots_675/new_default_site_675.png) 


## Working with Files

You can use WebMatrix to edit the files in your Orchard installation. WebMatrix provides a simple editor that includes colorization for HTML, CSS, JavaScript, and code files. 

![](../Upload/screenshots_675/webmatrix_files_675.png)

Although WebMatrix does not provide a build system for compiling code files, Orchard itself provides dynamic compilation for code files when they are edited. For more information, see [Orchard Dynamic Compilation](Orchard-module-loader-and-dynamic-compilation).

## Working with the Database

After you run Orchard for the first time and complete the setup, your site is configured to use a database. If you selected **SQL Compact** for the the database option in Orchard setup, you can open the **Databases** workspace in WebMatrix to view the SQL Server Compact database tables.
 
![](../Upload/screenshots_675/webmatrix_database_675.png)

(If you were already in the **Databases** workspace, you might need to right-click the Orchard node and then click **Refresh** in order to display the database and tables.)

![](../Upload/screenshots/db_refresh.png)

## Publishing Your Web Site

When you're ready to publish your website on the Internet, click the **Publish** button in the WebMatrix ribbon.

![](../Upload/screenshots/webmatrix_publish.png)

The first time you publish, the **Publish Settings** dialog box is displayed. 

![](../Upload/screenshots_675/webmatrix_publish_settings_675.png)

To publish a website, you must have an account with a web hosting provider. If you don't have one yet, you can click **Find web hosting**. This displays a web page where you can choose a hosting provider that supports WebMatrix publishing.

After you've set up an account with a hosting provider, the provider will typically send you an email with your user name, server name, and other information that goes into the **Publish Settings** dialog box. 

To save you the extra step of entering this information manually, the provider might send you a "Profile XML" file (named with the _.publishsettings_ extension) that contains this information. If you get one of these files, all you have to do is click **Import publish settings** and select the file, and you'll be ready to publish. Otherwise, you can enter the settings manually. 

At this point, you're ready to publish your website.
 
After you've published your site, you might want to make changes to it and republish it. WebMatrix makes it easy for you to download it from your hosting provider, edit it, and publish it again.
