namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    using System.Collections.Generic;

    public interface INavigation
    {
        IEnumerable<INavigationItem> Items { get; }
    }
}
