namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    using System;

    public interface IArticleDetails
    {
        string Author { get; }

        DateTime? PublicationDate { get; }
    }
}
