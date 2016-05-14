
Orchard will provide an easy way for content type authors to expose new feeds and advertise them from a view.


# Requirements

* Feeds should strictly conform to the relevant standards.
* Any list of content items can be exposed as a feed.
* It is simple as possible to enable feeds on a list of contents, no matter what the type of content item is.
* Feeds should be able to contain heterogeneous content types.
* Feed contents should be easily extensible (for example by content parts).

# Feed rendering and why it's not just a view

When rendering an HTML page, there are potentially going to be multiple content items and multiple parts for each item, all contributing to the rendering. But whereas in HTML the rendering for each part are relatively isolated from each other, in the case of a feed, the contribution actually happens on the same tag. In other words, in HTML, each aspect results in an island of HTML that it owns, whereas in RSS, everyone parties on the same tags, and there is only one tag (and subtags) for each item.

Template-based rendering of XML does not provide significant benefits and in fact obscures the design. For example, if you want to let different (and unknown) parts of a content item contribute attributes to the top-level item element, you would need to inject a zone placeholder inside of the item tag.

XML manipulation APIs are mature and will enable much cleaner construction of the feed documents from many parts than the regular view template system would allow. The template system would end up generating XML fragment strings from C# code.

The target audience for building handlers that contribute to feeds is also different as HTML templates are usually written by designers whereas feed handlers will be written by content type or part authors, who are developers.

# Exposing contents as a feed

Orchard will provide a ready-made controller for RSS, Atom and other feeds. This controller will dispatch the request to registered feed handlers, providing them a context object. Each handler can decide whether to handle the request or not based on the information available on the context object. If it decides to handle the request, it can add feed items to the response object (a property of the context object).

Multiple handlers can independently contribute to a given feed, allowing for example the home page feed of a site to include items from a blogging module, a pages module and a forum module.

# Building a feed document from the list of feed items

The way the feed document is built is specific per feed type (RSS, Atom, etc.) and per content part. Feed item builder objects will be able to contribute to the document based on the feed item and the type of feed.

# Advertising a feed from a view

To be discoverable, feeds have to be advertised on the regular views that show the same data in HTML form. This advertising can be done as actual links in the HTML body, and as link tags in the header. The latter is the most important as it enables feed readers to discover the feeds automatically. The former is important to inform user who may not be aware of feeds.

The code that advertises a feed will be written in the display template for a specific container item. For example, the post feed for a blog will be advertised from the display template for the Blog object that also displays the list of posts.

The link tag advertising is done by calling Html.RegisterFeed(new {type="comment", parent=slug}, "Comment feed");. From that, Orchard will ask each feed provider (we will provide RSS and Atom) to create a link tag that will get added to the top-level zone subsection "header:link" (need to add that subsection to the existing styles and scripts).

To advertise the feed as an HTML link, a developer can call a Html.FeedLink helper. That helper, modeled after Html.ActionLink, creates a specialized A tag that already has the type="application/rss+xml" attribute and builds the URL to the feed.

A variation is to handle the whole markup from the view template and only get the URL from the Html.FeedUrl helper for maximum control over the link markup. It should be pointed out that this may make it more difficult down the road to easily modify how RSS links get rendered throughout the site. Because of that, we might want to introduce a display template for feeds that Html.FeedLink can use when it exists.

Feed advertising could be automatically done on all content item containers. This way, feeds would become automatically available for all lists of contents without any specific development. Enabling finer-grained configuration of feed availability could be added later.

# Lifecycle of a feed

* On a blog post page
    * Html.RegisterFeed(new {type="comment", parent=slug}, "Comment feed"); results in <link rel=rss href="/myapp/rss?type=comment&parent=my\-first\-post"/>.
* Navigating to that feed url is routed to the feed controller
    * controller retrieves the IEnumeration<IFeedHandler>
    * foreach IFeedHandler in the list, Invoke(FeedContext). FeedContext has a Request property that has route values and querystring.
*** The Invoke code contributes to ctx.Response.FeedItems (FeedItem has ContentItem and XElement, which is null for now).
*** controller gets the IEnumeration<IFeedBuilder> (there is one for each feed format: RSS, Atom, etc. and IFeedBuilder has a Format string property).
*** find the IFeedBuilder for the current format and call Invoke(FeedContext) on it. FeedContext has a Format string property so each IFeedBuilder can decide to participate. It also has an XDocument on the Response (null so far). The Invoke code creates the XDocument on context.Response if it doesn't exist and populates its top-level properties.
*** foreach FeedItem in context.Response.FeedItems, create the XElement on the FeedItem
*** foreach IFeedItemBuilder, Invoke(FeedContext, IFeedBuilder)
**** The feed builder invocation enumerates foreach FeedItem and maps ContentItem to XElement as appropriate when the format is recognized, or dumps data by calling back into IFeedBuilder.AddProperty(string name, string value, FeedItem). The feed builder can then choose to format that data in a generic way or throw the data away.
*** The XDocument is now complete. The feed builder returns an ActionResult.
    * The controller returns the ActionResult it got back from the feed handler.
* ActionResult gets executed, resulting in an XML string, a JSON string or even possibly it could be injected into the view engine if a "regular" ActionResult was returned.

# Object model

## FeedContext

* FeedRequest Request {get;set;}
* FeedResponse Response {get;set;}

## FeedRequest

* RouteData RouteData {get;}
* HttpRequestBase HttpRequest {get;}

## FeedResponse

* XDocument Document {get;set;}
* IEnumerable<FeedItem> {get;}

## FeedItem

* ContentItem ContentItem {get;set;}
* XElement Element {get;set;}

## IFeedHandler

* void Invoke(FeedContext context)

## IFeedBuilder

* string Format {get;}
* ActionResult Invoke(FeedContext context)
* void AddProperty(string name, string value, FeedItem item)

## IFeedItemBuilder

* void Invoke(FeedContext context, IFeedBuilder feedBuilder)
