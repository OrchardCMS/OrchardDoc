While Orchard provides a simple way to write blog posts using the built-in features of the admin panel, many people prefer to author posts using a client application, such as [Windows Live Writer](http://explore.live.com/windows-live-writer).  These clients use an XML-RPC interface to publish posts remotely, and offer additional capabilities like saving offline drafts (for example, to write your blog posts on an airplane and sync-up your site later).

To enable Remote Blog Publishing, click **Features** in the Orchard admin panel.

To use Windows Live Writer with Orchard, you need to enable the **Remote Blog Publishing** feature. To enable **Remote Blog Publishing** click the **Enable** link on the feature box. Note that if you haven't already created a blog on your site, you'll want to do so.

![](../Upload/screenshots_675/feature_enable_675.png)

Now, launch Live Writer from your **Start** menu in Windows.

![](../Upload/screenshots/live_writer.png)

Choose **Add blog account...** from the **Blogs** menu.

![](../Upload/screenshots/livewriter2.png)

Choose **Other blog service** from the available options and click **Next**.

![](../Upload/screenshots_675/livewriter3.png)

Type the URL to your Orchard blog, along with the admin user name and password that you defined when you set-up Orchard for the first time.

> Note: it is possible to publish using other XML-RPC aware client applications, but you might have to provide the URL of the xmlrpc endpoint rather than the blog URL. For example, http://myimaginaryorchardsite.com/xmlrpc.

![](../Upload/screenshots_675/livewriter4.png)

Live Writer will connect to your blog in order to read the XML-RPC capabilities that Orchard supports and download the current Theme (for previewing posts before publishing).  If you are prompted to create a temporary post during this step, select "Yes" in the dialog.

![](../Upload/screenshots_675/livewriter5.png)

After Live Writer is configured, click **Finish**.

![](../Upload/screenshots_675/livewriter6.png)

Write a title and some content for your blog post in the Live Writer editor area.

![](../Upload/screenshots_675/livewriter7.png)

You can also insert pictures to your post using the **Insert Picture** button on the toolbar.

![](../Upload/screenshots_675/livewriter8.png)

![](../Upload/screenshots_675/livewriter9.png)

To edit the URL for your post, select **View / Properties** in the Live Writer menu.

![](../Upload/screenshots_675/livewriter10.png)

The **Slug** input appears at the bottom of the editor, where you can type the portion of the URL that refers to this post.

![](../Upload/screenshots_675/livewriter11.png)

To preview your post in the context of the currently applied Theme in Orchard, select the **Preview** tab in Live Writer. When you are satisfied with the way your post looks, click the **Publish** button.

![](../Upload/screenshots_675/livewriter12.png)

Live Writer publishes your post, and will automatically load the URL for the post in your browser for viewing.

![](../Upload/screenshots/livewriter13.png)


