# Enlisting

## Enlisting in the Source Code Using Git and Git Extensions

The Orchard project source code is hosted on CodePlex and can be accessed using a Git client. This page explains how to set-up your development environment, assuming you are a developer on the project or want to work on a patch or contribution.

If you are not a developer on the Orchard project, you can download the source code, compile it and play with it, but you won't be able to submit changes other than by submitting patches.

When using a distributed source control system such as Git, it's important to understand that the latest check-in on the CodePlex repository is not necessarily the one you want to download or sync to as it may be a different branch than the master branch. When synchronizing your enlistment, please make sure that you sync to the latest in the master branch.

For more information about Git, please read [Git Basics](http://git-scm.com/book/ch1-3.html), [Basic Branching and Merging](http://git-scm.com/book/en/Git-Branching-Basic-Branching-and-Merging) or [Git Extensions user manual](https://git-extensions-documentation.readthedocs.org/en/latest/).

### Step 1: Install Git Extensions
Download and install [Git Extensions](https://github.com/gitextensions/gitextensions) (Git Extensions is one of many Git clients, but you should be able to access the repository using any Git client).

### Step 2: Enlist in the Source Code Using Git Extensions

In Windows Explorer, navigate to the local directory where you want your copy of the source code to live, right-click and choose "GitEx Clone".

![](../Upload/screenshots/git_context_menu.png)

As the URL of the source, type "https://git01.codeplex.com/orchard":

![](../Upload/screenshots/git_clone.png)

Click "Clone". You will not be prompted for your CodePlex login and password until you try to commit changes.

### Step 3: Building and Running the Orchard Source

You can build and run Orchard either from the Visual Studio 2012, or using a command-line batch file.

#### Using Visual Studio 2012

Open Orchard.sln from the Git enlistement directory, in "src". For information on the structure of the Orchard solution, see the [Source code organization](Source-code-organization) page of this wiki.

![](../Upload/screenshots/git_cmd.png)

Hit F5 to build and run the application

![](../Upload/screenshots/git_solution_explorer.png)

#### Without Visual Studio 2012

Build the application from the command-line following the instructions found here: [Building and deploying Orchard from a source code drop](Building-and-deploying-Orchard-from-a-source-code-drop). You may use IIS or IIS Express to run the application.

## Everyday Git Extensions Use

The part of Git Extensions you're going to use the most is the Repository Explorer (right-click on the Git enlistement directory from the Windows Explorer to find it, it's called "GitEx Browse"). For example, to get the lastest changes from CodePlex, just click "Pull". The repository explorer gives you a view of all the branching and merging that has been going on on the server. You can examine each change, read its description and view diffs. You can also right-click a change and update your local repository to it by clicking "Checkout revision".

![](../Upload/screenshots/git_extensions.png)

You can also filter by branch, which is useful for example if you're only interested in the more stable "master" branch (everyday work is happening in special branches or in the common "1.x" branch).

## Viewing the Source Code Without Enlisting

If you are not a developer on the Orchard project, you can still download the source code on this page:

[https://orchard.codeplex.com/SourceControl/list/changesets](https://orchard.codeplex.com/SourceControl/list/changesets)

Click on the latest change set from the branch you 're interested in (if you don't know which, we recommend you use the latest in the master branch, which is going to be more stable than the 1.x branch on which everyday work is being done). The branches a particular checkin belongs to is displayed in its comment:

![](../Upload/screenshots/git_codeplex_changeset.png)

This enables you to browse the source code directly on the web, which is useful if you just want to check something or for educational purposes, but you can also download a local copy by clicking the download link. You can then unzip that file onto your local hard drive, compile the code and even modify it.

# Branches

* **master** the sources for the last release (1.0, 1.1, 2.0, etc.)
* **1.x** contains the sources of the day-to-day work
