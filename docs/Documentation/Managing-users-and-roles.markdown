Managing Users and Roles
========================
Orchard provides the ability to manage users and roles for your site, with users assigned to one or more roles, and different permissions associated to each role.

To manage the users in your site, click the **Users** link in admin panel.

![](../Upload/screenshots/Users_select.png)

By default, there is ony one user, which is the admin user that is configured in the Orchard setup screen on first install. To add an additional user, click **Add a new user**. You can also edit, remove, and disable user accounts from this screen.

![](../Upload/screenshots_675/Users_manage.png)

When adding a new user, specify a user name, email and password, along with one or more roles for the user.  The roles determine what permissions a user has on your site, in other words, what operations they are allowed to perform.  The effective permissions for a user are the union of permissions for all applied roles.  Permissions only grant operations to a user; they never deny them.

![](../Upload/screenshots_675/add_user.png)

You can also configure the roles in your site by clicking the **Roles** link in the admin panel.

![](../Upload/screenshots/Users_roles.png)

By default, Orchard includes a number of roles with default permissions:

* **Administrator** - Can perform any operation (has all permissions)
* **Editor** - Can author, publish and edit his own and others' content items.
* **Moderator** - Can moderate comments and tags only.  No authoring permissions.
* **Author** - Can author, publish and edit his own content items
* **Contributor** - Can author and edit his own content items, but not publish them (save draft only)
* **Anonymous** - Can view the front-end of the site only.
* **Authenticated** - Can view the site front-end, and perform other operations depending on the site and other role permission settings.




To edit the permission for a given role, click **Edit** next to the role name.

![](../Upload/screenshots_675/edit_role_admin.png)

To permit a limited number of self-management options expand the **Settings** tab and click **Users**:

* Users can create new accounts on the site
* Display a link to enable users to reset their password 
* Users must verify their email address 
* Users must be approved before they can log in 
Change History
--------------

* Updates for Orchard 1.8
    * 9-8-14: Updated screen shots for Managing users and roles.


