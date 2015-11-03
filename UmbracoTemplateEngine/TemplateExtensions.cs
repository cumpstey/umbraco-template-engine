namespace Zone.UmbracoTemplateEngine
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Umbraco.Web;

    public static class TemplateExtensions
    {
        #region Fields

        public static readonly string CurrentDataToken = Guid.NewGuid().ToString();

        #endregion

        #region Methods

        public static IHtmlString Template(this HtmlHelper htmlHelper, int id, string tag, string partialToRenderIfNoTemplate = null, string partialToRenderIfInvalidContent = null, object routeValues = null)
        {
            return Template(htmlHelper, id, new[] { tag }, partialToRenderIfNoTemplate, partialToRenderIfInvalidContent, routeValues);
        }

        public static IHtmlString Template(this HtmlHelper htmlHelper, int id, string[] tags, string partialToRenderIfNoTemplate = null, string partialToRenderIfInvalidContent = null, object routeValues = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }

            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var content = umbracoHelper.TypedContent(id);
            if (content == null)
            {
                return partialToRenderIfInvalidContent == null
                           ? null
                           : htmlHelper.Partial(partialToRenderIfInvalidContent);
            }

            var action = TemplateResolver.ResolveTemplate(content.DocumentTypeAlias, tags);
            if (action == null)
            {
                return partialToRenderIfNoTemplate == null
                           ? null
                           : htmlHelper.Partial(partialToRenderIfNoTemplate);
            }

            var mergedRouteValues = new RouteValueDictionary(routeValues) { { CurrentDataToken, id } };
            return htmlHelper.Action(action, content.DocumentTypeAlias, mergedRouteValues);
        }

        #endregion
    }
}
