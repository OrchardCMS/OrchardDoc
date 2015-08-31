Orchard CMS uses GitHub for its source code management and issue tracking. You can find the main Orchard CMS repository at:

  - [https://github.com/OrchardCMS/Orchard](https://github.com/OrchardCMS/Orchard)

We welcome community contributions but please read these guidelines before you start work.

## First step - open an issue or discuss an existing one

If you're new to contributing then you should discuss your plans before you start work. This is especially true if it involves building new features or changing the architecture.

Don't know where to start? There are lots of existing bugs which have been reported the issue tracker.

All of Orchard's planning is done in the GitHub repo's [issue tracker](https://github.com/OrchardCMS/Orchard/issues).

If your idea / bug isn't in the issue tracker (don't forget to check the closed issues as well - it might have been fixed in a development branch) then open a new issue to start a discussion with the community.

## Branches

The repository is split into two main development branches, `1.9.x` and `dev`. There is also a `master` branch which represents the latest released stable version of the software. While other features are being worked on you might find some additional branches temporarily created but they are just to test out ideas and they will get merged back into one of the main branches later on.

All the active feature work is being done by the core team in the `1.9.x` branch. Whenever a new release is ready, changes get merged from `1.9.x` to `master`. Master is a stable branch and is normally always in a "green" state. 

The `1.9.x` branch is the short-cycle dev branch. This is where features and bug fixes are being worked on for the next point release (for example, the difference between v1.9.1 and v1.9.2).

The `dev` branch is the long-cycle dev branch. This is where bigger features are being worked on that won't make it into the next version of Orchard CMS.

There is also a separate repository called [Brochard](https://github.com/OrchardCMS/Brochard) which is the implementation of Orchard CMS in Asp.Net VNext (also known as DNX).

## Milestones and labels

New issues are opened all the time. After an issue is submitted the core team members will it. When it is acccepted as a valid task to complete it will be given a milestone and perhaps some labels. The milestone indicates which branch any pull requests for the issue should be sent to.

**SCREENSHOT** milestones, labels

You might also see some additional tags like a severity level or further categorization. These labels can help you prioritise which issues you should give your attention first based on their urgency or your speciality as a developer.

## How to fork and work with the repository

The easiest way to get started with GitHub is to use [Github Desktop](https://desktop.github.com/). This software has a built-in tutorial which will teach you the basics when you first install it.

You can also create a fork via the GitHub website. GitHub have provided a guide explaining [how to fork a repo](https://help.github.com/articles/fork-a-repo/).

GitHub is powered by [Git](http://git-scm.com/). If you're an advanced user with experience of using Git on the command line then you can interact with GitHub hosted repositories as you normally would. If you're interested in learning then GitHub have their own [interactive code school](https://try.github.io/) and the entire [Pro Git book is available](http://git-scm.com/book/en/v2) has also been made available by it's authors and is endorsed by the official Git website.

## Working on an issue

By now you should have agreed with the community what you're working on, you should know which branch you're targeting and you should have created your own fork.

When working on an issue you should create a branch in your local clone per-issue. This branch isolates your changes from the main branch and you can merge the branch back in to the main codebase later on with a pull request.

Please work on only one one issue per branch / pull request.

Once you've made your changes you need to publish your local changes back to the remote fork in your GitHub account. The basic Git concept behind this process is to `commit` your local changes and the `push` the branch to your remote copy on GitHub.

This can be done in many ways:

  - [Using GitHub Desktop](https://help.github.com/desktop/guides/contributing/committing-and-reviewing-changes-to-your-project/)
  - From within Microsoft WebMatrix 3
  - From within Microsoft Visual Studio
  - Using Git Extensions
  - Using Git on the command line

If you are just starting out with Git then you should use GitHub Desktop to make this process simple for yourself.

Once this is done, your changes are on GitHub, but not yet in the project's official repository. To get it there, you'll need to ask us to pull the changes in. In order to do that, send us a pull request.

## Submitting a pull request

When you have finished your work on the issue you can create a pull request. A pull request opens a dialog with the community to review your work and provide feedback. If 

Creating a pull request is best done from within the GitHub.com website. You can create pull requests using other techniques but using the GitHub.com has a clear interface so that you can make sure you are creating a pull request with the correct branch and you can have one final check of the files before you initiate it.

Navigate to your forked copy of the OrchardDocs repo. Its url will be https://github.com/{YourUserName}/OrchardDoc

You should see a create pull request bar along the top of your repos page:

**** SCREENSHOT ****

**** COMPLETE SCREENSHOTS PROCESS ****

********** also dont forget the closes #issue in subject
****** - The first line should be short, less than 80 characters 


While committing your changes, please follow this convention for commit messages:

- If linked to a work item, it should start with its number, like `#12345: This is a change`
- If linked to a work item the last line should reference it to automatically mark it as resolved: `Work Item: 123245` 

Once this is done, your changes are on CodePlex, but not yet in the project's official repository. To get it there, you'll need to ask us to pull the changes in. In order to do that, send us a pull request from the fork management screen under the source control tab on CodePlex:

![](../Upload/submitting-patches/PullRequest.jpg)

You will receive an e-mail update from us when your patch submission has been evaluated and applied.

## Pull request review process
*************************
The Orchard development team meets every week to review pull request and triage issues. During this meeting we'll decide if the pull request fulfills the prerequisites or comment on what improvements should be applied.

If an agreement is reached to accept the pull request then it will be marked as so and someone with commit rights on the main repository will accept the pull request and merge your work into the Orchard CMS repository. This process might involve altering the history to remove any feeback loop changes which don't add anything to the work done.

## What to do once your pull request has been reviewed
*********************
You will get a notification when there is any activity on your pull request. If you

**SCREENSHOT** Notifications

Once the patch master has looked at your contribution and has either accepted and integrated it, or he has rejected it, there is no point in the branch still existing, so we recommend that you go ahead and delete it in order to keep the list of branches as clean as possible in your fork. Moreover, if you don't need the branch anymore you can also delete it, but we suggest you use the same fork for all your pull request, by using branches for each of them.
