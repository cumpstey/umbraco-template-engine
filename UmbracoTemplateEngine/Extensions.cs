namespace Zone.UmbracoTemplateEngine
{
    using System;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Mvc;

    public static class Extensions
    {
        #region Methods

        public static IPublishedContent GetCurrentData(this SurfaceController controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            if (controller.ControllerContext != null && controller.ControllerContext.RouteData.Values.ContainsKey(TemplateExtensions.CurrentDataToken))
            {
                var id = controller.ControllerContext.RouteData.Values[TemplateExtensions.CurrentDataToken];
                var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                return umbracoHelper.TypedContent(id);
            }

            return null;
        }

        #endregion
    }
}
