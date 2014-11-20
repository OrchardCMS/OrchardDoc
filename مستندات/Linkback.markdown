
Orchard should send linkbacks when contents gets created, and should receive refbacks, trackbacks and pingbacks. It should put all three through spam filters and should provide admin UI to manage the linkbacks and configure their moderation (moderation required or not, etc.).


# Sending linkbacks

The Linkback module, when activated for a given content type, should act as a filter on save actions. It should be looking for A tags in the body of the content item and extract the href attribute for each. It should then schedule trackback and pingback pings for each extracted URL.

> **Issue:** should only body be scanned for URLs or should we rely on a more generic definition of content text?

> **Note:** linking back to local contents can be considered like a regular linkback, but some site authors like to only show external ones. For this reason, there should be a setting to only send trackback notifications to external URLs.

## Sending refback

For refbacks, there isn't anything to do from the sender's end. The first visitor to click the link will implicitly notify the target site.

## Sending trackback

On the scheduled job, the linkback module should do a GET on the linked URL and then scan the results for embedded RDF for the ping URL. If such a ping URL is found, the module should send the trackback ping, according to [the trackback specification](http://www.sixapart.com/pronet/docs/trackback_spec).

## Sending pingback

The GET request that is being made to search for trackback RDF can be re-used to look for pinkback HTTP headers or link tags, according to [the pinkback specification](http://www.hixie.ch/specs/pingback/pingback). If such a pingback URL is discovered, it should be pinged according to spec.

## When both trackback and pingback are supported

When both pingback and trackback are discovered to be supported, we should only send the pingback notification.
# Embedding trackback and pingback auto-discovery

In order to comply with trackback and pingback specifications, we must include auto-discovery information in any document that must be able to be linked back to. For pingback, there is a choice of using an HTTP header or a link tag. We will use link tags because they are more explicit and easier to fit in our overall UI composition engine.

The linkback module, when activated on the main content item being displayed, will inject the auto-discovery markup for both trackback and pingback into the page, using the same composition engine that is being used for the rest of the page. That markup will point the linkback clients to trackback and pingback actions on the linkback controller.

# Receiving linkback pings

The linkback controller will receive all notifications for pingback and trackback.

For refback, the linkback module will have to act as a filter in order to handle all incoming GET actions that have a referrer that is different from the current URL.

In all three cases, the linkback module will verify that the targeted content item has linkback enabled (it has a linkback part), and it will then add a record to the list of linkback URLs on the linkback part for that item, if that URL is not already in the list.

The items in the list of linkback URLs have a URL, a title (the extracted title of the linking page), a summary (the summary meta of the linking page if available, null otherwise) and a date (the date the linkback was received).

# Moderation and spam filtering

Each linkback to a content item should be moderated and filtered for spam like comments are. See [comment specification](comments).

# Settings

It should be possible eventually to configure what content items accept linkbacks. That will be part of the general configuration of parts on content types. That work has not been done yet.

It should be possible to enable or disable each of the three linkback protocols, on the ways in or out.

There should be a setting to enable or disable local/internal linkbacks.

# Permissions
In this context, the owner is the owner of the content item being linked back to (the container of the linkbacks).


Permission                                       | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
Moderate linkbacks (implies all others)          | No    | No         | Yes   | Yes    | Yes    | Yes
Disable linkbacks                                | No    | No         | Yes   | Yes    | Yes    | Yes
