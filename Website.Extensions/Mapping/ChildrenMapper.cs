namespace Zone.UmbracoTemplateEngine.Website.Mapping
{
    using System.Linq;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    public static class ChildrenMapper
    {
        #region Custom mappings

        public static object GetChildren(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyName, bool recursive)
        {
            return contentToMapFrom.Children.Select(i => i.Id);
        }

        #endregion
    }
}
