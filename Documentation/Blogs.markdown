

# Initial feature set

## Post Creation & Administration
This feature makes it possible to create new blog posts as well as find and edit existing ones (see scenarios below). This should be a consistent  user experience with [CMS page](pages).

## XML-RPC / Live Writer Integration
The existing [XML-RPC features](xml-rpc) will be extended to work for blog posts.

## Media Integration
The existing [media management](media-management) features will be integrated into the blog post editing experience (including Live Writer).

## Drafts
Blog post drafts will be implemented in a way that is consistent with [CMS page](pages) drafts.

## Scheduled Publication
Scheduled publication of blog posts will be implemented in a way that is consistent with [CMS page](pages) scheduled publication.

## Multi-blog / Multi-author
This feature could potentially be postponed, but if implemented it enables multiple authors to maintain multiple blogs. A given author can create more than one blog, and a given blog can be contributed to by more than one author.

The simple [permission model](users) may need to be modified to enable authorship delegation, or this can be implemented as an ad-hoc feature.

## Archives
The list of posts can be displayed by month. A list of past months with the number of posts for each month can be displayed.

## Linkback: trackback, pingback and refback
[Linkback](http://en.wikipedia.org/wiki/Linkback) is a generic term that describes one of the three current methods to manage posts linking to each other across blogs.

The blog package should send trackbacks when a post gets created, and should receive refbacks, trackbacks and pingbacks. It should put all three through spam filters and should provide admin UI to manage the linkbacks and configure their moderation (moderation required or not, etc.).

## Related aspects
A few features that are necessary for any blog engine will be implemented as aspects that can be applied to other content types in addition to blog posts.

### List of Posts
Lists of content items need to be implemented for the blog front-end to work. This will be implemented as part of this iteration.

### RSS/Atom
All lists in the application should be exposed as alternate views that conform to RSS and Atom.

### Comments
Comments will be implemented with the bare minimum features (name, URL, e-mail, text, date). We will implement spam protection to an external service such as Akismet, and make it swappable in a future iteration.  We will also support authenticated comments (captring user name for comments when a user is logged in).

The implementation is described in [comments](comments).

### Tags
Tagging is described in [Tags](Tags).

### Search
Search will not be implemented in the initial blog iteration but will be added later as a cross-content-type aspect.

### Themes
Themes will be implemented for the whole application in a later iteration.

### Plug-ins
Plug-ins will be implemented in a future iteration and will be retrofitted into the existing blog code.

### Background tasks
Background tasks will be implemented in this iteration and will be retrofitted where relevant into the existing pages code.

### Widgets
Widgets will be implemented in a future iteration and will be retrofitted where relevant into the existing blog code.

## Future features

### BlogML import and export
This will provide a migration path to and from Oxite and other blogging engines.

# Permissions
Here, owner means the post owner if acting on a post, the blog owner if creating a post, and the site owner when creating a blog.

Permission                                       | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
View Posts                                       | Yes   | Yes        | Yes   | Yes    | Yes    | Yes
Create & Manage Blogs                            | No    | No         | Yes   | Yes    | No     | No
Create & Manage Posts (implies all others)       | No    | No         | Yes   | Yes    | Yes    | No
Create Drafts                                    | No    | No         | Yes   | Yes    | Yes    | No
Modify/Delete posts                              | No    | No         | Yes   | Yes    | Yes    | Yes
Publish/Unpublish/Schedule posts                 | No    | No         | Yes   | Yes    | Yes    | Yes

Additional permissions may apply to aspects such as comments or tags.
