
## Published version
A page can be published (publicly accessible) or not. When a page is first created, for example, it is not yet published.
Technically, unpublishing (taking pages offline) is done by Orchard by setting the IsOnline bit in the database record for the page to zero.

## Draft version
A page can have a draft version, which is a version that is not yet publicly available. Any modifications done on the draft version are without effect on the version of the page that is currently published (if there is one). The draft version exists precisely so that the page can be modified without affecting the version that the public sees.
A draft of any page is technically created by copying its row in the database to a new one with the IsDraft bit set to one. Publishing the draft is done by copying all data from the draft back into the published page row (except for id and the published bit) and deleting the draft row.

Technically, the database and model allow for the following states for a page:
* Not created yet (no record)
* Published does not exist, but there is a draft
* Not published, no draft
* Not published, draft exists
* Published, no draft
* Published, draft exists

This is simplified for the end user by only having a few possible actions in the admin UI that define the transitions between possible page states:
* Create
* Publish
* Unpublish
* Edit
* Revert

Here is a diagram of the state transitions:
![Publication workflow](../Upload/PublicationWorkflow.PNG)

The page list displays information about the existence of a draft using a torn page icon, and shows whether the page is online (published) or not using a check icon. The only actions that can be taken from this page are in the actions column.
The view action navigates to the currently published version (if there is one).
Edit goes to the edit page.
Delete deletes both draft and published page.
![List of pages](../Upload/ListPages.PNG)
