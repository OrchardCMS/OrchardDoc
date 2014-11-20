
Orchard makes it easy to browse available modules and themes from an online gallery and install them using the Orchard dashboard.  This topic shows how to install both modules and themes from the gallery.

> **Note:** If your site is running under IIS, make sure you have granted read/write permissions to the ~/Themes folder under the root of your site for the service account that is being used as the IIS application pool identity. However, you should remove the write permissions on a production server.


# Accessing and Enabling the Gallery

The gallery feature is enabled by default in Orchard. When the gallery is enabled, a **Gallery** tab appears at the top of the both the **Themes** screen and the **Modules** screen in the dashboard. 

![](../Upload/screenshots/gallery_default_enabled.png)

> Note:  If the gallery feature has been disabled, there will be no **Gallery** tab visible in the **Themes** or **Modules** dashboard screens. To enable the gallery, click **Modules** in the dashboard, find the gallery feature, and then click **Enable** on the feature. 

# Installing a Theme from the Gallery

To access the gallery for themes, click **Themes** in the dashboard. On the **Themes** screen click the **Gallery** tab. A set of themes appears with a pair of **Install** and **Download** links next to each theme. 

![](../Upload/screenshots_675/themes_themeGallery_675.png)

If you install a theme, it becomes available to apply to your site. If you download a theme, you save the theme package file to your local computer. You can then use the **Themes** screen in the Orchard dashboard to install the downloaded theme package. For more information, see [Installing Themes](Installing-themes).

## Previewing and Applying an Installed Theme

After installing a new theme, you can preview, enable, and apply that theme to your site by clicking **Themes** in the dashboard. For more information, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme). 

# Installing a Module from the Gallery

To access the gallery for modules, click **Modules** on the dashboard and then click the **Gallery** tab. A set of modules appears with a pair of **Install** and **Download** links next to each module.

![](../Upload/screenshots_675/modules_browse_gallery_675.png)

As with themes, if you install a module it becomes available to use on your site. If you download a module, you save the module package file to your local computer. You can then go to the **Modules** screen on the dashboard, click the **Installed** tab, and then click **Upload** to install the module in an Orchard site. For more information about how to activate a module after installing it, see [Installing and Upgrading Modules](Installing-and-upgrading-modules) and [Enabling and Disabling Features](Enabling-and-disabling-features).

On the dashboard **Modules** screen, click the **Installed** tab. This tab displays all the modules that are installed in an Orchard site.

![](../Upload/screenshots_675/modules_installedtab_upload_675.png)

Notice that on every page in the **Installed** tab, there is a link that lets you upload a module package to the site.

# Displaying Additional Gallery Feeds

The **Gallery** tabs on the **Modules** page and the **Themes** page of the dashboard together display the aggregated list of themes and modules exposed by all feeds registered on your site. On the **Gallery** tabs for both themes and modules, you can use the **Feed** drop-down list to filter the display so that it shows all available items, or only the items from a selected feed. (This is only useful if you have multiple feeds registered.) 

![](../Upload/screenshots_675/modules_gallerytab_filterbyfeed_675.png)

By default, the [Orchard Gallery feed](http://orchardproject.net/gallery/) is registered for an Orchard site. To register additional gallery feeds see [Registering Additional Gallery Feeds](Module gallery feeds).

  
  
  

# Change History
* Updates for Orchard 1.1
    * 3-22-11:  Updated screen shots and menu or UI options. 


