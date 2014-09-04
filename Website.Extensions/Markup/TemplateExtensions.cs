namespace Zone.UmbracoTemplateEngine.Website.Markup
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Umbraco.Web;
    using Zone.UmbracoTemplateEngine.Website.Templates;

    public static class TemplateExtensions
    {
        #region Properties

        public static string CurrentDataToken = Guid.NewGuid().ToString();

        #endregion

        #region Methods

        public static IHtmlString Template(this HtmlHelper htmlHelper, int id, string tag, string partialToRenderIfNoTemplate = null)
        {
            return Template(htmlHelper, id, new[] { tag }, partialToRenderIfNoTemplate);
        }

        public static IHtmlString Template(this HtmlHelper htmlHelper, int id, string[] tags, string partialToRenderIfNoTemplate = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }

            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var content = umbracoHelper.TypedContent(id);

            var action = TemplateResolver.ResolveTemplate(content.DocumentTypeAlias, tags);
            if (action == null)
            {
                return partialToRenderIfNoTemplate == null
                    ? null
                    : htmlHelper.Partial(partialToRenderIfNoTemplate);
            }
            else
            {
                var routeValues = new RouteValueDictionary { { CurrentDataToken, id } };
                return htmlHelper.Action(action, content.DocumentTypeAlias, routeValues);
            }
        }

        #endregion
    }
}
