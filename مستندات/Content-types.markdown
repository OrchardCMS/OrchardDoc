At the core of the idea of CMS is the ability to extend the system to new content types instead of restricting it
to pre-defined ones such as blog posts.

Orchard has a rich composition model that enables new content types to be created from existing parts
and extended at runtime. It also enables a development model that is code-centric rather than database-centric:
for all practical purposes, database persistence will just happen without the developer having to do anything
beyond defining the shape of his objects in code.


# Basic Concepts

## Content Item

A content item is a piece of content that you'd want to manipulate as a single entity.
For example, a blog post is composed of many parts: there is a title, a body, an author, comments, tags, etc.
But it is clear that the entity that you want to manipulate is the blog post as a whole.
Other examples of content items are images, videos, wiki pages, products, forum threads, etc.

A content item has an integer id that is unique across the site.

The definition of a content item is voluntarily relatively vague, because we don't want to restrict
what is considered a content item, so that developers can apply the same concepts to a wide array of objects.

## Content Type
A content type can be seen as a category of contents; it represents what a content item is.
For example, it's easy to understand that a content item is a blog post, or a photo, or a wiki page.
The core of the notion here are in the words "is a": if you can say that a given content item is a "something",
that "something" probably is the content type of the content item.

In developer speech, this concept is analogous to the concept of class, although the Orchard type system
is established at run-time rather than statically determined from definitions in source code.

A content type in Orchard is just a name (in other words, it's identified by a simple string).

## Content Part

Content items in Orchard are composed from existing nuggets of data and logic called content parts.
A content part packages the set of fields and methods that are necessary to implement a particular
reusable aspect of a content item.

All the parts that form a given content item share the same integer id.

For example, the "Comments" part has four properties: lists of published and pending comments,
a flag that determines whether comments are shown, and a flag that determines
whether the comment thread is closed. That part can be added to a content type to make it commentable.
In this system, the comment aspect doesn't need to know what it's commenting on, and the commented item
doesn't need to know that it has comments.

This of course provides high reusability as the composed units are narrow and loosely-coupled aspects.
Still, the size of the aspects is large enough that they can package a whole feature
(as opposed to field-level composition that does not enable rich feature sets to be encapsulated as one single entity,
and to type-level definition of behavior that doesn't provide easy reuse of cross-concerns
that apply to more than one content type).

## Record

A record is a concept that only needs to be known to content-type developers and that doesn't need
to surface to the end user of the application.

A record is the simple code representation of the data for a content part, as an almost Plain CLR Object
that is used for persistence of the part in and out of the database.
"Almost Plain CLR" because it usually derives from ContentPartRecord, which gives them an Id and a reference
to the content item the part is participating in.

## Content Driver

A content driver is similar to an MVC controller, except that it works at the level of the content part.
It is responsible for preparing the views of the part, on the front-end, but also as an editor in
the content item editor. It also handles post modifications in those editors in order to persist changes.
Finally, it handles the importing and exporting of the part. In many ways, the driver is the brain of your part.

## Content Handler

A content handler is the object that manages content items and parts.
It is a set of services that will chime in whenever the application needs to create parts or items,
among other tasks. Content providers are built around the idea of a filter, where the application
calls into all filters when it needs something, and each filter can decide whether to participate or not,
depending on the parameters communicated by the application.

For example, a content handler often manages the persistence of a part into a repository.

Most handlers are implemented as a simple assemblage of pre-defined filters.

## Shapes and Templates

Drivers create dynamic objects that represent the data to be rendered to the browser. Those objects are
called shapes and correspond to a view model in MVC, except that they represent a single part instead
of the whole model for the complete view.

When the time comes to render those shapes and transform them into HTML, Orchard looks in the file system
for templates and in special code constructs called shape methods for the most relevant way to handle
that specific shape. Templates are typically what you will use. They are typically `.cshtml` files found in the Views
folder of a theme or module.

# Building a new content type

New content types, and even new content parts, can be built from the admin UI. For more details about
this scenario, please read [creating custom content types](http://docs.orchardproject.net/Documentation/Creating-custom-content-types).

Of course, content parts and types can also b ebuilt from code.
See [writing a content part](http://docs.orchardproject.net/Documentation/Writing-a-content-part) for an example.

## Composing types from parts

On its own, a part doesn't do much. To make it useful, we need compose multiple parts
into a content type. Here are a few examples of the most frequently used parts:

* CommonPart gives an owner, created and last modified dates as well as an optional container (useful for hierarchies of content items such as a book containing chapters that contain pages that contain paragraphs for example).
* TitlePart gives the item a title
* AutoroutePart gives the item a path, making it possible to navigate to the item as a page in the front-end.
* BodyPart adds a body field and a format for that body.

## Settings

Content parts can have settings that define the behavior of the part for all items of a certain type.
For example, a map part can have settings for the default location to map, or for whether the map
should be interactive or not.
These part settings can be modified from the admin UI by going into Content/Content Types, choosing the content
type to configure and then by deploying the section of the part.

## Admin Menu

Modules can plug into the admin system.
This can be accomplished by using the INavigationProvider interface in the Orchard.UI.Navigation namespace.

Here is an example of an admin menu item:

    public class AdminMenu : INavigationProvider {
        public string MenuName { get { return "admin"; } }
    
        public void GetNavigation(NavigationBuilder builder) {
            builder.Add("Sandbox", "1",
                menu => menu
                    .Add("Manage Something", "1.0",
                        item => item
                            .Action("List", "Admin", new { area = "Orchard.Sandbox" })
                            .Permission(StandardPermissions.AccessAdminPanel)));
        }
    }

Note that we're using Orchard.Security.StandardPermissions.AccessAdminPanel here.
You can just as easily define your own permissions using the IPermissionProvider interface.

## Creating items of a custom type

Once you have created your own content type, you can create items of this type from the admin UI
by clicking New/YourContentType if the type has been marked "creatable".

Items can also be created from code:
    
    var custom = _contentManager.Create<CustomPart>("CustomType", part => {
        part.Record.SomeProperty = "My property value";
    });

## Querying the catalog

To get a specific content item of which you know the id, you can call:
    
    var page = _contentManager.Get<CustomPart>(id);

It is also possible to create more general queries against the content manager,
that can return lists of items:
    
    var items = _contentManager.Query<TitlePart, TitlePartRecord>()
        .Where(t => t.Title.Contains("foo"))
        .OrderBy(r => r.Title)
        .Slice(10, 5);


The code above will get the items 10 to 15 in the list of items that have "foo" in their titles, when ordered by title.

## Accessing the parts of the item

To access the different parts of a content item, you can call the As method on any of the parts:

    var body = mypage.As<BodyPart>().Text

## Revisions

06-10-2012: rewrite for current version of Orchard (1.4)
