Building a Web CMS (Content Management System) is unlike building a regular web application: it is more like building an application container. When designing such a system, it is necessary to build extensibility as a first-class feature. This can be a challenge as the very open type of architecture that's necessary to allow for great extensibility may compromise the usability of the application: everything in the system needs to be composable with unknown future modules, including at the user interface level. Orchestrating all those little parts that don't know about each other into a coherent whole is what Orchard is all about.

This document explains the architectural choices we made in Orchard and how they are solving that particular problem of getting both flexibility and a good user experience.


# Architecture

<table cellspacing="2" cellpadding="2" border="1" style="width:100%">
<tr>
<td colspan="4" align="center">Modules
</tr><tr>
<td colspan="4" align="center">Core
</tr><tr>
<td colspan="4" align="center">Orchard Framework
</tr><tr>
<td align="center" style="width:25%">ASP.NET MVC
<td align="center" style="width:25%">NHibernate
<td align="center" style="width:25%">Autofac
<td align="center" style="width:25%">Castle
</tr><tr>
<td colspan="2" align="center">.NET
<td colspan="2" align="center">ASP.NET
</tr><tr>
<td colspan="4" align="center">IIS or Windows Azure
</tr>
</table>

# Orchard Foundations

The Orchard CMS is built on existing frameworks and libraries. Here are a few of the most fundamental ones:

