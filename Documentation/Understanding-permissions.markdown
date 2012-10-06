> This topic has been updated for the Orchard 1.0 release.

Each role has a set of permissions assigned to it, and these permissions indicate which actions a user in that role can perform. For each role, you can only grant permissions; you cannot specifically deny a permission. A user's permission set consists of all granted permissions for all roles that the user belongs to.

To assign or review permissions for a role, click the **Roles** link.
![](../Upload/screenshots/Permission_ManageRoles.png)

Click **Edit** for the role you want to modify or review.
![](../Upload/screenshots_675/Permission_ManageRolesMenu.png)

By default, Orchard includes a number of roles with default permissions:

* **Administrator** - Can perform any operation (has all permissions)
* **Editor** - Can author, publish and edit his own and others' content items.
* **Moderator** - Can moderate comments and tags only.  No authoring permissions.
* **Author** - Can author, publish and edit his own content items
* **Contributor** - Can author and edit his own content items, but not publish them (save draft only)
* **Anonymous** - Can view the front-end of the site only.
* **Authenticated** - Can view the site front-end, and perform other operations depending on the site and other role permission settings.

## Implied Permissions
Some permissions specify whether a user is allowed to perform a single action; other permissions specify whether the user is allowed to perform a group of actions. The permissions that pertain to a group of actions are typically higher-level permissions that logically include lower-level actions. When you grant a higher-level permission that relates to a group of actions, the lower-level permissions are implicitly included. For example, if you grant a role permission to manage blogs, you are also granting that role  permission to edit, publish, and delete blogs.

You can see which permissions are explicitly or implicitly granted by examining the check boxes in the **Allow** and **Effective** columns. The **Allow** column shows which permissions are explicitly granted and the **Effective** column indicates which permissions are explicitly or implicitly granted. The following image shows that **Manage blogs** was specifically granted to the role and the other permissions were implicitly granted.
![](../Upload/screenshots_675/Permission_ManageBlog.png)

If you unselect the **Manage blogs** permission, all of the other permissions are also revoked.

The following image shows a role with **Edit any blog posts** granted. **Edit own blog posts** is implicitly granted.
![](../Upload/screenshots_675/Permission_EditBlogs.png)

The following image shows a role with only **Edit own blog posts** granted. No permissions are implicitly granted with this selection.
![](../Upload/screenshots_675/Permission_EditOwnBlog.png)

<!--## Defining and Customizing Permissions
For information about how to customize permissions, see [Adding custom permissions](Adding-custom-permissions). For advanced concepts, see [Permissions](Permissions).-->

## Orchard.ContentPermissions

> This applies to the Orchard.ContentPermissions Module, available since Orchard 1.5.1

When enabling the ContentPermissions module, you can define item-level permissions for the front end.
This allows you to protect your Projections or own Content Types.