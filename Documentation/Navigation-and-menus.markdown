*This topic targets, and was tested with, the Orchard 1.8 release. It includes too a reference to navigation in Orchard <1.5*


There are different ways to build up a menu structure. Here we will show two common methods that could be used:

* Adding menu items first, content later.
* Content first, navigation later.

Of course they are not mutually exclusive, you can alternate both methods in the same site.

# Adding Menu Items First, Content Later
This method could be prefered when you first want to style your website to see all menu items.

In the Orchard administration panel click the **Navigation** menu item. 
You will see that there is a default menu available, called 'Main Menu'.
The right side contains all types of menu items that you can add:

* Content Menu Item
* Custom Link
* Html Menu Item
* Query Link
* Shape Link
* Taxonomy Link

Click **Add** next to the **Content Menu Item** to add a new menu item.
![](/Attachments/Navigation-and-menus/AddNewContentItemLink.png)

On the 'Create Menu Item' page you can fill in the Menu text.
Select **Browse** and link to any content item (e.g your Home Page). Later, when you have prepared your real target content item you can update the menu link.

![](/Attachments/Navigation-and-menus/CreateMenuItem.png)

![](/Attachments/Navigation-and-menus/SelectAContentItem.png)

# Content First, Navigation Later

Here we first create a new Page (or edit a Page). 
Select **New Page** on the left menu. Create an *About Us* page. Give it a title and a body.
At the bottom check the **Show on a menu** checkbox to see the menu options
for that page. The **Menu text** is the name of your menu item. By default the Page link will be added to the **Main Menu**.

![](/Attachments/Navigation-and-menus/CreatePageAndNavigation.png)

When you now **Save** your page and navigate to the **Navigation** menu item on the left side you will see
that the new menu item that you created was added to the Main Menu.

# Creating A Submenu

Creating a submenu is very easy:
Navigate to the **Navigation** section. If you **hover** over an already added Menu Item with your mouse, you'll see
that you can drag and drop the Menu Item.
Simply drag the Menu Item a bit to the right until it snaps to a sub container.  Remember that changes you made here won't be updated until you click the **Save All** in the bottom-right side of the page.

![](/Attachments/Navigation-and-menus/NotIndentedMenu.png)
![](/Attachments/Navigation-and-menus/IndentedMenu.png)



 
# Older Versions Of Orchard (Before 1.5)
Managing menus in older versions of Orchard was quite different.
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


### Change History
* Updates for Orchard 1.8
    * 4-24-14:  Added screenshots. Now you can't create a Content Menu Item and leave empty the content item; updated that part. Changed a bit the structure to comply with Orchard style documentation guidelines.
