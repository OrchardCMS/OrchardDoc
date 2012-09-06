> This topic is a place holder and does not exist yet.

Adding an Orchard admin module starts with a class implementing the INavigationProvider:
    
    public interface INavigationProvider : IDependency {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }

In here the MenuName property should always return the value "admin", signalling to Orchard that this is an admin menu instead of a normal menu.

    using Orchard.Localization;
    using Orchard.UI.Navigation;
 
    namespace Orchard.Webshop {
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
                    .LinkToFirstChild(true)
                
                    // "Customers"
                    .Add(subItem => subItem
                        .Caption(T("Customers"))
                        .Position("2.1")
                        .Action("Index", "CustomerAdmin", new { area = "Orchard.Webshop" })
                    )
 
                );
        }
    }
    }