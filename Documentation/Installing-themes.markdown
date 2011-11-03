
There are two ways to add a theme to Orchard. The first and easiest is to use the **Gallery** tab on the **Themes** page in the dashboard to browse and install themes from an online feed of available themes. The second is to go to the dashboard **Themes** page and click the link to install a theme, which allows you to browse for a theme package on your local computer and install it.

> **Note** If your site is running under IIS, make sure you have granted read/write permissions to the _~/Themes_ folder under the root of your site for the service account that is being used as the IIS application pool identity. However, you should remove the write permissions on a production server.


# Installing a Theme from the Gallery

When the gallery feature is enabled, as it is by default in Orchard, a **Gallery** tab appears at the top of the both the **Themes** screen and the **Modules** screen in the dashboard. 

![](../Upload/screenshots/Themes_gallery_enabled.png)

> Note:  If the gallery feature has been disabled, there will be no **Gallery** tab visible in the **Themes** or **Modules** dashboard screens. To enable a disabled gallery, click **Modules** in the dashboard, and click **Enable** on the Gallery feature. 

In the **Themes** screen of the dashboard, click the **Gallery** tab. A set of themes appears with a pair of **Install** and **Download** links next to each theme. 

![](../Upload/screenshots_675/Gallerythemes_installing_675.png)

To install a theme in your site, click the **Install** link next to the theme. Installing a theme adds it to your site in the **Available** list of themes on the **Themes** page in the dashboard. From there, you can preview a theme or set it as the current site theme, as described [Previewing and Applying a Theme](Previewing-and-applying-a-theme).

# Installing a Theme from your Local Computer

To install a theme from your local computer, in the **Themes** screen of the dashboard, click the link to **Install a theme from your computer**. This displays a screen that lets you install a theme.

![](../Upload/screenshots/themes_installnew_upload.png)

Browse to a local package file that contains a theme (the file will have a _.nupkg_ extension), select it, and then click **Install**.  The theme package is installed in your site, and you will see the theme listed in the **Available** section of the **Themes** screen. 

> **Note**  A theme contains a number of files and folders packaged in a ZIP file that has a _.nupkg_ file extension. The packaging feature is provided by the NuGet package management system. Packaging themes and other add-ons is beyond the scope of this topic, but you can learn more at [http://nuget.codeplex.com/](http://nuget.codeplex.com/).

The following illustration shows the Terra theme, which was previously downloaded to the local computer from the Gallery, after clicking the **Install a theme from your computer** link and installing it to an Orchard site. The installed theme appears in the **Available** section.

![](../Upload/screenshots_675/theme_addLocal_install_675.png)

To use an example theme to test this feature, download an existing theme from the **Gallery** tab on the **Themes** page, then browse to the saved _.nupkg_ file on your computer and install it as described previously.

When a theme is installed, the theme files are placed in the _~/Themes_ folder. You can see the installed themes in your site by checking the **Available** section on the **Themes** page in the dashboard. For more information about how to preview themes and apply them to your site, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme).
  
  
  

# Change History
* Updates for Orchard 1.1
    * 3-21-11:  Updated screen shots and text for installing themes. 


