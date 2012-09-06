> This topic is a place holder and does not exist yet.

Adding an Orchard admin module starts with a class implementing the INavigationProvider:
    
    public interface INavigationProvider : IDependency {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }

In here the MenuName property should always return the value "admin", signalling to Orchard that this is an admin menu instead of a normal menu.

#Adding a single item

    using Orchard.UI.Navigation;
 
    namespace Orchard.Webshop 
    {
    public class AdminMenu : INavigationProvider
    {
        public string MenuName {
            get { return "admin"; }
        }
 
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

This will result in a single item being added to the admin menu.

#Adding submenu items
By adding more .Add statements nested in the parent menu, we can generate a second menu level

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

#Adding multiple tabs to a page

For this we can use the .LocalNav()
Be careful, if the Current displayed url is not part of the LocalNav pages, no tabs are displayed