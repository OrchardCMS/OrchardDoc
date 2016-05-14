## Step 1 - Install Microsoft Visual Studio
If you don't have a it on your system then grab a copy of [Microsoft Visual Studio Community 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx). Its totally free and it has most of the features of the full version and supports everything we will need to extend Orchard.

## Step 2 - Install Git Extensions
Every developer should have [Git Extensions](https://github.com/gitextensions/gitextensions/releases/latest) installed on their machine.

This is the easiest way to quickly clone the Orchard source code onto your dev machine. Its the easiest way to keep up to date when new code is released. As a bonus, if you haven't got to grips with Git and GitHub this will gently introduce you to the whole process.

> If you need detailed help installing Git Extensions and cloning the repository this process is described in the [setting up a source enlistment](Setting-up-a-source-enlistment) tutorial in step-by-step detail.

## Step 3 - Set up a braces management extension
This step is optional but recommended.

You will probably have noticed that Orchard code has the braces on the same line as the definition. It looks like this:

    namespace Orchard.LearnOrchard.Example.Models {
        public class ExamplePart {
        }
    }
    
Instead of what you normally see with .NET code where the opening curly brace is on it's own line, which looks like this:

    namespace Orchard.LearnOrchard.Example.Models
    {
        public class ExamplePart
        {
        }
    }

The placement of the opening curly braces on the same line is a requirement listed in the [code conventions](/Documentation/Code-conventions) document for Orchard CMS.

You [can do it by editing the Visual Studio settings manually](http://articles.runtings.co.uk/2015/09/orchard-cms-quick-tipcurling-up-with.html) but this will apply it to all of your solutions whether they are Orchard-based or not.

A better solution is to let a Visual Studio extension manage this for you. Orchard supports two options out of the box:

  1. [ReSharper](https://visualstudiogallery.msdn.microsoft.com/ea4ac039-1b5c-4d11-804e-9bede2e63ecf). (**Paid**) This is a powerful extension with many more features than simple brace management. It is recommended that you check this extension out if you haven't used it.
  
  1. [Rebracer](https://visualstudiogallery.msdn.microsoft.com/410e9b9f-65f3-4495-b68e-15567e543c58). (**Free**) Orchard also supports the free Rebracer extension. This extension simply manages your brace configurations for you on a per-solution basis.
  
Install one of these two extensions.

## Step 4 - Clone the repository to your machine
You should always work on a fresh copy of Orchard when you're following a tutorial, testing out new 3rd party modules and themes from the [Gallery](http://gallery.orchardproject.net/), or working on your own modules to keep things clean.

Database tables are going to be modified, you will make changes in the admin dashboard, you will make mistakes and change things a second time. When you install new modules or themes they can inject their own data into your database and adjust built in content types. Even if you deactivate them again these changes can get left behind.

To stop this detritus getting into your main site you should always use a fresh copy to test things out in.

With Git Extensions and Orchard's support for SqlCE databases you can have a fresh copy of Orchard up and running in just a minute or two.


  1. In Windows Explorer, navigate to the local directory where you want your copy of the source code to live, right-click and choose `GitEx Clone`.

    ![](../Attachments/setting-up-for-a-lesson/git_context_menu.png)

  2. In the clone window you have four fields to fill out:

    * In the `Repository to clone` field type [https://github.com/OrchardCMS/Orchard/](https://github.com/OrchardCMS/Orchard/). 
    * The `Destination` field will already be filled out with your current directory. 
    * When you paste the repository URL it will also fill out the `Subdirectory to create` field. If you want to change this to a project name you can. 
    * Selecting the `Branch` dropdown will show you all of the current branches. This is loaded from GitHub so it may take a few seconds to load the list. Unless your lesson says differently, select `master` for the latest stable branch. 

  3. The rest of the settings can be left as-is. Click `Clone`.

    ![](../Attachments/setting-up-for-a-lesson/git_clone.png)

Git Extensions will now pull down the files from the remote repository hosted on GitHub. This process will take a minute or two while the files are downloaded to your hard drive.

> **Tip:** If you find yourself following this process often you can greatly speed this up by cloning from a local copy. 

> To do this create a fresh clone on your hard drive and keep that as your reference copy. Then, instead of using a URL in the `Repository to clone:` field you can point at the location of your reference copy stored on your local hard drive. 

> The whole clone process should then take just a couple of seconds.  

## Step 5 - Complete the initial site setup process
Now you just need to follow these last few steps to create a default database and set up the admin user:

  1. Open Visual Studio
  
  1. Click `File`, `Open`, `Project/Solution...`
  
  1. Navigate to the folder you cloned the repo into
  
  1. Open the main solution file located at `.\src\Orchard.sln`
  
  1. Press `Ctrl-F5` to start the project without debugging (it loads quicker)
  
  1. You will now be presented with the `Get Started` install screen of Orchard:
  
     ![](../Attachments/setting-up-for-a-lesson/orchard-setup.png)
     
     Select these options:
     
       - **Site name:** Enter any name you like that's related to the lesson you're following
       - **User name:** admin
       - **Password:** password
       - **Data store:** SQL Server Compact
       - **Recipe:** Default
       
  1.  Click `Finish setup`
  
The site will now do its initial prep and present you with the `Welcome to Orchard!` start screen.

## Preparation completed
You can now return to the lesson that brought you here.