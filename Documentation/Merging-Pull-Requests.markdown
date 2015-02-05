## Challenges of integrating a Pull Request

When a Pull Request has been reviewed and is ready to be merged it's usually marked with a __GG__ commnent meaning __Good to Go__. 
At this point any dev with commit rights should be able to merge it in the main repository. 
However we might need to rewrite the changes to keep the repository clean:
- By updating the commit message if it needs to be shortened or improved. For instance if the patch is related to a work item, the commit message should look like this:

```
#12345: Short message

A longer message than can span multiple lines and describe the reasonning behind the change.

Work Item: 12345
```

- By rebasing the changes on the top of the branch to keep a more readable changelog.
- By squashing the changes into a single commit.

Doing so can be tedious depending on your level of knowledge on git. To help with this a specific git alias can be used.

## GIT Alias to Merge changes from codeplex

- In your user's profile folder (e.g., `c:\users\sebros`) open the file `.gitconfig`.
- Anywhere in the file (at the end for instance) add a new alias like this:
```
[alias]
accept-pr = "!f(){ git checkout -b PR $1 && git pull $2 $3 && git rebase $1 && author=`git log -n 1 --pretty='format:%an <%ae>'` && git reset $1 && git checkout $1 && git commit -a -m \"$4\" && git commit --amend --author=\"$author\" --no-edit && git branch -D PR; };f"
```	
- If the `[alias]` section already exists, keep it

This `accept-pr` command is now accessible from the git console and will apply all the necessary steps.

* `$1`: The branch to apply the PR to, e.g., `1.8.x`, `1.x`
* `$2`: The url of the remote PR, e.g., `https://git01.codeplex.com/forks/jchenga/orchard`
* `$3`: The branch to pull from the remote PR, e.g., `issues/20311`
* `$4`: The commit message for the squashed commit, e.g., `$'#1234: Short \n Long \n Work Item: 1234'`

The parameters $2 and $3 can be found in the modal dialog which appears when clicking on the `Accept` link of the pull request page on codeplex. For instance it will show up a line like this:

`git pull https://git01.codeplex.com/forks/jchenga/orchard issues/20797`, where 
- `$2` is `https://git01.codeplex.com/forks/jchenga/orchard`
- `$3` is `issues/20797`

### Usage

```
accept-pr 1.8.x https://git01.codeplex.com/forks/jchenga/orchard issues/20797 $'#20797: Fixing taxonomy handler exception\n\nWork Item: 20797'
```

If this command results with an error, it's probably because the PR is too old and there are some merge conflicts. In this case reopen the PR by requesting the user to rebase his changes on the targeted branch or to merge the conflicts, clean you local changes, then try again.
If at this point you don't know what you doing or you have a doubt, please contact another committer for help.

Finally, push the commits, and mark the PR as accepted.


