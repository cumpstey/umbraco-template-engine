namespace Zone.UmbracoTemplateEngine.Website.ContentTypes.Content
{
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Media;
    using Zone.UmbracoTemplateEngine.Website.ViewModels;

    public class VideoResource : WebPage,
                                 IHeroVideo, IMainTitle, IStandfirst,
                                 IChildListingItem
    {
        #region Fields

        private string _listingTitle;

        private string _listingText;

        #endregion

        #region Properties

        public ImageWithCrops MainImage { get; set; }

        public string HeaderText { get; set; }

        public string VideoUrl { get; set; }

        public string Standfirst { get; set; }
        
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
