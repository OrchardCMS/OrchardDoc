Creating **a branch inside a fork should be preferred** because it makes merging a lot easier.

## Prerequisites

- In order to create pull requests, you will need to have a good understanding of git, the source code management tool.
- Before working on a pull request, please file a work item describing what you are trying to achieve. This will let everyone talk about the issue and the best way to solve it.

## Working on a Pull Request

When working on a pull request, your local enlistment should in most cases be synchronized to the latest check-in in the current development branches. If you intend to provide a bug fix then the best branch to work on is the short-cylce dev branch, currently named 1.8.x. If instead you intend to provide a new or enhanced feature then it's recommended to use the long-cycle dev branc, currently named 1.x.

Another thing to consider is the status of the issue you are fixing. Bugs that are marked as "Proposed" have been reported, but not yet triaged by the team. It just means that we didn't have time to look at them and see if they are valid, or duplicates of existing issues, or have since already been fixed. Thus, for best results, please send pull requests for issues that are marked as "Active".

Please only fix one issue per pull request: if one fix is rejected and the other accepted, it would be more difficult for us to integrate the accepted fix and we might have to reject the whole pull request and ask you to resubmit. One fix per pull request also makes the source tree's history cleaner and more readable.

## Submitting a Pull Request as a Fork/Branch

If you go to the source code tab of the project, you'll see links on the top of the page to manage and create forks. Each fork is a copy of the full source code repository that you own entirely.

You can create a new fork by clicking "Create fork". You can then enter a name for your fork, typically the name of the feature you want to work on or a bug number if you're patching a bug. The description is optional.

Once you've hit save, you'll see a view of the forks that you own. Each of them has its own clone URL. What you want to do next is clone that remote CodePlex repository to your local machine in order to be able to start working.

Based on the branch you want to submit your pull request on (1.8.x or 1.x) you will need to create a new branch dedicated to this work item. For instance you can name it based on the work item number or whatever you want which will help you organize your fork.

Once you've made your changes and are ready to submit them back to us, commit your changes then push your branch.

While committing your changes, please follow this convention for commit messages:
- The first line should be short, less than 80 characters 
- If linked to a work item, it should start with its number, like `#12345: This is a change`
- If linked to a work item the last line should reference it to automatically mark it as resolved: `Work Item: 123245` 

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
3. Verify sources build and unit tests pass
4. Commit your changes

Once this is done you can create a patch file [using git](http://git-scm.com/docs/git-format-patch).

You should now have a ".patch" file that you can attach to the issue it fixes in the [CodePlex Issue Tracker](http://orchard.codeplex.com/WorkItem/AdvancedList.aspx) by clicking "Choose File" under "Attach File" and then uploading.

If you have the permissions to do so, you can change the status of the issue to "Fixed".

Once the patch has been attached to the issue, please send us e-mail at ofeedbk@microsoft.com so that we can evaluate and integrate it.

## Pull Request Review Process

The Orchard development team meets every week to review pull request and triage work items. During this meeting we'll decide if the pull request fulfills the prerequisites or comment on what improvements should be applied.

If an agreement is reached to accept the pull request then it will be marked as so and someone with commit rights on the main repository will pull the changes in Orchard. This process might involve altering the history to remove any feeback loop changes which don't add anything to the work done.

## What to Do Once Your Patch Has Been Processed

Once the patch master has looked at your contribution and has either accepted and integrated it, or he has rejected it, there is no point in the branch still existing, so we recommend that you go ahead and delete it in order to keep the list of branches as clean as possible in your fork. Moreover, if you don't need the branch anymore you can also delete it, but we suggest you use the same fork for all your pull request, by using branches for each of them.
