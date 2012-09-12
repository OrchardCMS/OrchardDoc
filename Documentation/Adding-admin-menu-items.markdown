An Admin menu is a menu which only appears in the admin website. There are 2 levels of admin menus available on the side menu and the second level is by default collapsed. Adding a third level is possible, but this will only be displayed as a tabbed navigation on top of the pages.

Adding an Orchard admin module starts with a class implementing the INavigationProvider:
    
    public interface INavigationProvider : IDependency {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }

In here the MenuName property should always return the value "admin", signalling to Orchard that this is an admin menu instead of a normal menu.

#Adding a single level

    using Orchard.UI.Navigation;
 
    namespace Orchard.Webshop 
    {
    public class AdminMenu : INavigationProvider
    {
        public string MenuName {
            get { return "admin"; }
        }
        
        public AdminMenu() {
            T = NullLocalizer.Instance;
        }
   
        private Localizer T { get; set; }

        public void GetNavigation(NavigationBuilder builder) {
            builder
                
                // Image set
                .AddImageSet("webshop")
 
                // "Webshop"
                .Add(item => item
 
                    .Caption(T("Webshop"))
                    .Position("2")
                    .Action("Index", "CustomerAdmin", new { area = "Orchard.Webshop" })       
                );
        }
    }
    }

This will result in a single item being added to the admin menu. The AddImageSet lets you create an image (in a set of related css files) to display in the navigation menu. Position is the order in which the menu's are displayed.

#Adding 2nd level menu items
By adding more .Add statements nested in the parent menu, we can generate a second menu level. With the .LinkToFirstChild we don't need an action anymore in the parent item, we'll use the first one from the first child.

        public void GetNavigation(NavigationBuilder builder) {
            builder
                
                // Image set
                .AddImageSet("webshop")
 
                // "Webshop"
                .Add(item => item
 
                    .Caption(T("Webshop"))
                    .Position("2")
                    .LinkToFirstChild(true)
                        .Add(localItem => localItem
                            .Caption(T("Customers"))
                            .Action("Index", "CustomerAdmin", new { area = "Orchard.Webshop" })
                        )
                         .Add(localItem => localItem
                            .Caption(T("Orders"))
                            .Action("Index", "OrdersAdmin", new { area = "Orchard.Webshop"  })
                        )
                );
        }

#Adding multiple tabs to a page (3rd level)

For this we can use the .LocalNav() method.

    public void GetNavigation(NavigationBuilder builder) {
      builder.AddImageSet("webshop")
        .Add(T("Customers"), "7", menu => menu.Action(...})
          .Add(T("Details"), "0", item => item.Action(...}).LocalNav())
          .Add(T("History"), "1", item => item.Action(...).LocalNav())
          .Add(T("Contact"), "2", item => item.Action(...).LocalNav()));
    }

>Be careful, if the Current displayed url is not part of the LocalNav pages, no tabs are displayed. You first have to navigate to one of the pages for the LocalNav to display.
