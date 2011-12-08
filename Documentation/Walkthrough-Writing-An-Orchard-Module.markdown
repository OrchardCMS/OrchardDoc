> This topic is obsolete. Please use the following topics for information on module creation, see
[Creating a module with a simple text editor](Creating-a-module-with-a-simple-text-editor) or
[Building a Hello World module](Building-a-hello-world-module) or
[Writing a content part](Writing-a-content-part).

Orchard is designed with modular extensibility in mind.  The current application contains a number of built-in modules by default, and our intent with writing these modules has been to validate the underlying CMS core  as it is being developed - exploring such concepts as routable content items, their associated "parts" (eventually to be bolted on using metadata), UI composability of views from separate modules, and so on.  While there are many CMS core concepts that remain unimplemented for now, there are still many things you can do with the current system.  The module concept is rooted in ASP.NET MVC Areas ([1](http://weblogs.asp.net/scottgu/archive/2009/07/31/asp-net-mvc-v2-preview-1-released.aspx),[2](http://haacked.com/archive/2009/07/31/single-project-areas.aspx)) with the idea that module developers can opt-in to Orchard-specific functionality as needed.  You can develop modules in-situ with the application as "Areas", using Visual Studio's MVC tools: Add Area, Add Controller, Add View, and so on (in VS2010).  You can also develop modules as separate projects, to be packaged and shared with other users of Orchard CMS (the packaging story is still to be defined, along with marketplaces for sharing modules).  This is how the Orchard source tree is currently organized.  There is also a "release" build of Orchard that contains all the modules pre-built and ready to run (without source code), that you can extend using the VS tooling for MVC Areas - this can be downloaded from 
[http://orchard.codeplex.com/releases](http://orchard.codeplex.com/releases). 

![](../Upload/module-tutorial/architecture_sm.gif)

Let's take a walk through building an Orchard module as an MVC Area in VS.  We'll start simple (Hello World), and gradually build up some interesting functionality using Orchard. 

**Installing Software Prerequisites**

First, install these MVC and Orchard releases to your machine, along with Visual Studio or Visual Web Developer for code editing:

1. Install VS2010 (Express or higher)
2. Download and Install ASP.NET MVC 3
3. Download and extract the latest "release" build from http://orchard.codeplex.com
4. Double-click the csproj file in the release package to open it in VS

### Getting Started: A Simple Hello World Module ("Area" in VS)

Our objective in this section is to build a very simple module that displays "Hello World" on the front-end using the applied Orchard theme.  We'll also wire up the navigation menu to our module's routes.


**Objectives:**

* A simple custom area that renders "Hello World" on the app's front-end
* Views in the custom area that take advantage of the currently applied Orchard theme
* A menu item on the front-end for navigating to the custom area's view

**Follow These Steps:**

1. Right-click the project node in VS Solution Explorer, and choose "Add &gt; Area..."
2. Type "Commerce" for the area name and click **OK**.
3. Right-click the newly created "Commerce &gt; Controllers" folder, and choose "Add &gt; Controller..."
4. Name the Controller "HomeController"
5. Right-click on the "Index()" method name and choose "Add View..."
6. Selected the "Create a partial view" option and click **Add**
7. Add the following HTML to the View page: `<p>Hello World</p>`
8. Add the following namespace imports to the HelloController.cs file:

        using Orchard.Themes;
        using Orchard.UI.Navigation;

9. Add a `[Themed]` attribute to the HelloController class:

        namespace Orchard.Web.Areas.Commerce.Controllers {
            [Themed]
            public class HomeController : Controller

10. Add another class to create a new Menu item:

        public class MainMenu : INavigationProvider {
            public String MenuName {
                get { return "main"; }
            }
            public void GetNavigation(NavigationBuilder builder)
            {
                builder.Add(menu => 
                        menu.Add("Shop", "4", item => item
                            .Action("Index", "Home", new { area = "Commerce" })));
            }
        }
