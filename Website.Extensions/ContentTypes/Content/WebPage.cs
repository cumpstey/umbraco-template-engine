namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class WebPage : Node,
                           IMetaData
    {
        #region Fields

        private string _metaTitle;

        #endregion

        #region Properties

        public string MetaTitle
        {
            get { return string.IsNullOrEmpty(_metaTitle) ? Name : _metaTitle; }
            set { _metaTitle = value; }
        }

        public string MetaTitleSuffix { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string CanonicalUrl { get; set; }

        #endregion
    }
}
