namespace Zone.UmbracoTemplateEngine.Website.Markup
{
    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using Umbraco.Web;

    public static class UiExtensions
    {
        #region Text

        public static string Text(this HtmlHelper helper, string key)
        {
            return new UmbracoHelper(UmbracoContext.Current).GetDictionaryValue(key);
        }

        #endregion

        #region Date and time

        public static IHtmlString Date(this HtmlHelper helper, DateTime date, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentUICulture;
            }

            var tag = new TagBuilder("time");
            tag.Attributes.Add("datetime", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            tag.InnerHtml = date.ToString("d", culture);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static IHtmlString DateTime(this HtmlHelper helper, DateTime dateTime, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentUICulture;
            }

            var tag = new TagBuilder("time");
            tag.Attributes.Add("datetime", dateTime.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));
            tag.InnerHtml = dateTime.ToString("g", culture);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        #endregion
    }
}
