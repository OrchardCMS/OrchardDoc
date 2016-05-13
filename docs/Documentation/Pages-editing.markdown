

## Page creation
The page draft is created in the database when the save or preview button is clicked (preview saves the draft implicitly). In order to save, the state of the page form must be valid.

## Validation rules
The slug rules are described here: [Slugs](slugs).

* The title field cannot be empty. Message: "Please specify a title."
* The title field can contain any character except for tabs, newlines/CR and control characters. Message: "No control characters are allowed in the title field."
* If the radio button for later publication is checked, a date must be specified. Message: "Please specify a publication date."
* If a publication date is specified, it must be parsable under the current culture. Message: "'{0}' is not recognized as a valid date. An example of a valid date is: '{1}'." Substitute {1} with the current date, formatted with the current culture.
* The publication date, if specified, must be in the future. "Please specify a future date."

## Orphaned contents
When the user switches the page to a layout that has less zones than the previous ones, he is potentially creating orphaned contents. We don't throw that contents away or try to merge them. We also don't try to reassign if the zone names are different, even if the number of zones is the same.

Instead, we display the following message in the top alert zone: "You have switched to a template that does not have the same content zones as the previous one, resulting in some of your contents not showing up on your site. You can either delete that content or copy it into another zone."

In the admin screen for the page, we show the orphaned contents with an alert "This content is assigned to a zone that does not exist in the current template. Please delete it or copy it to another zone."

When the page is saved, we delete empty orphaned contents. By empty, we mean empty of contents, not necessarily empty string: &lt;p&gt;&lt;/p&gt; is empty contents. Warning, &lt;img src="foo.gif"/&gt; is not.

## Preview
When the user clicks the "Preview" button, we need to create a draft. We've considered making that draft "temporary" and not a full draft. We also talked about the potential concurrency issues associated with this. Those concurrency issues actually also exist when saving a draft, the difference here is that the operation is implicit.

For the moment, we'll ignore the concurrent editing scenarios and let the latest draft, implicit or explicit, win. There is still always only one draft at any given time.
Clicking preview is exactly equivalent to saving as a draft and then navigating to the url for the draft in a new window. The draft is not automatically deleted.

When the preview button is clicked and JS is disabled, we save a draft then redirect to the preview page. The user can go back to the edit page UI by clicking "edit this page" in the preview or by hitting back.

When JS is enabled, we can override the default behavior of the button and open the preview in a new window.

## Changing template
The behavior when clicking the change template button is to be determined. We could warn about unsaved changes when JS is enabled, or we could implicitly save, or we could persist the data in hidden fields.

## Page Management
We are not implementing parent pages. In future iterations, we'll introduce ways to organize pages and other kinds of contents using tags and / or categories.

## Security
We do not introduce security in the iteration as this would require making a decision on user management / membership, which we are not ready to do at this point. It should be a high priority item for future iterations.

## Media Management
We do not implement media management this iteration but it should be a high priority item for future iterations.

## History / Revisions
We do not implement history now but so that we do not have to throw away our implementation of drafts when we do, we implement the draft feature now with history in mind. In particular, the database structure will be the one that we'll eventually use for storing revisions. A draft is a special case of revision.

## Error information bar
Error messages and warnings in the admin UI are uniformly presented in a colored bar that sits between the title area and the top of the current screen. The bar takes all the width of the page.

Errors are on a red background, warnings on an orange background, informational / confirmation messages are on a cream background.

When JavaScript is enabled, we can animate the appearance of the message (Jon?) to better attract attention.
The messages have an optional icon, a type (error / warning / notification) and a text message. They are informational and may state possible action steps for the user, but they do not contain any UI (confirmation or otherwise) other than the icon and message.

The bar is temporary and disappears as soon as any user action results in a POST or an Ajax request.

The bar is able to expand to display more than one message at a time, stacked one above another.

The validation summary when it exists goes into the error bar.

The admin views will have to provide a hook for the message bar to display.

## Dialogs
Some user actions will result in the system prompting him for additional information. One such example is bulk delayed publishing, where we need to prompt for the publication date.

In the non-JavaScript case, this is done by displaying the dialog UI as a separate screen.

When JavaScript is enabled, the same dialog is shown as a lightbox modal dialog style without navigating away from the current page.

Dialogs have a cancel button.
