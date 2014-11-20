> This topic has been updated for the Orchard 1.0 release.

A content handler defines what happens with a content part in response to specific events, such as when the part is activated. The content handler enables you to perform actions at particular moments in the lifecycle of the content item. It also enables you to set up data repositories and manipulate the data model prior to rendering the content item.

Typically, you define a handler for a content part by creating a class that inherits from `ContentHandler`. The `ContentHandler` class is a base class that provides the methods and properties you will commonly need when defining your own content handler. Alternately, you can also create your own content handler by creating a class that implements `IContentHandler`.

## Defining Data Repository and Adding Filters

When working with a content part that persists data, add a constructor for the handler that accepts an `IRepository` parameter for objects of the type you defined for records in the part. The following code shows a basic implementation of a content handler. `MapRecord` is a class defined in a separate file.

    
    using Map.Models;
    using Orchard.ContentManagement.Handlers;
    using Orchard.Data;
    
    namespace Map.Handlers {
        public class MapHandler : ContentHandler {
            public MapHandler(IRepository<MapRecord> repository) {
                Filters.Add(StorageFilter.For(repository));
            }
        }
    }

You can add other types of filters to the content handler. For example, you can add an `ActivatingFilter` to the `Filters` collection to define how the part is added to a type.

## Built-in filter types

* `StorageFilter` class - Takes care of persisting the data from `repository` object to the database. Its usage is shown in the example above.
* `ActivatingFilter` class - Attaches a part to a content type from code. As opposed to attaching parts via migrations, parts attached using this filter will neither be displayed in the Dashboard, nor users will be able to remove them from types. It's a legitimate way of attaching parts that should *always* exist on a given content type.

## Lifecycle Events

In addition to defining the repository, you can add code for handling events. You use the following methods to add the code that is executed for the event:

* `OnActivated`
* `OnCreated`
* `OnCreating`
* `OnIndexed`
* `OnIndexing`
* `OnInitializing`
* `OnLoaded`
* `OnLoading`
* `OnPublished`
* `OnPublishing`
* `OnRemoved`
* `OnRemoving`
* `OnUnpublished`
* `OnUnpublishing`
* `OnVersioned`
* `OnVersioning`

For example, the `TagPartHandler` class contains code to take action for the `Removed` and `Indexing` events, as shown in the following example:

    
    public class TagsPartHandler : ContentHandler {
        public TagsPartHandler(IRepository<TagsPartRecord> repository, ITagService tagService) {
            Filters.Add(StorageFilter.For(repository));
     
            OnRemoved<TagsPart>((context, tags) => 
                tagService.RemoveTagsForContentItem(context.ContentItem));
    
            OnIndexing<TagsPart>((context, tagsPart) => 
                context.DocumentIndex.Add("tags", String.Join(", ", tagsPart.CurrentTags.Select(t => t.TagName))).Analyze());
        }
    }


## Data Manipulation

You can override the following methods to perform actions related to the state of the data:

* `GetItemMetadata`
* `BuildDisplayShape`
* `BuildEditorShape`
* `UpdateEditorShape`

For example, the `BlogPostPartHandler` class overrides the `GetItemMetadata` method to add route values using code like the following:

    
    protected override void GetItemMetadata(GetContentItemMetadataContext context) {
        var blogPost = context.ContentItem.As<BlogPostPart>();
                
        if (blogPost == null)
            return;
    
        context.Metadata.CreateRouteValues = new RouteValueDictionary {
            {"Area", "Orchard.Blogs"},
            {"Controller", "BlogPostAdmin"},
            {"Action", "Create"},
            {"blogId", blogPost.BlogPart.Id}
        };
        context.Metadata.EditorRouteValues = new RouteValueDictionary {
            {"Area", "Orchard.Blogs"},
            {"Controller", "BlogPostAdmin"},
            {"Action", "Edit"},
            {"postId", context.ContentItem.Id},
            {"blogId", blogPost.BlogPart.Id}
        };
        context.Metadata.RemoveRouteValues = new RouteValueDictionary {
            {"Area", "Orchard.Blogs"},
            {"Controller", "BlogPostAdmin"},
            {"Action", "Delete"},
            {"postId", context.ContentItem.Id},
            {"blogSlug", blogPost.BlogPart.As<RoutePart>().Slug}
        };
    }

