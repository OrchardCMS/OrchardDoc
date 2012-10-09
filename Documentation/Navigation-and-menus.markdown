
# Building up a menu structure

> This information is for Orchard version >= 1.5.1.0.

There are different ways to build up a menu structure. Here we will show two common methods that could be used:

* Adding menu items first, content later
* Content first, navigation later

## Adding menu items first, content later

In the Orchard administration panel click the **Navigation** menu item. 
You will see that there is a default menu available, called 'Main Menu'.
The right side contains all types of menu items that you can add:
* Content Menu Item
* Custom Link
* Html Menu Item
* Query Link

Click *Add* next to the **Content Menu Item** to add a new menu item.
On the 'Create Menu Item' page you can fill in the Menu text.
Either you can already select your Content Item (e.g. a Page) where you want to link to by selecting the
**Browse** button under the **Content Item** section. By default the content item is empty.
If you plan to first fully create your navigation structure and link up your pages later you only have to edit
your menu item and select the **Browse** button to attach a Content Item (your Page).
This method could be prefered when you first want to style your website to see all menu items.


## Content first, navigation later

Here we first create a new Page (or edit a Page). 
At the bottom you will see a section **Menu Item**. Check the **Add on a menu** checkbox to see the menu options
for that page. The **Menu text** is the name of your menu item. By default the **Main Menu** will be used where
the Menu Item will be added to. 
When you now **Save** your page and navigate to the **Navigation** menu item on the left side you will see
that the new menu item that you created was added to the Main Menu.

# Creating a submenu

Creating a submenu is very easy:
Navigate to the **Navigation** section. If you **hover** an already added Menu Item with your mouse, you'll see
that you can drag and drop the Menu Item.
The trick is to simply drag the Menu Item a bit to the right until it snaps to a sub container. 
Now you can visually create your navigation hierarchy without having to configure anything.
A simple mouse touch is enough.

# Managing menus on older versions of Orchard (before 1.5)

Orchard <1.5 has a very simple main menu feature that is a list of menu item text and links to display,
accessible from the **Navigation** link in the Orchard admin panel.  When you add an item to the main menu
using the page or blog post editor screens, a new entry is added here.  You can use this screen to rename,
reorder, and remove menu items. (This will not delete the content item; it will only remove the menu item).

![](../Upload/screenshots_675/manage_menu_675.png)

You can also add arbitrary URLs in your menu, whether external or pointing to a page in your Orchard site,
by adding a new menu item.  Note that only items added in this way have an editable URL on this screen.
Content item URLs must be edited from the editor screen for that content item instead.

To reorder menu items, type a numeric index in the "Position" textbox.  Position indexes can be any of
the following format:

* **Integer**: 1, 2, 3, etc.
* **Decimal**: 1.1, 1.2, 1.3, etc
* **Multi-part number**: 1.1.1, 1.2.1, 1.2.2, etc

When you are satisfied with your changes, click **Update All** to update the main menu of your site
(effective immediately).
