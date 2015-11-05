This section describes the project structure of an Orchard solution in Visual Studio.
The projects and folders are listed in the order they appear in Visual Studio. 

We recommend that you open the Orchard project in Visual Studio and browse through the files as you read this topic.

# Modules
Modules is a Visual Studio solution folder that contains Orchard module projects.
It maps to the /Modules subfolder of the Orchard.Web web site folder.
Each subfolder of the Modules folder is an Orchard module.
All Orchard modules are ASP.NET MVC areas.

# Specs
The _Specs_ folder contains the following projects:

* Orchard.Profile. This provides for creating a profiling image for Orchard.
* Orchard.Specs. This contains integration tests written using a [SpecFlow](http://www.specflow.org) style. Feature-specific information is contained in the _*.feature_ files.

# Tests
The _Tests_ folder contains the following projects:

* Orchard.Core.Tests is the test project for the Orchard.Core project.
* Orchard.Framework.Tests is the test project for the Orchard.Framework project.
* Orchard.Tests.Modules is the test project for Orchard modules. It contains subfolders for different modules.
* Orchard.Web.Tests is the test project for the Orchard.Web project.

# Tools

The _Tools_ folder contains the source code for tools that are used to build the Orchard solution.
It also contains the Orchard project, which builds the Orchard.exe command-line tool that you can use
to run commands defined in an Orchard website in order to automate administrative tasks.

# Orchard.Core

The Core project contains a set of core modules and content types for Orchard, such as feeds, theming,
navigation or the common, routable and body content parts.

# Orchard.Framework Project

Orchard.Framework is a class library project containing the Orchard CMS framework.

# Orchard.Web Project

Orchard.Web is an MVC web application project. This is the application that you actually run.
It is the startup project of the application. It contains the Orchard CMS core platform binaries and
is therefore the Orchard CMS host application.

# Other Notes

* The Orchard.Web project is set as the startup project of the solution (for example, when you use Visual Studio debugging). Orchard.Web dynamically loads all Orchard modules and discovers module extensibility points (MVC routes, admin pages, and so on.)
* The projects in the _Modules_ folder are physically located under the **Ochard.Web\Modules** folder. This allows modules to contain ASP.NET views (_.aspx_, _.ascx_, and other files) and static content without having to copy files between projects to be able to run the project.
* The Orchard.Web project has project references to the modules. This enables automatic copying of the output assemblies into the _bin_ folder of the Orchard.Web project. Orchard.Web has no dependency on types in the _Modules_ assemblies, because the Orchard.Web project is not supposed to have a compile-time knowledge of which modules are loaded at run time. (This is not entirely true at the current stage of Orchard development.)
* The projects in the _Modules_ folder have a project reference to the Orchard project. This allows modules to have access to the base Orchard services.

# About Core Modules

This section discuss some of the design decisions that went into creating core modules.
The first issue is this: why are core modules modules? Because during the design phase for Orchard,
it was determined that an extensibility point such as modules was needed.
Everything else would constitute the core framework. 

For example, the **Common** module introduces the **Body** part, a core concept that is common to many
types of content types, such as blog posts or pages. This could have been implemented as part of the
Orchard framework DLL and could have had modules depend on it. However, then it would not get
the benefit of being a module, such as being able to hook up handlers, drivers, views, routes, and so on.
This also relates to MVC and areas, where everything that belongs to an area is under the same directory. 

It was determined that the correct approach was to get certain core concepts out of the framework DLL
into a separate DLL and have them be modules. This is similar to non-monolithic operating systems where
parts of the core functionality are implemented as modules outside the kernel, talking to the kernel
using the same interfaces as the more high-level modules.

A second design issue for core modules was this: why are core modules core modules?
After it was determined that core concepts would be implemented as modules, it might have made sense
to put them into the modules directory along with the rest of the Orchard modules, such as the comments module. 

The problem with that approach was dependencies. In Orchard, modules that are in the modules directory
can be disabled, uninstalled, or otherwise updated in a breaking way. Orchard modules should avoid
dependencies on other modules as much as possible -- that's part of the dynamism behind the content-type
architecture. Pages and blog posts, which belong to the **Pages** and **Blog** modules, don't reference
the **Comments** or **Tags** modules, but it's possible to attach comments or tags to pages and blog posts.
This decoupled behavior is ensured by the underlying content-type architecture and not by direct reference
from another module. 

However, core modules are part of the Orchard framework and it's considered acceptable for modules to
depend on them. Core modules will be distributed by the Orchard development team, and for all practical
purposes are integral parts of the Orchard framework. Modules can depend on them and directly access
their public surface.
