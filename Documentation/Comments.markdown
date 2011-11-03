

# Scenarios

## A user can comment content entries

1. User browses the site and wants to comment a blog post

2. User scrolls down to the bottom of the post and starts entering the mandatory information: name, e-mail and comment. He also enters the URL of his own blog and checks "remember me" so that he doesn't have to enter that information when he returns. He clicks the "add comment" button.

Validation rules check that the e-mail, name and text was entered before validating the comment.

When "remember me" is checked, a cookie with a long expiration is set on the client to store the information to remember.

3. The comment is published after validation by the spam filter.

## A user can receive notifications when answers to his comments are published

1. When adding a comment, a user can check "receive e-mail notifications for new comments on this post".

2. A new comment gets added to the same post.

3. The user receives an e-mail to notify him of the new comment.
The e-mail contains the text of the new comment and a link (using a # anchor) to the new comment.

**Status: Not implemented yet**

## A user can subscribe to the comments feed for any item

1. The user can use the feed icon for the comment stream to add it to his favorite feed reader (modus operandi varies with readers and browsers).

2. New comments get published.

3. User sees the new comments in feed reader.

**Status: Not implemented yet**

## The site administrator gets notified when new comments are added

1. A user adds a comment.

2. The administrator receives an e-mail with a link to the admin UI for comments.

3. The administrator can then click on a comment and moderate it or click the link to the content item in order to answer the new comment.

**Status: Not implemented yet**

## The site administrator can manage comments

1. The administrator of the site clicks "Manage comments" from the admin UI's global menu or from a "manage comments for this item" link at the bottom of the admin UI for a specific content item or from an alert e-mail he received from the site.

2. He checks the checkbox in front of a bunch of comments he recognizes as spam, chooses the "Delete" bulk action and clicks "Apply".

3. He clicks on a specific unpublished comment, reads it and then clicks "publish".

4. The new comment can be read by anyone.

## The site administrator can configure comment publication rules

1. The administrator goes to the permission administration screen.

2. He changes the "Add a comment without validation" right to apply only to authenticated users.

3. Comments by non-authenticated users are not published by default anymore, but only when an administrator publishes them.

## A content owner can close comments on his items

1. A content author feels the comment thread on one of his blog posts is spinning out of control into a troll fest.

2. He clicks "Close comments on this item".

3. No new comments can be added.

## Comments are threaded

1. A user sees a specific comment he wants to answer.

2. He clicks the "reply" button next to that specific comment.

3. He types an answer that is stored as an answer to the original comment.

4. The resulting new comment gets added at the end of the comment thread and has a link to the original comment.

## Authenticated users and author comments appear different

1. An author answers a comment on one of his content items.

2. His comment appears in the comment thread with a different style.

**Note:** authenticated users' comments could also appear differently (from non-authenticated and also from author comments) as they can have a different weight in people's minds on some sites.

# Spam protection

Spam protection is strictly necessary on a comment feature but is difficult to implement. Fortunately, many solutions already exist and can be integrated into existing applications.

The comment infrastructure should be ready to be extended with various spam protection technologies such as CAPTCHA or Akismet. We will integrate Akismet by default and make it easy for users to obtain their own Akismet key.

Administrators can mark comments as spam rather than delete them, which could result in the comment being fed into the spam protection provider's feedback service.

# Permissions
In this context, the owner is the owner of the content item being commented (the container of the comments).


Permission                                       | Anon. | Authentic. | Owner | Admin. | Author | Editor
------------------------------------------------ | ----- | ---------- | ----- | ------ | ------ | ------
Add Comments                                     | Yes   | Yes        | Yes   | Yes    | Yes    | Yes
Manage Comments (implies all others)             | No    | No         | Yes   | Yes    | No     | Yes
Close Comments                                   | No    | No         | Yes   | Yes    | Yes    | Yes
Moderate comments                                | No    | No         | Yes   | Yes    | No     | Yes
