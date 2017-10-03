namespace Zone.UmbracoTemplateEngine.Website.Mapping
{
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    public static class GeneralMapper
    {
        #region Custom mappings

        public static object GetEnumerableOfInt(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyName, bool recursive)
        {
            var property = contentToMapFrom.GetProperty(propertyName);
            if (property == null)
            {
                return null;
            }

            var value = property.DataValue;
            return value == null ? new int[0] : value.ToString().ToIntArray();
        }

        #endregion
    }
}
