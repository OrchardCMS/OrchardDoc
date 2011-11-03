
You can configure the general, global, and feature-specific settings for your site in the **Settings** panel (the menu items contained in the  **Settings** section) of the Orchard dashboard. This topic describes these site-level settings. 

In the **Settings** panel in the dashboard, the settings are arranged into categories, including **General**, **Gallery**, **Comments**, **Media**, and **Users**.

![](../Upload/screenshots/dashboard_sitewide_settings.png)


## General Settings
To access general settings, click **General** in the **Settings** panel. This opens the following screen:

> **Note** The general settings screen also displays options that are specific to the features that are enabled for your site. 

![](../Upload/screenshots_675/manage_general_settings_675.png)

In the general settings category, you can modify the following global and site-wide settings: 

* **Site Name**. The name of your site, which is usually displayed by the applied theme. 
* **Default Site Culture**. The default culture for the site.  You can also add culture codes here. For more information, see [Creating Global-Ready Applications](Creating-global-ready-applications).
* **Page title separator**. The character that is used to separate sections of a page title. For example, the default separator character for the `en-US` locale is a hyphen (-).
* **Super user**. A user who has administrative capability on the site, regardless of configured roles. This is usually the user who ran the Orchard installation and setup. The default user is the admin account. 
* **Resource Debug Mode**. The mode that determines whether scripts and style sheets are loaded in a "debuggable" form or in their minimal form.
* **Default number of items per page**. On pages that can show multiple items (like a blog page with blog posts), the default number of items that are shown per page.
* **Base URL**. The base URL for your site.

## Gallery Settings
To access settings for the gallery, click **Gallery** in the **Settings** panel. This opens the following screen:

![](../Upload/screenshots_675/manage_gallery_feed_settings_675.png)

In the gallery feed settings, you can add or delete a feed using the following settings:

* **Add Feed**. Lets you specify the URL to a gallery feed.
* **Delete**. Lets you remove an existing gallery feed.

For more information about how to add feeds to the gallery, see [Registering Additional Gallery Feeds](Module gallery feeds).

## Comments Settings
To access settings for comments, click **Comments** in the **Settings** panel. This opens the following screen: 

![](../Upload/screenshots_675/manage_site_comments_settings_675.png)

In the comments settings, you can enable or disable the following features:

* **Comments must be approved before they appear**. Requires user comments to be approved by an administrator or moderator before they become visible on the site. 
* **Enable spam protection**. Automatically identifies spam comments and marks them for your review.

For more information about how to work with comments, see [Moderating Comments](Moderating-comments).

## Media Settings
To access settings for what types of files can be uploaded on a site, click **Media** in the **Settings** panel. This opens the following screen:

![](../Upload/screenshots_675/manage_site_media_extensions_675.png)

In the media settings, you can specify the following options:

* **Media**. A space-delimited list of file extensions that can be uploaded (for example, `jpeg gif png txt doc docx xls xlsx`). Do not include a dot (.) as part of the extension.

## User Settings
To access user settings, click **Users** in the **Settings** panel. This opens the following screen:

![](../Upload/screenshots_675/manage_site_user_settings_675.png)

In the user settings, you can enable or disable the following settings in order to customize user registration:

* **Users can create new accounts on the site**. Configures the site to let users create a new account.
* **Display a link to enable users to reset their password**. Provides users with a way to reset their password.
* **Users must verify their email address**. Requires users to confirm their email address during registration.
* **Users must be approved before they can log in**. Requires administrative approval of new accounts before users can log in.

  
  
  

# Change History

* Updates for Orchard 1.1
    * 3-29-11: Added sections for new screens in the dashboard.  Updated existing screen shots. 


