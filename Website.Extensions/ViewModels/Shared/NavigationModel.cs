namespace Zone.UmbracoTemplateEngine.Website.ViewModels.Shared
{
    using System.Collections.Generic;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class NavigationModel : INavigation
    {
        public IEnumerable<INavigationItem> Items { get; set; }
    }
}
