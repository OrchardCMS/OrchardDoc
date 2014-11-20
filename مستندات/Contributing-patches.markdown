Creating **a fork should be preferred** because it makes merging a lot easier.

## Working on a Patch

When working on a patch, your local enlistment should in most cases be synchronized to the latest check-in in the **contributions** branch (contributions tip). Working on the dev branch would only expose you to nasty things (like the application breaking all the time).

Another thing to consider is the status of the issue you are fixing. Bugs that are marked as "Proposed" have been reported, but not yet triaged by the team. It just means that we didn't have time to look at them and see if they are valid, or duplicates of existing issues, or have since already been fixed. Thus, for best results, please send patches for issues that are marked as "Active".

Please only fix one issue per patch: if one fix is rejected and the other accepted, it would be more difficult for us to integrate the accepted fix and we might have to reject the whole patch and ask you to resubmit. One fix per patch also makes the source tree's history cleaner and more readable.

## Submitting a Patch as a Fork

If you go to the source code tab of the project, you'll see links on the top of the page to manage and create forks. Each fork is a copy of the full source code repository that you own entirely.

You can create a new fork by clicking "Create fork". You can then enter a name for your fork, typically the name of the feature you want to work on or a bug number if you're patching a bug. The description is optional.

Once you've hit save, you'll see a view of the forks that you own. Each of them has its own clone URL. What you want to do next is clone that remote CodePlex repository to your local machine in order to be able to start working.

Once you've made your changes and are ready to submit them back to us, right-click the clone directory and choose "Hg commit". Click "commit". This commits the change to the local repository clone. The patch has not yet been submitted to CodePlex.

![](../Upload/submitting-patches/HgCommit_675.PNG)

Next, you'll want to push your changes to your private fork on CodePlex through the Hg Repository Explorer.

Before preparing to submit a contribution, be sure to: 
1.  Mark new files as added
2.  Mark missing files as deleted
3.  Use Hg update to ensure the local copy is current
4.  Verify sources build and unit tests pass
5.  Do any merge and re-base operations necessary to get your local change tree to what you actually want to submit (see [Mercurial documentation](http://mercurial.selenic.com/wiki/Mercurial) if in doubt about what this means). In particular, before you submit, your enlistment should be **merged into contributions tip**.

Once this is done, your changes are on CodePlex, but not yet in the project's official repository. To get it there, you'll need to ask us to pull the changes in. In order to do that, send us a pull request from the fork management screen under the source control tab on CodePlex:

![](../Upload/submitting-patches/PullRequest.jpg)

You will receive an e-mail update from us when your patch submission has been evaluated and applied.

More information about fork management on CodePlex can be found in this post: <http://blogs.msdn.com/codeplex/archive/2010/03/05/codeplex-mercurial-support-for-forks.aspx>.

## Submitting a Patch as an Attachment to an Issue

An alternative to using a fork is to package your changes into a file and then to attach that file to the issue or feature proposal corresponding to your patch.

In order to prepare your patch, you'll need to get a local enlistment of the source code of the application and work off of that.

Before preparing to submit a contribution, be sure to: 

1. Mark new files as added


2. Mark missing files as deleted


3. Use Hg update to ensure the local copy is current


4. Verify sources build and unit tests pass


5. Do any merge and re-base operations necessary to get your local change tree to what you actually want to submit (see [Mercurial documentation](http://mercurial.selenic.com/wiki/Mercurial) if in doubt about what this means).

Once this is done, go into the Repository Explorer for your local enlistment, right-click your latest revision and choose "Export Patch...":

![](../Upload/submitting-patches/ExportPatch.png)

You should now have a ".patch" file that you can attach to the issue it fixes in the [CodePlex Issue Tracker](http://orchard.codeplex.com/WorkItem/AdvancedList.aspx) by clicking "Choose File" under "Attach File" and then uploading.

If you have the permissions to do so, you can change the status of the issue to "Fixed".

Once the patch has been attached to the issue, please send us e-mail at ofeedbk@microsoft.com so that we can evaluate and integrate it.

## What to Do Once Your Patch Has Been Processed

Once the patch master has looked at your contribution and has either accepted and integrated it, or he has rejected it, there is no point in the fork still existing, so we recommend that you go ahead and delete it in order to keep the list of forks as clean as possible.
