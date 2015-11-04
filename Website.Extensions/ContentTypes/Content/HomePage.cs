namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using System.Web;
    using System.Collections.Generic;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class HomePage : WebPage,
                            IMainTitle, IBodyText
    {
        #region Properties

        public string HeaderText { get; set; }

        public IHtmlString BodyText { get; set; }

        public IEnumerable<int> FeaturedContent { get; set; }

        #endregion
    }
}
