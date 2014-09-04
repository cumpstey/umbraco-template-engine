namespace Zone.UmbracoTemplateEngine.Website.ViewModels
{
    using System.Collections.Generic;

    public interface IChildListing
    {
        IEnumerable<int> ChildListing { get; }
    }
}
