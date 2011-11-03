
This walkthrough provides a glimpse of the features that Orchard has to offer, provided as a step-by-step guide. If this is your first time using Orchard, this document is for you!

This topic assumes that you have already installed Orchard and set up your website. If you haven't, follow the instructions in [Installing Orchard](Installing-Orchard).


### Customizing the Orchard Home Page

When you're logged in as an administrator, on the home page you'll notice the various zones that can contain content. By holding the mouse pointer over any of these zones and clicking the **Edit** link (at the top right), you can edit the content of the zone.  

![](../Upload/screenshots_675/home_page_675.png)

Click the **Edit** link for the main zone of the home page. Orchard displays the **Edit Page** screen, which provides a rich-text editor for customizing contents. 

![](../Upload/screenshots/edit_page_2.png)

Edit the page title, add some content for the site, and then click **Publish Now** at the bottom of the page. The home page is redisplayed.

Now you can add content to the zones at the bottom of the page. For purposes of this walkthrough, you'll add an image to each of the zones.

Click **Edit** for the zone named "First Leader Aside". The **Edit Widget** screen is displayed.

Change the title, and optionally, change or remove the existing body text for the zone.  Then click the **Insert/Update Media** button. 

![](../Upload/screenshots_675/edit_widget_media_1_675.png)

The **Pick Image** dialog box is displayed.  Browse to an image file on your computer and click **Upload** to upload it to your Orchard site.

![](../Upload/screenshots/pick_image.png)

After uploading the image, click **Insert** to insert it into the zone.

> **Note:** Before you insert the uploaded image, it is helpful to specify width and height attributes for the image, for example 200 pixels wide by 150 pixels high, so that the image fits correctly into its zone. 

Click **Save** to save the changes to the widget. The home page is displayed with the updated zone.

![](../Upload/screenshots_675/edit_widget_tulip_675.png)

Now edit each of the other "Aside" zones. Repeat the process of adding an image to each zone, so that all three zones on the bottom of the home page have an image.

After you have added an image to each "Aside" zone, inserted a title for each zone, and removed the body text from the zone, the updated home page looks like the following example:

![](../Upload/screenshots_675/playground_1_675.png)

### Adding a New Page to Your Site

Next, you'll add a new page to the site.  Click the **Dashboard** link at the bottom of the home page.

![](../Upload/screenshots/dashboard_link.png)

In the Orchard dashboard, under **New**, click **Page**. The **Create Page** screen is displayed.

![](../Upload/screenshots_675/create_new_page_0_1_675.png)

Fill in details for the new page.  When you enter a title for the page (for example, "Download"), the permalink (URL) for the page is filled in automatically ("download").  You can edit this link if you prefer a different URL.

![](../Upload/screenshots_675/create_new_page_1_1_675.png) 

Add some content to the page body and then fill in some of the other options, such as tags and comments. In the **Tags** field, add comma-separated tags such as "download" and "Orchard" so that you can search and filter using those tags later. If you select the **Show on main menu** check box, you can enter the menu text to use in the site's main menu.

![](../Upload/screenshots_675/create_new_page_2_1_675.png)

When you've finished customizing the new page, click **Publish Now** to publish it. You can also save the page as a draft (to edit later before publishing), or you can choose to publish the page at a specific date and time.

Now click the **Your Site** link in the upper-left side of the dashboard. This returns you to your home page so that you can view the changes to your site.

![](../Upload/screenshots/your_site_1.png)

Notice that the **Downloads** tab has been added to the main menu, and that you can click it to view your page. Also notice that the new page has a slightly different layout from the home page. Orchard provides the ability for pages to have different layouts. Some of the built-in themes use this feature to differentiate the home page and subpages.

![](../Upload/screenshots_675/playground_new_page_1_675.png)

### Adding a Blog to Your Site

Now you'll add a blog to the site. Return to the Orchard dashboard and click **Blog**. Orchard displays the **Create New Blog** screen.

![](../Upload/screenshots_675/blog_create_1_675.png)

Add a title, description, and menu text for the blog and click **Save**. A page for managing the blog is displayed.

![](../Upload/screenshots_675/blog_new_post_1_1_675.png)

Click **New Post** to create a new blog entry. The **Create New Blog Post** screen is displayed.

![](../Upload/screenshots_675/blog_new_post_2_1_675.png)

