namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class HomePage : WebPage,
                            IMainTitle
    {
        #region Properties

        public string HeaderText { get; set; }

        #endregion
    }
}
