namespace Zone.UmbracoTemplateEngine.Website.Controllers.WebPages
{
    using System.Web.Mvc;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Controllers.Base;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public class HomePageController : BaseWebPageSurfaceController<HomePage>
    {
        #region Constructor

        public HomePageController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Action methods

        public ActionResult HomePage()
        {
            var model = GetModel();
            return CurrentTemplate(model);
        }

        #endregion
    }
}
