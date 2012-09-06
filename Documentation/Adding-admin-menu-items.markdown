> This topic is a place holder and does not exist yet.

Adding an Orchard admin module starts with a class implementing INavigationProvider:
    
    public interface INavigationProvider : IDependency {
        string MenuName { get; }
        void GetNavigation(NavigationBuilder builder);
    }