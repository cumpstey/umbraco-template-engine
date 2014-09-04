namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    public interface IMetaData
    {
        string MetaTitle { get; }

        string MetaTitleSuffix { get; }

        string MetaDescription { get; }

        string MetaKeywords { get; }

        string CanonicalUrl { get; }
    }
}
