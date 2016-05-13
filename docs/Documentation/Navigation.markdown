
Navigation and search are an essential part of CMS applications. This specification aims at defining the default navigation menu generation experience.


# Scenarios

#### The application contains one main menu by default
The application comes preconfigured with one static menu that is present in the header include of the default templates.

> The current implementation only allows one global flat menu for the whole site.

#### A menu item consists of a name, description, and target route/url
The name and description can have their default values extracted from the object being pointed to if available, and can be overridden on the menu item.

The choice of the target route or URL is made through a URL editor that should eventually become standard and shared for other components to use (for the moment it's just a textbox with validation).

Menu items can either point to a statically determined URL, or they can be attached to a routable content item, in which case the URL is not editable but is instead provided by the item's routable aspect.

#### An administrator can manage the set of menus and menu items from the application's admin panel

> The application currently supports only one menu, without support for nested menus.

The administrator can create new named menus and modify or delete existing ones.

An administrator can add, enable/disable, reorder, nest and delete menu items within a menu.

#### The main menu display is determined by a menu template included in the header template, so the markup is customizable by a theme author

Displaying the menu is done by including a partial view and giving it a specific named menu as the model. That partial view can be modified and overridden by themes.

> In the current implementation, there is only one menu, and the partial view is simply named menu.ascx.

#### The application may optionally contain one or more sub-menus to be displayed within application sidebar zones

Those "sub-menus" actually are other named menus. Until we build widgets, these other menus will have to be manually added to templates.

> Not implemented.

#### A navigation menu displays contextual links for every content item

Such a dynamic menu may be implemented as a helper API that asks all content providers to give parents, children (optionally hierarchical to a specified depth) and siblings from a given content item. The results of this call could then get rendered by a partial view using it as the model.

> Not implemented.

#### A user can choose to add a page or post to a menu as part of the page/post editing interface

This should be on by default for pages, off by default for posts.

The UI to add an item to a menu consists of a checkbox ("Included in navigation menu") and a name textbox that is pre-filled by default with the title of the item.

#### A menu widget can be configured to display the contents of a menu

See Widgets section for more detail. This is essentially the same scenario as above, except that the partial view is encapsulated into a widget. Will be implemented when the widget infrastructure exists.

> Not implemented.

#### The menu widget may be configured to show a static or dynamic set of items

The dynamic behavior is to display only the parent/children of the currently displayed item.

> Not implemented. Only one static menu at the moment.

#### The main menu and menu widget have progressive expand/collapse behavior

The menu widget has a setting for the depth at which it represents the site hierarchy. When JavaScript is not enabled, the sub-menus have a statically defined CSS class that hides them (the downlevel experience could actually be CSS dynamic menus). When JavaScript is enabled, better expansion logic can be added, using a jQuery plug-in preferably (developing a complete JavaScript menu is not a trivial task and could become a project in itself. We should concentrate first on the core scenario).

> Not implemented.

#### The application exposes an API for accessing menus and menu items that can be called from user code in a template/view

The API that asks content providers to contribute menu hierarchies knowing the current item could also take a menu name. This way, the "static" named menus could just be a special, default case of dynamic menus.

> Not implemented.

# Permissions
The owner in this context is the site owner.

Permission             | Anon. | Authentic. | Owner | Admin. | Author | Editor
---------------------- | ----- | ---------- | ----- | ------ | ------ | ------
Manage navigation menu | No    | No         | Yes   | Yes    | No     | No
