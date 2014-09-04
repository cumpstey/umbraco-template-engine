namespace Zone.UmbracoTemplateEngine.Website.Controllers.Base
{
    using Umbraco.Core.Models;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public abstract class BaseWebPageSurfaceController<T> : BaseWebPageSurfaceController
            where T : WebPage, new()
    {
        #region Constructor

        protected BaseWebPageSurfaceController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Helpers

        protected virtual T GetModel()
        {
            return GetModel<T>();
        }

        #endregion
    }
}
