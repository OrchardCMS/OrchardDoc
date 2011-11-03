

# Supported tools

On Windows, the best choice for a blogging tool is [Windows Live Writer](http://windowslivewriter.spaces.live.com). On the Mac, [MarsEdit](http://www.red-sweater.com/marsedit/) and [Ecto](http://illuminex.com/ecto/) are fairly popular. Also of note is [ScribeFire](http://www.scribefire.com/), which is a FireFox extension that provides blog writing features right from the browser.

All of these tools support the MetaWeblog API (see below), so supporting MetaWeblog would give us instant support from all those tools.

# Publication protocols

There are many blogging APIs, but the most important are:

## MetaWeblog

The [MetaWeblog API](http://www.xmlrpc.com/metaWeblogApi) is by far the most common API to get implemented by blogs and publishing software. Supporting it pretty much gives instant and universal support. It is a superset of the Blogger API.

## WordPress

The [WordPress API](http://codex.wordpress.org/XML-RPC_wp) is an extended version of the Movable Type API. The WordPress API is interesting in that it also exposes the concept of page in addition to blog posts.

## Movable Type

The [Movable Type](http://www.sixapart.com/developers/xmlrpc/movable_type_api/) is a fairly minimal and limited API. WordPress uses an extended version of that API.

## Blogger

The [Blogger API](http://code.google.com/apis/blogger/docs/2.0/developers_guide_protocol.html) is Google's blogging API. MetaWeblog is a superset of the Blogger API.

## Atom Publishing Protocol

The [Atom Publishing Protocol](http://www.atomenabled.org/developers/protocol/atom-protocol-spec.php) is what comes closest to an "official" standard. It does go well beyond simply blogging and is closer to the needs of a general purpose protocol to publish contents.

## Recommendation

If we had to support only one format, MetaWeblog looks like the most universally supported one. On the other hand, it is rather poor in terms of features when compared with the WordPress API. For example, it doesn't have page support and is quite specialized to handle blog posts, which means that in order to use it as a more general publishing protocol, we might need to use some custom meta-data. The WordPress API might be a better choice because of the larger scope of the application. In addition to WordPress or MetaWeblog, Atom seems like a good investment for the future, and it does offer more CMS-friendly features than the others but client tool support is lacking. It might be a way in the future to achieve the universality that MetaWeblog or WordPress will make more difficult.

# Discoverability

To enable tools to discover what API the application supports, we should implement [Really Simple Discovery](http://tales.phrasewise.com/rfc/rsd) and the [Live Writer Manifest](http://msdn.microsoft.com/en-us/library/bb463260.aspx).

# Supported API capability

The Live Writer manifest enables a very granular implementation of the various APIs. The following table shows what set of APIs Orchard would support at first.

Those capabilities are being provided by modules (blog, pages, tags), not by the core application. For that reason, we will eventually enable modules to participate in the creation of the manifest. As a first step though, we will implement the manifest as a static list of capabilities (see [the LiveWriter Manifest documentation](http://msdn.microsoft.com/en-us/library/bb463260.aspx)).

API Capability                 | Orchard support | Expected behavior
------------------------------ | --------------- | -----------------------------------------------------------------------------
supportsPostAsDraft            | ?               | Respects the publish flag on metaWeblog.newPost and metaWeblog.editPost calls
supportsFileUpload             | ?               | Supports metaWeblog.newMediaObject
supportsExtendedEntries        | -               | Supports mt_text_more field of post struct
supportsCustomDate             | ?               | Supports explicit specification of dateCreated field of post struct
supportsCategories             | ?               | Supports categorization of posts using either a category array within the post struct or mt.setPostCategories
supportsCategoriesInline       | ?               | Supports categories field of post struct
supportsMultipleCategories     | ?               | Allows specification of more than one category per post
supportsHierarchicalCategories | -               | Supports wp.getCategories and wp.addCategory
supportsNewCategories          | -               | Supports the addition of new categories from the client via either inline specification (see below) or via the wp.addCategory method
supportsNewCategoriesInline    | ?               | Previously unused categories included within the categories field are automatically added
supportsKeywords               | -               | Supports mt_keywords field of post struct
supportsCommentPolicy          | ?               | Supports mt_allow_comments field of post struct
supportsPingPolicy             | -               | Supports mt_allow_pings field of post struct
supportsAuthor                 | ?               | Supports wp_author field of post struct
supportsSlug                   | ?               | Supports either wp_slug or mt_basname field of post struct
supportsPassword               | -               | Supports wp_password field of post struct
supportsExcerpt                | ?               | Supports mt_excerpt field of post struct
supportsTrackbacks             | -               | Supports mt_tb_ping_urls field of post struct
supportsPages                  | ?               | Supports WordPress page editing API: wp.newPage, wp.editPage, wp.getPage, wp.getPages, wp.getPageList, andwp.deletePage
supportsPageParent             | -               | Supports wp_page_parent_id field of page struct
supportsPageOrder              | -               | Supports wp_page_order field of page struct
supportsEmptyTitles            | -               | Allows empty string as a valid value for the title field of the post struct
requiresHtmlTitles             | -               | Title field is interpreted as HTML content rather than plain text
requiresXHTML                  | -               | Generate XHTML style markup by default
supportsScripts                | ?               | Allows embedded script within post content
supportsEmbeds                 | ?               | Allows object embeds within post content

Categories in the Live Writer manifest correspond to tags in Orchard.

Supporting custom date will mean for Orchard that that date gets translated into scheduled publication if the date is in the future, and to modifying the publication date on the post or page otherwise.

# Permissions

Default permissions:

Permission                                      | Anon. | Authentic. | Owner | Admin. | Author | Editor
----------------------------------------------- | ----- | ---------- | ----- | ------ | ------ | ------
Create and manage contents through XML-RPC APIs | No    | No         | Yes   | Yes    | Yes    | Yes

> **Note**: the specific rights for each content type and operation are also checked in addition to this right. If this right is not granted, none of the operations work
