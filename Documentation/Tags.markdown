
The system can also be queried to provide all tags currently in use or to provide all content items that have been tagged with a given tag.

Because any content could be tagged, this will be implemented as a content part.


# Applicability of the taggable content part
The default setting for tags should be that they are available on any content type.

# Scenarios

## A content author can apply tags to any content item he creates
Except is the site administrator disabled the taggable aspect from the content type being edited, content items can be tagged through UI that is dynamically added to the admin UI for the current item.

1. The author goes to the admin page for his content item.

2. A tags section appears on the bottom of the admin page where the list of existing tags is presented as a checkbox list. There is also a textbox and an "add" button to add a new tag.

3. The author checks "Apples", "Pears" and types Orange into the text box, then clicks "add".

4. The author publishes the new version.

## A user of the site can navigate contents by tags

1. A user navigates to the site and sees a tag cloud in one of the columns.

For the moment, and until we have widgets, we will hard-code the tag cloud into the page templates.

2. The user sees a topic he's interested in: "Pears" and clicks the tag.

3. The user is then taken to a page that has a list of content items that have been tagged with "Pears". **Note:** this requires the list feature to be implemented.

4. (optional) The user can refine the search by clicking on "Orange" on the "sub" tag cloud that appeared on top of the search results.

5. The user clicks on the title of one of the items and can then read the full page.

# Permissions

The owner here is the owner of the content item being tagged for the tag content permission, and the site owner for the tag management right.

Permission                                 | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
Tag contents                               | No    | No         | Yes   | Yes    | Yes    | Yes
Manage tags                                | No    | No         | Yes   | Yes    | No     | No
