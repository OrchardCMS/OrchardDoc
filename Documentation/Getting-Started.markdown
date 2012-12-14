This walkthrough provides a glimpse of the features that Orchard has to offer, provided as a step-by-step guide. If this is your first time using Orchard, this document is for you!

This topic assumes that you have already installed Orchard and set up your website. If you haven't, follow the instructions in [Installing Orchard](Installing-Orchard).

### Changing the layout of the Home Page

Out of the box, Orchard applies a theme to your website known as the "Theme Machine".  The Theme Machine includes CSS styles and a layout. Orchard allows you to selectively include or exclude portions (zones) of the layout on each page of your website. 
By default, the zones highlighted in blue are enabled on the home page.

![](../Upload/screenshots_675/ThemeZonePreview_homepage_675.png)

The **Navigation** zone contains a menu with a single tab, *Home*. The **TripelFirst, TripleSecond** and **TripleThird** zones at the bottom of the page are populated with dummy text in the *First Leader Aside*, *Second Leader Aside* and *Third Leader Aside* paragraphs.  

In addition to zones, every page has a central region (In this case, the text from *"Welcome to Orchard"* to *"Thank you for using Orchard"*) which, for this tutorial, will be referred to as the **Body** of the page. 

![](../Upload/screenshots_675/homepage_before_contextual_edits_675.png)

Although the Theme Machine has many possible zones defined, on a given page the only zones visible will be zones that have had widgets added to them (you can learn more about widgets [here](Managing-Widgets)). The Navigation, TripelFirst, TripelSecond and TripelThird zones are visible on the home page because they contain widgets.

**1)** Select **Widgets** from the Dashboard.  

The Widgets management page opens with the *Default* layer selected.  Any zone that is visible in the Default layer will appear on all pages. Therefore, the *Navigation* zone is visible on
all web pages and has a **Main Menu** widget.  The Main Menu widget is annotated in green because it has been added to a zone in the **current layer**.  

![](../Upload/screenshots_675/widgets_default_layer_675.png)

**2)** Select the **HomePage** layer to see which zones are visible for the home page.  

Widgets which have been added to zones in the selected layer will be annotated in green (FirstLeaderAside, SecondLeaderAside and ThirdLeaderAside).  Widgets which have been added to zones in other layers will be annotated in gray (Main Menu).

![](../Upload/screenshots_675/homepage_layer_selection_675.png)

![](../Upload/screenshots_675/homepage_layer_675.png)

 
The TripelFirst, TripelSecond, and TripelThird zones on the home page have widgets in them and are visible. Removing all of the widgets in a zone will make the zone invisible.  


**3)** Select **Remove** for the **Third Leader Aside** widget.

![](../Upload/screenshots_675/homepage_tripelthird_675.png)

The TripelThird zone will no longer be visible on the home page.

![](../Upload/screenshots_675/homepage_remove_tripelthird_675.png)

**4)** Select **Add** for the TripelThird zone to add a widget to the zone.
![](../Upload/screenshots_675/homepage_add_tripelthird_675.png)

**5)** Select the **HTML Widget** to add this type of widget to the TripelThird zone.
![](../Upload/screenshots_675/homepage_choose_widget_675.png)

**6)** Enter a title for your widget and some content.

![](../Upload/screenshots_675/homepage_new_thirdleaderaside_675.png)

**7)** **Save** the new widget.

**8)** Select **Your Site** in the upper-left side of the Dashboard to view the modified home page with the new TripelThird zone.
![](../Upload/screenshots_675/homepage_modified_thirdleaderaside_675.png)

### Editing the content of the Home Page

Orchard provides a feature that makes it easy for you to edit the content in a zone or the page body.  To turn on this feature you must enable the **Content Control Wrapper** and **Widget Control Wrapper** modules 

**1)** Select **Modules** on the Dashboard.

**2)** Enable **Content Control Wrapper**

**3)** Enable **Widget Control Wrapper**

![](../Upload/screenshots_675/enable_content_control_675.png)

Once these modules are enabled, you can edit the contents of an individual zone by clicking the **Edit** link (at the top right) in the zone.  

![](../Upload/screenshots_675/home_page_675.png)

**4)** Select the **Edit** link for the *TripelFirst* zone of the home page. 

**5)** Change the title, and optionally, change or remove the existing body text for the zone.  

**6)** Select **Insert/Update Media**. 

![](../Upload/screenshots_675/edit_widget_media_1_675.png)

**7)** Browse to an image file on your computer and select **Upload** to upload it to your Orchard site.

![](../Upload/screenshots/pick_image.png)

**8)** Select **Insert** to insert it into the TriplelFirst zone.

> **Note:** Before you insert the uploaded image, it is helpful to specify width and height attributes for the image, for example 200 pixels wide by 150 pixels high, so that the image fits correctly into its zone. 

