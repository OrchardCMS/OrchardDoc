# Enlisting

## Enlisting in the Source Code Using Mercurial and TortoiseHg

The Orchard project source code is hosted on CodePlex and can be accessed using a Mercurial client. This page explains how to set-up your development environment, assuming you are a developer on the project or want to work on a patch or contribution.

If you are not a developer on the Orchard project, you can download the source code, compile it and play with it, but you won't be able to submit changes other than by submitting patches.

When using a distributed source control system such as Mercurial, it's important to understand that the latest check-in on the CodePlex repository is not necessarily the one you want to download or sync to as it may be a different branch than the default branch. When synchronizing your enlistment, please make sure that you sync to the latest in the default branch.

For more information about Mercurial, please read [understanding Mercurial](http://mercurial.selenic.com/wiki/UnderstandingMercurial), [branching in Mercurial](http://mercurial.selenic.com/wiki/BranchingExplained?highlight=%28%5CbCategoryHowTo%5Cb%29) or [TortoiseHg user manual](http://tortoisehg.bitbucket.org/manual/0.9/).

### Step 1: Install TortoiseHg
Download and install [TortoiseHg](http://tortoisehg.bitbucket.org/) (TortoiseHg is the Mercurial client that we use, but you should be able to access the repository using any Mercurial client).

### Step 2: Enlist in the Source Code Using TortoiseHg

In Windows Explorer, navigate to the local directory where you want your copy of the source code to live, right-click and choose "TortoiseHG/Clone".

![](../Upload/screenshots_675/hg_clone.png)

As the URL of the source, type "https://hg01.codeplex.com/orchard":

![](../Upload/screenshots/hg_clone_dialog.png)

Click "Clone". You will not be prompted for your CodePlex login and password until you try to commit changes.

### Step 3: Building and Running the Orchard Source

You can build and run Orchard either from the Visual Studio 2010, or using a command-line batch file.

#### Using Visual Studio 2010

Open Orchard.sln from the Mercurial enlistement directory, in "src". For information on the structure of the Orchard solution, see the [Source code organization](Source-code-organization) page of this wiki.

![](../Upload/screenshots_675/devenv_orchard_sln.png)

Hit F5 to build and run the application

![](../Upload/screenshots/vs_orchard_sln.png)

#### Without Visual Studio 2010

Build the application from the command-line following the instructions found here: [Building and deploying Orchard from a source code drop](Building-and-deploying-Orchard-from-a-source-code-drop). You may use IIS or IIS Express to run the application.

## Everyday TortoiseHg Use

The part of TortoiseHg you're going to use the most is the Repository Explorer (right-click on a directory from the Windows Explorer to find it, it's called "Hg Workbench"). For example, to view the recent changes from CodePlex, just click "refresh". The repository explorer gives you a view of all the branching and merging that has been going on on the server. You can examine each change, read its description and view diffs. You can also right-click a change and update your local repository to it by clicking "update".

![](../Upload/source-enlistment/HgExplorer_675.PNG)

You can also filter by branch, which is useful for example if you're only interested in the more stable
"default" branch (everyday work is happening in special branches or in the common "1.x" branch).

## Viewing the Source Code Without Enlisting

If you are not a developer on the Orchard project, you can still download the source code on this page:

[http://orchard.codeplex.com/SourceControl/ListDownloadableCommits.aspx](http://orchard.codeplex.com/SourceControl/ListDownloadableCommits.aspx)

Click on the latest change set from the branch you 're interested in (if you don't know which, we recommend you use the latest in the default branch, which is going to be more stable than the dev branch on which everyday work is being done). The branches a particular checkin belongs to is displayed in its comment:

![](../Upload/source-enlistment/HgCodePlex.PNG)

This enables you to browse the source code directly on the web, which is useful if you just want to check something or for educational purposes, but you can also download a local copy by clicking the download link. You can then unzip that file onto your local hard drive, compile the code and even modify it.

# Branches

* **default** the sources for the latest release (1.0, 1.1, 2.0, etc.)
* **1.x** working branch when we get close to a release
