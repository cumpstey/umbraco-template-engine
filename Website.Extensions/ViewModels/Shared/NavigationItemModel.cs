namespace Zone.UmbracoTemplateEngine.Website.ViewModels.Shared
{
    using System.Collections.Generic;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class NavigationItemModel : Node,
                                       INavigationItem
    {
        #region Properties

        public string HeaderText { get; set; }

        public bool IsCurrentPage { get; set; }

        public bool IsCurrentPageOrAncestor { get; set; }

        public IEnumerable<INavigationItem> Items { get; set; }

        #endregion
    }
}
