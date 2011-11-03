
At the core of the idea of CMS is the ability to extend the system to new content types instead of restricting it to pre-defined ones such as blog posts.

Orchard has a rich composition model that enables new content types to be created from existing parts and extended at runtime. It also enables a development model that is code-centric rather than database-centric: for all practical purposes, database persistence will just happen without the developer having to do anything beyond defining the shape of his objects in code.


# Basic Concepts

## Content Item
A content item is a piece of content that you'd want to manipulate as a single entity. For example, a blog post is composed of many parts: there is a title, a body, an author, comments, tags, etc. But it is clear that the entity that you want to manipulate is the blog post as a whole. Other examples of content items are images, videos, wiki pages, products, forum threads, etc.

A content item has an integer id that is unique across the site.

The definition of a content item is voluntarily relatively vague, because we don't want to restrict what is considered a content item, so that developers can apply the same concepts to a wide array of objects.

## Content Type
A content type can be seen as a category of contents; it represents what a content item is. For example, it's easy to understand that a content item is a blog post, or a photo, or a wiki page. The core of the notion here are in the words "is a": if you can say that a given content item is a "something", that "something" probably is the content type of the content item.

In developer speech, this concept is analogous to the concept of class, although the Orchard type system is established at run-time rather than statically determined from definitions in source code.

