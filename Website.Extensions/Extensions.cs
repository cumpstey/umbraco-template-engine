namespace Zone.UmbracoTemplateEngine.Website
{
    using System.Linq;

    public static class Extensions
    {
        #region String

        public static int[] ToIntArray(this string source)
        {
            return (source ?? string.Empty).Split(',')
                                           .Select(i =>
                                           {
                                               int temp;
                                               return int.TryParse(i, out temp) ? new int?(temp) : null;
                                           })
                                           .Where(i => i.HasValue)
                                           .Select(i => i.Value)
                                           .ToArray();
        }

        #endregion
    }
}
