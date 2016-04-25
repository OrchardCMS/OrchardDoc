Developer FAQ
=============
## What are the dependencies?
Orchard uses a number of external libraries. They can all be found under \lib directory in your enlistment. They are also enumerated in [Orchard dependencies and libraries](Orchard-dependencies-and-libraries.html).

## What framework versions does Orchard support?
Orchard supports the following versions of .net:

<table><thead><tr>
    <td>Orchard Version   </td>
    <td>Framework Required</td>
</tr></thead><tbody>
    <tr>
        <td>Up to version 1.7</td>
        <td>Orchard supports .NET 4.0.</td>
    </tr>
    <tr>
        <td>Version 1.8</td>
        <td>Orchard runs on .NET 4.5 and IIS 7 (or newer)</td>
    </tr>
    <tr>
        <td>Version 1.9</td>
        <td>Orchard runs on .NET 4.5.1 and IIS 7 (or newer)</td>
    </tr>
    <tr>
        <td>Version 1.10</td>
        <td>Orchard runs on .NET 4.5.2 and IIS 7 (or newer)</td>
    </tr>
</tbody></table>

## Which branch should I be using when working on the codebase?
Branches are discussed on the [contributing patches](Contributing-patches.html#Branches) page.

## What types of extensions can I write?
Orchard Modules and Themes are supported. There is extensive documentation covering these topics in the [main documentation index](/).

## Where are Modules physically located?
The projects in the "Modules" folder are physically located under the "src\Orchard.Web\Modules" folder. This allows modules to contain ASP.NET views and static content without having to copy files between projects to be able to run the project.

The Core modules are physically located under the "\src\Orchard.Web\Core" folder. 

## What is a Module.txt file?
This is the module manifest. It is a YAML-format file. You can learn more about module.txt in the [manifest files guide](manifest-files.html).

## What is the AdminMenu.cs file?
This file has an implementation of the Orchard interface called `INavigationProvider`. It lets modules hook themselves into the admin menu in the backend. This is typically where you declare what links should your module inject into the Admin menu and what controller actions these links invoke.

## What is the Permissions.cs file?
This file has an implementation of the Orchard interface called `IPermissionProvider`. It lets modules declare a set of permissions as well as attach those permissions to default Orchard roles. Once you add a new permission type to your module here, you will be able to use the Orchard authorization APIs to check that permission against the current user. You will also be able to manage which custom roles the permission belongs to in the Roles administration page.

## How do I do authorization inside my module against current user/roles?
Orchard comes with a default services implementation of the `IOrchardServices` interface. Simply include `IOrchardService` in your constructor and you will get the default implementation injected. Like:

    
    public AdminController(IMyService myService, IOrchardServices orchardServices) {
                _myService = myService;
                _orchardServices = orchardServices;
    }


At this point, services gives you Authorizer for authorization, Notifier for writing out notifications, ContentManager for access to the Orchard content manager and TransactionManager for handling database transactions. 

To check if the current user has a certain permission, you would simply do:

    
    Services.Authorizer.Authorize(Permissions.SomeModulePermission, 
       T("Some operation failed"));


## What are Core Modules?
Core Modules are Orchard Modules you can find under \src\Orchard.Web\Core. They also constitute the Orchard.Core project in the solution. These are modules that are always enabled and come with the default Orchard installation. 

See "Why are Core modules modules?" and "Why are Core Modules Core Modules?" below for more detailed information.

## Why are Core modules modules?
The difference is similar to OS concepts of monolithic vs micro-kernel: it was pretty obvious during high level design of Orchard that an extensibility point such as modules was needed. Everything else would constitute the core framework. 

Take the Common module for example, which introduces the BodyPart, a core concept common to many types of content types, such as blog posts or pages. Now we could've implemented this as part of the Orchard framework dll, and have modules depend on it. But then it wouldn't get the benefit of being a module, such as being able to hook up handlers, drivers, views, routes etc. 

This also relates to MVC and areas, where everything that belongs to an area is under the same directory. It was pretty clear that the right choice was to get some core concepts out of the framework dll into a separate dll, and have them be modules. 

This is very similar to non-monolithic operating systems where parts of the core functionality is implemented as modules outside the kernel, talking to it via the same exact interfaces as the more higher level modules.

## Why are Core Modules Core Modules?
Now that we want core concepts to be implemented as modules, why not put them into the modules directory along with the rest of the more obvious Orchard modules, such as the comments module. Well, this time it's about dependencies. In Orchard, modules that are in the modules directory can be disabled, uninstalled or otherwise updated in a breaking way. 

We prefer modules that are self-contained and don't require other non-core modules as dependencies, as much as possible. That's part of the entire dynamism behind the content type architecture. Pages and Blog posts, which belong to Pages and Blog modules, don't reference Comments or Tags modules, but it's possible to attach comments or tags to pages and blogposts. 

This decoupled behavior is ensured by the underlying content type architecture and not by direct reference from one or the other modules. Core modules are part of the Orchard framework and it's ok for modules to depend on them. They will be distributed by us and for all practical purposes are integral parts of the Orchard framework. Modules can depend on them and directly access their public surface.

## How do I write and run tests?
Orchard comes with a solution folder called Tests. This hosts 2 types of tests:

* **Unit Tests**: These are NUnit test fixtures. To write a fixture for a module, simply create a new directory under Orchard.Tests.Modules and populate it with your tests. 
* **Integration Tests**: These are also NUnit tests, generated using SpecFlow ([http://www.specflow.org](http://www.specflow.org)) .feature files. Your integration tests would go under Orchard.Specs and there are a multitude of examples there you can look at if you are new to the BDD approach.  

Running the unit tests is a matter of right clicking the solution or appropriate project and choose Run Unit Tests.

> Note: this applies to writing tests for the modules that come with the standard source code distribution of Orchard. 

> To write code for your own modules you should work in your own separate project. You can use the [orchard scaffolding command](Command-line-scaffolding.html) `codegen moduletests <module-name>` to set up test projects for your own modules.

## How do I contribute my changes to Orchard?

Contributing changes to Orchard are discussed on the [contributing patches](Contributing-patches.html#Branches) page.

## How to build a WCF service that exposes Orchard functionality?

To host a WCF Service in Orchard, with all of its goodies coming from IoC you have to:

Create a SVC file for your service with the new Orchard Host Factory:

    
    <%@ ServiceHost Language="C#" Debug="true" 
    Service="Orchard.Service.Services.IService, Orchard.Service"
    Factory="Orchard.Wcf.OrchardServiceHostFactory, Orchard.Framework" %>


Register the service normally as an IDependency.

    
    using System.ServiceModel;
    
    namespace Orchard.Service.Services {
      [ServiceContract]
      public interface IService : IDependency {
        [OperationContract]
        string GetUserEmail(string username);
      }
    }


Provide implementation (i.e.: Service : IService).

## What's in `App_Data`?

The `App_Data` folder is used to store various kinds of data. Contents of `App_Data` are never served. The contents are organized this way:

* File:**cache.dat** is a cache XML document describing what features are enabled for each tenant in the site. This being only a cache, modifying it may have unpredictable results.
* File:**hrestart.txt** stands for Host Restart. It is a file that is touched by the system to indicate a need to restart the application.
* Folder:**Dependencies** is used by dynamic compilation to store compiled dlls and has an XML file, dependencies.xml that tracks how each module was compiled (dynamically or not).
* Folder:**Exports** contains export XML files generated by the import/export feature.
* Folder:**Localization** contains localization `.po` files.
* Folder:**Logs** contains log files.
* Folder:**RecipeQueue** is used during setup to queue the recipes to execute.
* Folder:**Sites** contains one folder per tenant. The default tenant is in the Default folder, which is all there is if no tenant was created. Each folder contains the following:
    * **mappings.bin** is a binary serialized cache of nHibernate mappings.
    * **Orchard.sdf** is the SQL CE database file for the tenant.
    * **reports.dat** is a legacy log file.
    * **Settings.txt** describes the low-level settings for the tenant (database provider, connection string, etc.)
    * ***.settings.xml** - You will see one of these per search index you have configured in the admin panel. They hold configuration settings for the current state of that index.
    * Folder: **Indexes** - Used by the Lucene module to store search index cache files. 
* Folder:**Warmup** contains cached versions of pages generated by the warmup module, and a warmup.txt file that contains the timestamp for the last warmup file generation.

## Understanding bug status and triage

When you submit a bug, the team (or anybody subscribing to notifications) receives an e-mail. We do regular triage meetings with a small committee, sometimes as often as daily and usually at least once a week.

When we do triage, we make a query that returns all bugs in "Proposed" state, ordered by number of votes. This means that we are always looking at the most voted bugs first. If you care about a bug, you should vote for it, and it won't fall on deaf ears.

A bug that is still in "Proposed" state has not been triaged yet. When we look at a bug, several things can happen. We may close it if it doesn't reproduce, if it's by design or if it was fixed since submitted. We may ask for more information (and leave it in "Proposed" state). Or finally, we may move it to the "Active" bucket.

A bug that is in "Active" state has been triaged and should have been assigned a release. The release usually is one of the planned releases. Planned releases are usually the ones we are currently working on, plus a "Future Versions" release that we use for bugs and features that we want to handle but don't think we can do in the current cycle. The "Assigned to" field is only set when the bug is scheduled to be fixed in the current iteration or cycle. If it's in "Future Versions" it is usually unassigned.

Impact is usually set during triage but a "Low" value does not necessarily mean much: this is the default value so it might just mean that it hasn't been touched. It's OK to investigate with the team on the impact of a bug you care about.

## Developer Troubleshooting

* **Record Names**: Your implementations of the ContentPartRecords shouldn't have properties that are known keywords to NHibernate. Examples include Identity, Version.