Creating a blog post is nearly the same as creating a page. Add some details for your post, such as a title, permalink, and body content. Also add some tags (separated by commas) to your blog post in the **Tags** field. Notice that the check box next to **Allow new comments** is checked by default. When you're done editing the post, click **Save** to save it as a draft.

In the dashboard, click **Manage Blog** to view the list of posts in your blog.  

![](../Upload/screenshots_675/blog_manage_1_675.png)

In the list of posts, you can see that the post is saved as a draft, which means it is not yet visible to visitors of your site.  Click **Publish** to allow site visitors to see the post.

A screen shows that the post was published successfully.   

![](../Upload/screenshots_675/publish_draft_post_675.png)

Click **Your Site** to view the site's home page again.

Click the **Our Blog** tab on the home page. This time, you can see a blog has been added to your menu and that the blog shows the post that you published.  

![](../Upload/screenshots_675/playground_blog_1_675.png)

### Using Comments and Tags

To see more details about the post, click the **more** link. Because you enabled comments for the post, you can enter a comment. 

![](../Upload/screenshots_675/blog_comment_1_675.png)

Orchard provides settings for moderating comments as well. Return to the Orchard dashboard and under **Settings**, click **Comments**. You see an option to require comments to be approved by an administrator before they appear, and another option for enabling spam protection. For more details about these features, see the [Moderating Comments](Moderating-comments) topic.

![](../Upload/screenshots_675/manage_settings_comments_1_675.png)

Orchard provides the ability to browse content by the tags that you define when you create content. Click one of the tags (for example, click "Orchard") to see a list of all content that has that tag.  For more information about managing tags, see [Organizing Content with Tags](Organizing-content-with-tags).

![](../Upload/screenshots_675/tagged_contents_1_675.png)

Notice the URL for browsing tagged content as well.  

![](../Upload/screenshots/tags2.png)

> **Note:** If you reduce the URL to just the _/Tags/_ portion, you can see a list of available tags in your site.

### Selecting a Theme

You probably want to customize the look and feel of your site. On the Orchard dashboard, click **Themes**. The **Themes** screen is displayed. You can also install new themes. To do that, go to the **Gallery** tab, install an additional theme, and then return to the **Installed** tab. After a theme has been installed it appears as an option in the **Available** section on the **Installed** tab. In the following illustration, the **Contoso** theme has been installed so it appears in the **Available** section. (The current theme for the site is **The Theme Machine**.) 

![](../Upload/screenshots_675/themes_manage_1_675.png)

Orchard makes it easy to preview installed themes. Try previewing an available theme, and then click **Set Current** to apply the theme to your site. For more details, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme) and [Installing Themes](Installing-themes).

### Extending Orchard with Modules and Features

A key feature of Orchard is the ability to add new features in order to extend the functionality of your site. The primary way to do this is by installing modules. You can think of a module as a package of files (in a .zip folder) that can be installed on your site. To view the modules that are included with Orchard, in the Orchard dashboard, click **Modules** and then click the **Installed** tab in the **Modules** screen.

![](../Upload/screenshots_675/installed_modules_1_675.png)

Orchard provides some built-in modules, and you can install new modules. For details, see [Installing and Upgrading Modules](Installing-and-upgrading-modules) and [Registering additional gallery feeds](Module gallery feeds).

Individual modules can expose features that can be independently enabled or disabled. To view the features exposed by the built-in modules in Orchard, click the **Features** tab in the **Modules** screen.  

![](../Upload/screenshots_675/features_link_675.png)

Each feature has an **Enable** or **Disable** link (depending on its current state), as well as an optional list of dependencies that must also be enabled for a specific feature. The documentation throughout this site describes the variety of features in Orchard and how you can use them to customize your site's user interface and behavior.

Try enabling a feature such as remote blog publishing. This feature lets the blog author create posts using a client application like [Windows Live Writer](http://explore.live.com/windows-live-writer). For more information about how to use this features, check out the [Blogging with LiveWriter](Blogging-with-LiveWriter) topic.

![](../Upload/screenshots_675/enable_remoteblog_675.png)

This concludes the Getting Started tutorial for Orchard. We hope we've captured your imagination and you've started thinking of ways to build your next awesome site.

  
  
  

### Change History
* Updates for Orchard 1.1
    * 3-14-11:  Updated screen shots showing updated menus, and updated dashboard and settings options. 
