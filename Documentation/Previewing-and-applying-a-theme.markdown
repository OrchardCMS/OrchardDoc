
Orchard provides a powerful but simple theming system for customizing the look and feel of your site. Orchard includes one theme in the default installation to help you get started. 


# Managing Themes

To manage themes, click **Themes** in the dashboard.

![](../Upload/screenshots_675/themes_start_675.png)

The main **Themes** screen defaults to the **Installed** tab, which displays the current theme, shows any other available themes, and lets you upload a new theme.  There are also tabs for the **Gallery** (which shows additional online themes you can install), **Updates** (which shows available updates for installed themes), and a link to **Install a theme from your computer** (use this to install a theme package from your local computer to your site). For more information on options for adding new themes, see [Installing Themes](Installing-themes).

To download and install additional themes, click the **Gallery** tab. Click **Install** on a theme to install it in your site. To see how themes work, install the **Contoso** and the **Classic** themes. 

![](../Upload/screenshots_675/GalleryThemes_1_675.png)

After you have installed a theme, click the **Installed** tab on the **Themes** screen. Any newly installed themes appear in the **Available** section. 

![](../Upload/screenshots_675/Themes_select_675.png)

As you can see from the links and buttons on the available themes, you have the following options for  each theme:

* **Preview**. Lets you preview a theme before you apply it. This lets you see how a theme will look on your site, but site visitors do not see the new theme until you apply it.
* **Set Current**.  Changes the current theme of the site to the selected theme.
* **Uninstall**.  Removes a theme from the **Available** themes section.
* **Enable**.  Used for two cases:  dependent themes and multiple themes. For dependent themes, you can create a set of themes that depend on each other (by specifying a **BaseTheme** value in the _Theme.txt_ file), so that activating that theme automatically enables the others. For multiple themes, you can enable several themes at once (even though only one theme is set as the current theme), which lets you dynamically change the current theme based on an incoming request. These are advanced topics that aren't covered here.
> **Note** You do not have to click the **Enable** link to carry out the other operations on themes, such as previewing a theme or setting the current theme.

# Previewing and Applying Themes

To experiment with the theme features, click **Preview** on an available theme.  The following illustration shows a site in preview mode for the **Contoso** theme. The drop-down list lets you preview other themes.

![](../Upload/screenshots_675/Themes_previewmode_675.png)

Click **Cancel** to exit preview mode and return to the **Themes** screen. 

> **Note:**  By default, a newly installed theme is not enabled. When you preview a theme it is automatically enabled. Only enabled themes are shown in the drop-down list of themes available for preview. 

Click **Set Current** on an available theme. The following illustration shows the **Themes** screen after you click **Set Current** on the **Contoso** theme. 

![](../Upload/screenshots_675/Themes_setcurrent_Contoso_675.png)

When return to the home page for your site, the new theme is applied to your pages. 
  
  
  

# Change History
* Updates for Orchard 1.1
    * 3-21-11:  Updated screen shots and reworked text for installing, applying, and previewing themes. 
