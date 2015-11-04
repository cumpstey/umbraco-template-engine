namespace Zone.UmbracoTemplateEngine.Website.Controllers.WebPages
{
    using System.Web.Mvc;
    using Zone.UmbracoTemplateEngine.Website.ContentTypes.Content;
    using Zone.UmbracoTemplateEngine.Website.Controllers.Base;
    using Zone.UmbracoTemplateEngine.Website.Services;

    public class ArticleController : BaseWebPageSurfaceController<Article>
    {
        #region Constructor

        public ArticleController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Action methods

        public ActionResult Article()
        {
            var model = GetModel();
            return CurrentTemplate(model);
        }

        #endregion

        #region Partial template methods

        [ChildActionOnly]
        [TemplateDescriptor(Tags = new[] { "ChildListing" })]
        public PartialViewResult ChildListing(int? characterLimit)
        {
            var model = GetModel();
            return PartialView("ChildListing", model);
        }

        [ChildActionOnly]
        [TemplateDescriptor(Tags = new[] { "HomepageListing" })]
        public PartialViewResult HomepageListing()
        {
            var model = GetModel();
            return PartialView("HomepageListing", model);
        }

        [ChildActionOnly]
        [TemplateDescriptor(Tags = new[] { "ContentMacro" })]
        public PartialViewResult ContentMacro()
        {
            var model = GetModel();
            return PartialView(model);
        }

        #endregion
    }
}