A content type in Orchard is just a name (in other words, it's identified by a simple string).

## Content Part
Content items in Orchard are composed from existing nuggets of data and logic called content parts. A content part packages the set of fields and methods that are necessary to implement a particular reusable aspect of a content item.

All the parts that form a given content item share the same integer id.

For example, the "HasComments" part has two properties, a list of comments and a flag that determines whether the comment thread is closed. That part can be added to a content type to make it commentable. In this system, the comment aspect doesn't need to know what it's commenting, and the commented item doesn't need to know that it has comments.

This of course provides high reusability as the composed units are narrow and loosely-coupled aspects. Still, the size of the aspects is large enough that they can package a whole feature (as opposed to field-level composition that does not enable rich feature sets to be encapsulated as one single entity, and to type-level definition of behavior that doesn't provide easy reuse of cross-concerns that apply to more than one content type).

## Record
A record is a concept that only needs to be known to content-type developers and that doesn't need to surface to the end user of the application.

A record is the simple code representation of a content part, as an almost Plain CLR Object. "Almost" because it derives from ContentPartRecord, which gives them an Id and a reference to the content item the part is participating in.

## Content Handler
A content handler is the object that manages content items and parts. It is a set of services that will chime in whenever the application needs to create parts or items, among other tasks. Content providers are built around the idea of a filter, where the application calls into all filters when it needs something, and each filter can decide whether to participate or not, depending on the parameters communicated by the application.

For example, a content handler could look at the content type and decide based on it to add a specific part to the current content item.

Most handlers are implemented as a simple assemblage of pre-defined filters, as we'll see in the actual example below.

# Building a new content type
In this example, we'll build a simple content type that just consists of a single name field at first, to which we'll add parts and settings.

The first part of this is done by creating a simple record class:

    
    namespace Orchard.Sandbox.Records {
        public class SandboxPageRecord : ContentPartRecord{
            public virtual string Name { get; set; }
        }
    }


Very straightforward stuff here.

First, we work in a "Records" or "Models" namespace. This is actually an important convention as this namespace pattern will enable automatic database persistence of our objects.

Then, we create a simple record class that derives from ContentPartRecord. The base class here gives us an Id and a reference to the content item this part will help represent. Notice here that this is implemented as a part, but it's the one part that will be used only for our content type that does not have a vocation to be re-used. For all practical purposes, this is the part that will be the most representative of the whole content type.

Finally, we define the name property as a read/write string.

## Choosing the parts
On its own, the part we just defined isn't doing much. To fix this, we'll add the following parts:

* CommonAspect gives an owner, created and last modified dates as well as an optional container (useful for hierarchies of content items such as a book containing chapters that contain pages that contain paragraphs that have comments for example).
* Routable gives the item a title and a slug, making it possible to navigate to the item as a page in the front-end.
* Body adds a body field and a format for that body.

## Building the content handler
This is done from a new content handler that we're defining as follows:

    
    namespace Orchard.Sandbox.Models {
        public class SandboxContentHandler : ContentHandler {
        }
    }


Again, the namespace is not neutral here as it enables the application to discover the content handlers dynamically at runtime.

Adding the parts is done from the constructor of the handler class:

    
    public SandboxContentHandler(
        IRepository<SandboxPageRecord> pageRepository, 
        IRepository<SandboxSettingsRecord> settingsRepository) {
    
        // define the "sandboxpage" content type
        Filters.Add(new ActivatingFilter<SandboxPage>("sandboxpage"));
        Filters.Add(new ActivatingFilter<CommonAspect>("sandboxpage"));
        Filters.Add(new ActivatingFilter<RoutableAspect>("sandboxpage"));
        Filters.Add(new ActivatingFilter<BodyAspect>("sandboxpage"));
        Filters.Add(new StorageFilter<SandboxPageRecord>(pageRepository) { AutomaticallyCreateMissingRecord = true });
    
        // add settings to site, and simple record-template gui
        Filters.Add(new ActivatingFilter<ContentPart<SandboxSettingsRecord>>("site"));
        Filters.Add(new StorageFilter<SandboxSettingsRecord>(settingsRepository) { AutomaticallyCreateMissingRecord = true });
        Filters.Add(new TemplateFilterForRecord<SandboxSettingsRecord>("SandboxSettings"));
    
    }


This code is the first time the actual content type makes an apparition as the "sandboxpage" string (we are repeating a string constant here for clarity but you'd of course move that to a constant in real code). Each ActivatingFilter that is added here adds a part any time a content item of type "sandboxpage" is created by the application.

One thing to notice is that we're not using the SandboxPageRecord directly here, but the SandboxPage, which is the actual part. This class is defined as follows:

    
    namespace Orchard.Sandbox.Models {
        public class SandboxPage : ContentPart<SandboxPageRecord>, IContentDisplayInfo {
            string IContentDisplayInfo.DisplayText {
                get { return Record.Name; }
            }
        }
    }


The part is defined as a ContentPart of SandboxPageRecord, which gives calling code access to the data for the part through the Record base property. It also implements IContentDisplayInfo, which enables the application to have a uniform way of displaying a short text representing a content item. It is implemented here to surface the value of the Name property.

We also create a storage filter for our own part from this handler to tell the system to use a repository of sandbox page records for storage. We don't have to worry about the storage of the other aspects in our content type as it will be handled by the handler for each of those parts (which probably has a storage filter of their own).

## Settings
Our content type has a few settings that can be configured from the site settings page. The settings themselves are defined by a part for which the record is defined like follows:

    
    namespace Orchard.Sandbox.Models {
        public class SandboxSettingsRecord : ContentPartRecord {
            public virtual bool AllowAnonymousEdits { get; set; }
        }
    }


Because this settings part is going to be very simple (it's pure data from a single part), we can build a part from the record generically: ContentPart<SandboxSettingsRecord>.

The code in our handler above (there is no need for a separate handler for the settings) adds an activating filter for that settings part, filtered on the "site" content type. Site is a special content type that represents the global settings of the site. With that simple filter, we've dynamically added our own settings to the global site settings.

Then, we have the storage filter for the settings that is similar to the one for the part itself.

Finally, we have a template filter, which is pointing the system to the editor to use for our settings record. The template should be located in packages/orchard.sandbox/Views/Models/EditorTemplate and called "SandboxSettingsRecord.ascx". The code for it can be:

    
    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Orchard.Sandbox.Models.SandboxSettingsRecord>" %>
    <h3>Sandbox</h3>
    <ol>
        <li>
            <%= Html.LabelFor(x=>x.AllowAnonymousEdits) %>
            <%= Html.EditorFor(x=>x.AllowAnonymousEdits) %>
            <%= Html.ValidationMessage("AllowAnonymousEdits", "*")%>
        </li>
    </ol>



## Admin Menu
Modules also have a way to plug into the admin system. This can be accomplished by using the INavigationProvider interface in the Orchard.UI.Navigation namespace.

    
    public class AdminMenu : INavigationProvider {
        public string MenuName { get { return "admin"; } }
    
        public void GetNavigation(NavigationBuilder builder) {
            builder.Add("Sandbox", "1",
                        menu => menu
                                    .Add("Manage Pages", "1.0", item => item.Action("List", "Admin", new { area = "Orchard.Sandbox" }).Permission(StandardPermissions.AccessAdminPanel)));
        }
    }


Note that we're using Orchard.Security.StandardPermissions.AccessAdminPanel here. You can just as easily define your own permissions using the IPermissionProvider interface.

## Adding the Module.txt
For Orchard to pick up your module in the system, there needs to be a Module.txt file with your package name in it like this:
    
    name: Sandbox


# Using our new content type
To use content types from a controller's code, you need to inject an instance of the content manager and of any repository that you want to use:

    
    namespace Orchard.Sandbox.Controllers
    {
        public class PageController : Controller {
            private readonly IContentManager _contentManager;
    
            public PageController(IContentManager contentManager) {
                _contentManager = contentManager;
            }
        }
    }


## Creating items of the new type
You can create a new sandbox page by calling the Create method of the content manager:

    
    var page = _contentManager.Create<SandboxPage>("sandboxpage", item => {
        item.Record.Name = "My page";
    });


## Querying the catalog
To get a specific content item of which you know the id, you can call:

    
    var page = _contentManager.Get<SandboxPage>(id);


It is also possible to create more general queries against the content manager, that can return lists that contain items of various types:

    
    var items = _contentManager.Query("blogpost", "sandboxpage")
        .Where<BodyRecord>(b => b.Body.Contains("foo"))
        .OrderBy<RoutableRecord, string>(r => r.Title)
        .Slice(10, 5);


The code above will get the items 10 to 15 in the list of blog posts and sandbox pages that have "foo" in their bodies, when ordered by title.

## Accessing the parts of the item
To access the different parts of a content item, you can call the Get method on any of the parts:

    
    var body = mypage.Get<BodyAspect>().Body

