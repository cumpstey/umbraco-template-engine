namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    using System.Collections.Generic;

    public interface INavigationItem
    {
        int Id { get; }

        string Url { get; }

        string HeaderText { get; }

        bool IsCurrentPage { get; }

        bool IsCurrentPageOrAncestor { get; }

        IEnumerable<INavigationItem> Items { get; }
    }
}