**9)** Select **Save** to save the changes to the widget. The home page is automatically displayed with the updated zone.

![](../Upload/screenshots_675/edit_widget_tulip_675.png)

**10)** Select the **Edit** link for the **Body** of the page.

![](../Upload/screenshots_675/edit_body_675.png)

 Orchard will display the **Edit Page** screen.
 > **Note:** The Edit Page screen can also be reached from the Dashboard by selecting **Content** on the Dashboard and then selecting **Edit** for the page you are interested in.

 **11)** Enter some text for the content. 

![](../Upload/screenshots_675/edit_homepage_675.png)

**12)** Select **Publish Now** at the bottom of the page to make the updates to the page visible immediately.

![](../Upload/screenshots_675/publishnow_homepage_675.png)


### Adding a New Page to Your Site

**1)** In the Orchard Dashboard, under **New**, select **Page**.

**2)** Enter a title for the page.  When you enter a title for the page (for example, "Download"), the permalink (URL) for the page is filled in automatically ("download").  You can edit this link if you prefer a different URL.

**3)** Enter some text for the content page body.

![](../Upload/screenshots_675/create_new_page_0_1_675.png)


**4)**  In the **Tags** field, add comma-separated tags such as "download" and "Orchard" so that you can search and filter using those tags later. 

**5)** Check **Show on main menu** and enter the menu text ("Downloads") to use in the site's main menu.

**6)** Select **Publish Now** to make the page to make the updates to the page visible immediately. You can also save the page as a draft (to edit later before publishing), or you can choose to publish the page at a specific date and time.

![](../Upload/screenshots_675/create_new_page_1_1_675.png)

 When you publish the page, you will be offered the opportunity to create a new Widget Layer for the page.

**7)** Select **add a widget layer** to add a new layer for this page which will allow you to customize the layout for the new page at a later point in time.

![](../Upload/screenshots_675/create_new_page_1_2_675.png)

**8)** Select **Save** which will create the new layer with the default settings.

![](../Upload/screenshots_675/create_new_page_2_2_675.png)

**9)** Select **Your Site** in the upper-left side of the Dashboard to view the updated website.

Notice that the **Downloads** tab has been added to the main menu, and that you can select the tab to view your page. Also notice that the new page has a different layout from the home page.  The only zones visible on the new page are the zones (Navigation) made visible by the Default layer.  To make additional zones visible only on the Download page, you must add widgets to zones in the Download layer.

![](../Upload/screenshots_675/website_new_page_added_675.png)

 


### Selecting a Theme

To customize the look and feel of the Orchard website you change the theme. 

**1)** On the Orchard Dashboard, select **Themes**.  The currently installed themes are listed. 

**2)** To download new themes, select the **Gallery** tab.

**3)** Search for **Contoso** to find the Contoso Theme. Install the **Contoso** theme.

**4)** Select the **Installed** tab. 

After a theme has been installed it appears as an option in the **Available** section on the **Installed** tab. In the following illustration, the **Contoso** theme has been installed so it appears in the **Available** section. (The current theme for the site is **The Theme Machine**.) 

**5)** To see how your site will look with an available them,  select **Preview** for the theme.  To apply an available theme to your site select **Set Current** for the theme. For more details, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme) and [Installing Themes](Installing-themes).

![](../Upload/screenshots_675/themes_manage_1_675.png)


### Extending Orchard with Modules and Features

A key feature of Orchard is the ability to add new features in order to extend the functionality of your site. The primary way to do this is by installing modules. You can think of a module as a package of files (in a .zip folder) that can be installed on your site. To view the modules that are included with Orchard, in the Orchard Dashboard, click **Modules** and then click the **Installed** tab in the **Modules** screen.

![](../Upload/screenshots_675/installed_modules_1_675.png)

Orchard provides some built-in modules, and you can install new modules. For details, see [Installing and Upgrading Modules](Installing-and-upgrading-modules) and [Registering additional gallery feeds](Module gallery feeds).

Individual modules can expose features that can be independently enabled or disabled. To view the features exposed by the built-in modules in Orchard, click the **Features** tab in the **Modules** screen.  

![](../Upload/screenshots_675/features_link_675.png)

Each feature has an **Enable** or **Disable** link (depending on its current state), as well as an optional list of dependencies that must also be enabled for a specific feature. The documentation throughout this site describes the variety of features in Orchard and how you can use them to customize your site's user interface and behavior.
  

### Change History
* Updates for Orchard 1.6
	* 11-25-12:  Added section describing how to change the layout for a page by enabling/disabling zones.  Removed section on Creating a Blog (which already has it's own topic).
* Updates for Orchard 1.1
    * 3-14-11:  Updated screen shots showing updated menus, and updated dashboard and settings options. 
