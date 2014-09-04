namespace Zone.UmbracoTemplateEngine.Website.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ContentTypes.Media;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;
    using UmbracoMapper;
    using Zone.UmbracoTemplateEngine.Website.ActionResults;
    using Zone.UmbracoTemplateEngine.Website.Mapping;
    using Zone.UmbracoTemplateEngine.Website.Services;
    using MediaFile = Zone.UmbracoTemplateEngine.Website.ContentTypes.Media.MediaFile;

    public abstract class BaseSurfaceController : SurfaceController, IRenderMvcController
    {
        #region Fields

        private IPublishedContent _currentData;

        private bool _currentDataDetected;

        #endregion

        #region Constructor

        protected BaseSurfaceController(ServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            Mapper = services.Mapper
                             .AddCustomMapping(typeof(MediaFile).FullName, MediaMapper.GetMediaFile)
                             .AddCustomMapping(typeof(Image).FullName, MediaMapper.GetImage)
                             .AddCustomMapping(typeof(ImageWithCrops).FullName, MediaMapper.GetImageWithCrops)
                             .AddCustomMapping(typeof(IEnumerable<int>).FullName, ChildrenMapper.GetChildren, "ChildListing");
        }

        #endregion

        #region Properties

        protected IUmbracoMapper Mapper { get; private set; }

        protected IPublishedContent CurrentData
        {
            get
            {
                if (!_currentDataDetected)
                {
                    _currentData = this.GetCurrentData();
                    _currentDataDetected = true;
                }

                return _currentData ?? CurrentPage;
            }
        }

        #endregion

        #region Action methods

        /// <summary>
        /// Returns an ActionResult based on the template name found in the route values and the given model.
        /// </summary>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <param name="model">Model</param>
        /// <returns>ViewResult</returns>
        /// <remarks>
        /// If the template found in the route values doesn't physically exist, then an empty ContentResult will be returned.
        /// </remarks>
        protected ActionResult CurrentTemplate<T>(T model)
        {
            return View(ControllerContext.RouteData.Values["action"].ToString(), model);
        }

        /// <summary>
        /// The default action to render the front-end view.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>ActionResult to render the current template</returns>
        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        #endregion

        #region Helpers

        protected IPublishedContent GetWebsiteContent()
        {
            return CurrentPage.GetPropertyValue<IPublishedContent>("mockWebsiteContent")
                               ?? CurrentPage.AncestorOrSelf(1);
        }

        #endregion

        #region Action result helpers

        protected override RedirectResult Redirect(string url)
        {
            return new SafeRedirectResult(url);
        }

        protected override RedirectResult RedirectPermanent(string url)
        {
            return new SafeRedirectResult(url, true);
        }

        #endregion
    }
}
