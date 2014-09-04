namespace Zone.UmbracoTemplateEngine.Website.Controllers.WebPages
{
    using System.Linq;
    using System.Web.Mvc;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Controllers.Base;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public class WebsiteController : BaseSurfaceController
    {
        #region Constructor

        public WebsiteController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Template methods

        public ActionResult Website()
        {
            var homePage = GetWebsiteContent().Children.FirstOrDefault(i => i.DocumentTypeAlias == "HomePage");
            if (homePage != null)
            {
                return RedirectToUmbracoPage(homePage);
            }

            var model = new Website();
            Mapper.Map(CurrentPage, model);
            return CurrentTemplate(model);
        }

        #endregion
    }
}
