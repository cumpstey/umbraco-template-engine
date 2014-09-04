namespace Zone.UmbracoTemplateEngine.Website.Controllers.WebPages
{
    using System.Linq;
    using System.Web.Mvc;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Controllers.Base;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public class LandingPageController : BaseWebPageSurfaceController<List>
    {
        #region Constructor

        public LandingPageController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Action methods

        public ActionResult LandingPage()
        {
            var model = GetModel();
            return CurrentTemplate(model);
        }

        #endregion
    }
}
