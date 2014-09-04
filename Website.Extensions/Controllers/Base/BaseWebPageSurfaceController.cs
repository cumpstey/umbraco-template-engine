namespace Zone.UmbracoTemplateEngine.Website.Controllers.Base
{
    using Umbraco.Core.Models;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public abstract class BaseWebPageSurfaceController : BaseSurfaceController
    {
        #region Constructor

        protected BaseWebPageSurfaceController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Helpers

        protected virtual T GetModel<T>()
            where T : WebPage, new()
        {
            var model = new T
            {
                CanonicalUrl = Request.Url == null || Request.Url.AbsolutePath == CurrentData.Url ? null : CurrentData.Url,
            };
            Mapper.Map(CurrentData, model);
            return model;
        }

        #endregion
    }
}
