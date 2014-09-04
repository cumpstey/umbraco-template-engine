namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using System;
    using System.Web;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Media;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class Article : WebPage,
                           IHeroImage, IMainTitle, IStandfirst, IBodyText,
                           IArticleDetails,
                           IChildListingItem
    {
        #region Fields

        private string _listingTitle;

        private string _listingText;

        #endregion

        #region Properties

        public ImageWithCrops MainImage { get; set; }

        public string HeaderText { get; set; }

        public string Standfirst { get; set; }

        public IHtmlString BodyText { get; set; }

        public string Author { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string ListingTitle
        {
            get { return _listingTitle ?? HeaderText; }
            set { _listingTitle = value; }
        }

        public string ListingText
        {
            get { return _listingText ?? Standfirst; }
            set { _listingText = value; }
        }

        #endregion
    }
}
