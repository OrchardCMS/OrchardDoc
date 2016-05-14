*This topic targets, and was tested with, the Orchard 1.8 release.*

Orchard provides a blogging engine that makes it easy to add a blog to your web site.
This topic describes how to create a blog for your site, add a new blog post, and then setup comments and tags.

### Add the Blog

On the Orchard dashboard expand the **Blog** submenu. Then click **New Blog**.
In the *New Blog* screen add a title, description, and menu text for the blog and click **Save**.

![](../Attachments/Adding-A-Blog-To-Your-Site/NewBlog.png)

 A page for managing the blog is displayed.
> Note: You can have several blogs in the same Orchard site.

![](../Attachments/Adding-A-Blog-To-Your-Site/ManageBlog.png)

### Add a post to the Blog

Click **New Post** to create a new blog entry. The **New Blog Post** screen is displayed. Enter a title for your post and the post contents.

![](../Attachments/Adding-A-Blog-To-Your-Site/NewPost1.png)

Enter tags (separated by commas) to your blog post in the **Tags** field. Check **Show comments** , **Allow new comments** and **Allow threaded comments**. Click **Save** to save it as a draft.

![](../Attachments/Adding-A-Blog-To-Your-Site/NewPost2.png)

In the dashboard, click **Blog** to view the list of posts in the blog.  In the list of posts, the new post is saved as a draft, which means it is not yet visible to visitors of the site.  Click **Publish** to allow site visitors to see the post.

![](../Attachments/Adding-A-Blog-To-Your-Site/PublishPost.png)

A screen shows that the post was published successfully.   

![](../Attachments/Adding-A-Blog-To-Your-Site/PublishedPostNotification.png)

Click **Your Site** to view the site's home page again.

A new tab, **Blog**, has been added to the menu. Click the **Blog** tab which will display the blog and the new the post.  To see more details about the new post, click the **more** link at the end of the post content.

![](../Attachments/Adding-A-Blog-To-Your-Site/WebsiteBlog.png)

### Add a comment to the post

Because comments were enabled for the post, a new comment can be entered.  The comment may not appear immediately after it is submitted.  That is because Orchard has a setting which requires the site administrator to approve comments before they are published.

![](../Attachments/Adding-A-Blog-To-Your-Site/PostComment.png)

Return to the Orchard dashboard and under **Settings**, click **Comments**. There are two options which effect how comments are handled. One to require administrator approval before a comment is published, and another option for enabling automatic closing of comments for old posts. For more details about these features, see the [Moderating Comments](Moderating-comments) topic.
> Note: There are several good modules in the [Orchard Gallery](http://gallery.orchardproject.net/) to enable spam protection in your blog.

![](../Attachments/Adding-A-Blog-To-Your-Site/CommentsSettings.png)

### Using Tags in blogs

Orchard provides the ability to browse content by the tags that are added to the content. Click one of the tags (for example, "Orchard") in the blog post to see a list of all content that has that tag.  For more information about managing tags, see [Organizing Content with Tags](Organizing-content-with-tags).

![](../Attachments/Adding-A-Blog-To-Your-Site/PostsByTag.png)

Notice the URL for browsing tagged content as well.  

![](../Attachments/Adding-A-Blog-To-Your-Site/PostsByTagUrl.png)

If the URL is shortened to just the _/Tags/_ portion, the list of tags used in your site is displayed.

![](../Attachments/Adding-A-Blog-To-Your-Site/AllTheTags.png)

### Change History
* Updates for Orchard 1.8
	* 4-25-14:  New Screenshots. Comment settings are different. You can add many blogs.
* Updates for Orchard 1.6
	* 11-25-12:  Broke into multiple sections.


