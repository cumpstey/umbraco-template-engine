namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using System.Collections.Generic;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class ResourceList : WebPage,
                                IMainTitle, IChildListing
    {
        #region Properties

        public string HeaderText { get; set; }

        public IEnumerable<int> ChildListing { get; set; }

        #endregion
    }
}