- [ASP.NET MVC](http://www.asp.net/mvc): ASP.NET MVC is a modern Web development framework that encourages separation of concerns.
- [NHibernate](http://nhforge.org/): NHibernate is an object-relational mapping tool. It handles the persistence of the Orchard content items to the database and considerably simplifies the data model by removing altogether the concern of persistence from module development. You can see examples of that by looking at the source code of any core content type, for example Pages.
- [Autofac](http://code.google.com/p/autofac/): Autofac is an [IoC container](http://en.wikipedia.org/wiki/Inversion_of_control). Orchard makes heavy use of dependency injection. Creating an injectable Orchard dependency is as simple as writing a class that implements IDependency or a more specialized interface that itself derives from IDependency (a marker interface), and consuming the dependency is as simple as taking a constructor parameter of the right type. The scope and lifetime of the injected dependency will be managed by the Orchard framework. You can see examples of that by looking at the source code for IAuthorizationService, RolesBasedAuthorizationService and XmlRpcHandler.
- [Castle Dynamic Proxy](http://www.castleproject.org/projects/dynamicproxy/): we use Castle for dynamic proxy generation.

The Orchard application and framework are built on top of these foundational frameworks as additional layers of abstraction. They are in many ways implementation details and no knowledge of NHibernate, Castle, or Autofac should be required to work with Orchard.

# Orchard Framework

The Orchard framework is the deepest layer of Orchard. It contains the engine of the application or at least the parts that couldn't be isolated into modules. Those are typically things that even the most fundamental modules will have to rely on. You can think of it as the base class library for Orchard.

## Booting Up Orchard

When an Orchard web application spins up, an Orchard Host gets created. A host is a singleton at the app domain level.

Next, the host will get the Shell for the current tenant using the ShellContextFactory. Tenants are instances of the application that are isolated as far as users can tell but that are running within the same appdomain, improving the site density. The shell is a singleton at the tenant level and could actually be said to represent the tenant. It's the object that will effectively provide the tenant-level isolation while keeping the module programming model agnostic about multi-tenancy.

The shell, once created, will get the list of available extensions from the ExtensionManager. Extensions are modules and themes. The default implementation is scanning the modules and themes directories for extensions.

At the same time, the shell will get the list of settings for the tenant from the ShellSettingsManager. The default implementation gets the settings from the appropriate subfolder of App_data but alternative implementations can get those from different places. For example, we have an Azure implementation that is using blob storage instead because App_data is not reliably writable in that environment.

The shell then gets the CompositionStrategy object and uses it to prepare the IoC container from the list of available extensions for the current host and from the settings for the current tenant. The result of this is not an IoC container for the shell, it is a ShellBlueprint, which is a list of dependency, controller and record blueprints.

The list of ShellSettings (that are per tenant) and the ShellBluePrint are then thrown into ShellContainerFactory.CreateContainer to get an ILifetimeScope, which is basically enabling the IoC container to be scoped at the tenant level so that modules can get injected dependencies that are scoped for the current tenant without having to do anything specific.

## Dependency Injection

The standard way of creating injectable dependencies in Orchard is to create an interface that derives from IDependency or one of its derived interfaces and then to implement that interface. On the consuming side, you can take a parameter of the interface type in your constructor. The application framework will discover all dependencies and will take care of instantiating and injecting instances as needed.

There are three different possible scopes for dependencies, and choosing one is done by deriving from the right interface:

- Request: a dependency instance is created for each new HTTP request and is destroyed once the request has been processed. Use this by deriving your interface from IDependency. The object should be reasonably cheap to create.
- Object: a new instance is created every single time an object takes a dependency on the interface. Instances are never shared. Use this by deriving from ITransientDependency. The objects must be extremely cheap to create.
- Shell: only one instance is created per shell/tenant. Use this by deriving from ISingletonDependency. Only use this for objects that must maintain a common state for the lifetime of the shell.

### Replacing Existing Dependencies

It is possible to replace existing dependencies by decorating your class with the OrchardSuppressDependency attribute, that takes the fully-qualified type name to replace as an argument.

### Ordering Dependencies

Some dependencies are not unique but rather are parts of a list. For example, handlers are all active at the same time. In some cases you will want to modify the order in which such dependencies get consumed. This can be done by modifying the manifest for the module, using the Priority property of the feature. Here is an example of this:

    
    Features:
        Orchard.Widgets.PageLayerHinting:
            Name: Page Layer Hinting
            Description: ...
            Dependencies: Orchard.Widgets
            Category: Widget
            Priority: -1



## ASP.NET MVC

Orchard is built on ASP.NET MVC but in order to add things like theming and tenant isolation, it needs to introduce an additional layer of indirection that will present on the ASP.NET MVC side the concepts that it expects and that will on the Orchard side split things on the level of Orchard concepts.

For example, when a specific view is requested, our LayoutAwareViewEngine kicks in. Strictly speaking, it's not a new view engine as it is not concerned with actual rendering, but it contains the logic to find the right view depending on the current theme and then it delegates the rendering work to actual view engines.

Similarly, we have route providers, model binders and controller factories whose work is to act as a single entry point for ASP.NET MVC and to dispatch the calls to the properly scoped objects underneath.

In the case of routes, we can have n providers of routes (typically coming from modules) and one route publisher that will be what talks to ASP.NET MVC. The same thing goes for model binders and controller factories.

## Content Type System

Contents in Orchard are managed under an actual type system that is in some ways richer and more dynamic than the underlying .NET type system, in order to provide the flexibility that is necessary in a Web CMS: types must be composed on the fly at runtime and reflect the concerns of content management.

### Types, Parts, and Fields

Orchard can handle arbitrary content types, including some that are dynamically created by the site administrator in a code-free manner. Those content types are aggregations of content parts that each deal with a particular concern. The reason for that is that many concerns span more than one content type.

For example, a blog post, a product and a video clip might all have a routable address, comments and tags. For that reason, the routable address, comments and tags are each treated in Orchard as a separate content part. This way, the comment management module can be developed only once and apply to arbitrary content types, including those that the author of the commenting module did not know about.

Parts themselves can have properties and content fields. Content fields are also reusable in the same way that parts are: a specific field type will be typically used by several part and content types. The difference between parts and fields resides in the scale at which they operate and in their semantics.

Fields are a finer grain than parts. For example, a field type might describe a phone number or a coordinate, whereas a part would typically describe a whole concern such as commenting or tagging.

But the important difference here is semantics: you want to write a part if it implements an "is a" relationship, and you would write a field if it implements a "has a" relationship.

For example, a shirt **is a** product and it **has a** SKU and a price. You wouldn't say that a shirt has a product or that a shirt is a price or a SKU.

From that you know that the Shirt content type will be made of a Product part, and that the Product part will be made from a Money field named "price" and a String field named SKU.

Another difference is that you have only one part of a given type per content type, which makes sense in light of the "is a" relationship, whereas a part can have any number of fields of a given type. Another way of saying that is that fields on a part are a dictionary of strings to values of the field's type, whereas the content type is a list of part types (without names).

This gives another way of choosing between part and field: if you think people would want more than one instance of your object per content type, it needs to be a field.

### Anatomy of a Content Type

A content type, as we've seen, is built from content parts. Content parts, code-wise, are typically associated with:

- a Record, which is a POCO representation of the part's data
- a model class that is the actual part and that derives from `ContentPart<T>` where T is the record type
- a repository. The repository does not need to be implemented by the module author as Orchard will be able to just use a generic one.
- handlers. Handlers implement IContentHandler and are a set of event handlers such as OnCreated or OnSaved. Basically, they hook onto the content item's lifecycle to perform a number of tasks. They can also participate in the actual composition of the content items from their constructors. There is a Filters collection on the base ContentHandler that enable the handler to add common behavior to the content type.  
For example, Orchard provides a StorageFilter that makes it very easy to declare how persistence of a content part should be handled: just do `Filters.Add(StorageFilter.For(myPartRepository));` and Orchard will take care of persisting to the database the data from myPartRepository.  
Another example of a filter is the ActivatingFilter that is in charge of doing the actual welding of parts onto a type: calling `Filters.Add(new ActivatingFilter<BodyAspect>(BlogPostDriver.ContentType.Name));` adds the body content part to blog posts.
- drivers. Drivers are friendlier, more specialized handlers (and as a consequence less flexible) and are associated with a specific content part type (they derive from `ContentPartDriver<T>` where T is a content part type). Handlers on the other hand do not have to be specific to a content part type. Drivers can be seen as controllers for a specific part. They typically build shapes to be rendered by the theme engine.

## Content Manager
All contents are accessed in Orchard through the ContentManager object, which is how it becomes possible to use contents of a type you don't know in advance.

ContentManager has methods to query the content store, to version contents and to manage their publication status.

## Transactions

Orchard is automatically creating a transaction for each HTTP request. That means that all operations that happen during a request are part of an "ambient" transaction. If code during that request aborts that transaction, all data operations will be rolled back. If the transaction is never explicitly cancelled on the other hand, all operations get committed at the end of the request without an explicit commit.


## Request Lifecycle

In this section, we'll take the example of a request for a specific blog post.

When a request comes in for a specific blog post, the application first looks at the available routes that have been contributed by the various modules and finds the blog module's matching route. The route can then resolve the request to the blog post controller's item action, which will look up the post from the content manager. The action then gets a Page Object Model (POM) from the content manager (by calling BuildDisplay) based on the main object for that request, the post that was retrieved from the content manager.

A blog post has its own controller, but that is not the case for all content types. For example, dynamic content types will be served by the more generic ItemController from the Core Routable part. The Display action of the ItemController does almost the same thing that the blog post controller was doing: it gets the content item from the content manager by slug and then builds the POM from the results.

The layout view engine will then resolve the right view depending on the current theme and using the model's type together with Orchard conventions on view naming.

Within the view, more dynamic shape creation can happen, such as zone definitions.

The actual rendering is done by the theme engine that is going to find the right template or shape method to render each of the shapes it encounters in the POM, in order of appearance and recursively.

## Widgets

Widgets are content types that have the Widget content part and the widget stereotype. Like any other content types, they are composed of parts and fields. That means that they can be edited using the same edition and rendering logic as other content types. They also share the same building blocks, which means that any existing content part can potentially be reused as part of a widget almost for free.

Widgets are added to pages through widget layers. Layers are sets of widgets. They have a name, a rule that determines what pages of the site they should appear on, and a list of widgets and associated zone placement and ordering, and settings.

The rules attached to each of the layers are expressed with IronRuby expressions. Those expressions can use any of the IRuleProvider implementations in the application. Orchard ships with two out of the box implementations: url and authenticated.

## Site Settings

A site in Orchard is a content item, which makes it possible for modules to weld additional parts. This is how modules can contribute site settings.

Site settings are per tenant.

## Event Bus

Orchard and its modules expose extensibility points by creating interfaces for dependencies, implementations of which can then get injected.

Plugging into an extensibility point is done either by implementing its interface, or by implementing an interface that has the same name and the same methods. In other words, Orchard does not require strictly strongly typed interface correspondence, which enables plug-ins to extend an extensibility point without taking a dependency on the assembly where it's defined.

This is just one implementation of the Orchard event bus. When an extensibility point calls into injected implementations, a message gets published on the event bus. One of the objects listening to the event bus dispatches the messages to the methods in classes that derive from an interface appropriately named.

## Commands

Many actions on an Orchard site can be performed from the command line as well as from the admin UI. These commands are exposed by the methods of classes implementing ICommandHandler that are decorated with a CommandName attribute.

The Orchard command line tool discovers available commands at runtime by simulating the web site environment and inspecting the assemblies using reflection. The environment in which the commands run is as close as possible to the actual running site.

## Search and Indexing

Search and indexing are implemented using Lucene by default, although that default implementation could be replaced with another indexing engine.

## Caching

The cache in Orchard relies on the ASP.NET cache, but we expose a helper API that can be used through a dependency of type ICache, by calling the Get method. Get takes a key and a function that can be used to generate the cache entry's value if the cache doesn't already contains the requested entry.

The main advantage of using the Orchard API for caching is that it works per tenant transparently.

## File Systems

The file system in Orchard is abstracted so that storage can be directed to the physical file system or to an alternate storage such as Azure blob storage, depending on the environment. The Media module is an example of a module that uses that abstracted file system.

## Users and Roles

Users in Orchard are content items (albeit not routable ones) which makes it easy for a profile module for example to extend them with additional fields.
Roles are a content part that gets welded onto users.

## Permissions

Every module can expose a set of permissions as well as how those permissions should be granted by default to Orchard's default roles.

## Tasks

Modules can schedule tasks by calling CreateTask on a dependency of type IScheduledTaskManager. The task can then be executed by implementing IScheduledTaskHandler. The Process method can examine the task type name and decide whether to handle it.

Tasks are being run on a separate thread that comes from the ASP.NET thread pool.

## Notifications

Modules can surface messages to the admin UI by getting a dependency on INotifier and calling one of its methods. Multiple notifications can be created as part of any request.

## Localization

Localization of the application and its modules is done by wrapping string resources in a call to the T method: `<%: T("This string can be localized") %>`. See [Using the localization helpers](Using-the-localization-helpers) for more details and guidelines. Orchard's resource manager can load localized resource strings from PO files located in specific places in the application.

Content item localization is done through a different mechanism: localized versions of a content item are physically separate content items that are linked together by a special part.

The current culture to use is determined by the culture manager. The default implementation returns the culture that has been configured in site settings, but an alternate implementation could get it from the user profile or from the browser's settings.

## Logging

Logging is done through a dependency of type ILogger. Different implementations can send the log entries to various storage types. Orchard comes with an implementation that uses [Castle.Core.Logging](http://docs.castleproject.org/Windsor.Logging-Facility.ashx) for logging.

# Orchard Core

The Orchard.Core assembly contains a set of modules that are necessary for Orchard to run. Other modules can safely take dependencies on these modules that will always be available.

Examples of core modules are feeds, navigation or routable.

# Modules
The default distribution of Orchard comes with a number of built-in modules such as blogging or pages, but third party modules are being built as well.

A module is just an ASP.NET MVC area with a manifest.txt file that is extending Orchard.

A module typically contains event handlers, content types and their default rendering templates as well as some admin UI.

Modules can be dynamically compiled from source code every time a change is made to their csproj file or to one of the files that the csproj file references. This enables a "notepad" style of development that does no require explicit compilation by the developer or even the use of an IDE such as Visual Studio.

# Themes

It is a basic design principle in Orchard that all the HTML that it produces can be replaced from themes, including markup produced by modules. Conventions define what files must go where in the theme's file hierarchy.

The whole rendering mechanism in Orchard is based on shapes. The theme engine's job is to find the current theme and given that theme determine what the best way to render each shape is. Each shape can have a default rendering that may be defined by a module as a template in the views folder or as a shape method in code. That default rendering may be overridden by the current theme. The theme does that by having its own version of a template for that shape or its own shape method for that shape.

Themes can have a parent, which enables child themes to be specializations or adaptations of a parent theme. Orchard comes with a base theme called the Theme Machine that has been designed to make it easy to use as a parent theme.

Themes can contain code in much the same way modules do: they can have their own csproj file and benefit from dynamic compilation. This enables themes to define shape methods, but also to expose admin UI for any settings they may have.

The selection of the current theme is done by classes implementing IThemeSelector, which return a theme name and a priority for any request. This allows many selectors to contribute to the choice of the theme. Orchard comes with four implementations of IThemeSelector:

- SiteThemeSelector selects the theme that is currently configured for the tenant or site with a low priority.
- AdminThemeSelector takes over and returns the admin theme with a high priority whenever the current URL is an admin URL.
- PreviewThemeSelector overrides the site's current theme with the theme being previewed if the current user is the one that initiated the theme preview.
- SafeModeThemeSelector is the only selector available when the application is in "safe mode", which happens typically during setup. It has a very low priority.

An example of a theme selector might be one that promotes a mobile theme when the user agent is recognized to belong to a mobile device.
