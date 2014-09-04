namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Media;

    public interface IChildListingItem
    {
        int Id { get; }

        string Url { get; }

        ImageWithCrops MainImage { get; }

        string ListingTitle { get; }

        string ListingText { get; }
    }
}
