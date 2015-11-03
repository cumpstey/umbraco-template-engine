namespace Zone.UmbracoTemplateEngine.Website.Controllers.Shared
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoTemplateEngine.Website.Controllers.Base;
    using Zone.UmbracoTemplateEngine.Website.Services;
    using Zone.UmbracoTemplateEngine.Website.ViewModels.Shared;

    public class NavigationController : BaseSurfaceController
    {
        #region Constructor

        public NavigationController(ServiceCollection services)
            : base(services)
        {
        }

        #endregion

        #region Action methods

        [ChildActionOnly]
        public PartialViewResult MainNavigation(int levels)
        {
            var website = GetWebsiteContent();

            var model = new NavigationModel
                            {
                                Items = GetMenuItems(website, 0, levels - 1),
                            };

            return PartialView(model);
        }

        #endregion

        #region Helpers

        private IEnumerable<NavigationItemModel> GetMenuItems(IPublishedContent parent, int currentLevel, int maxLevel)
        {
            var menu = parent.Children
                             .Where(i => !i.GetPropertyValue<bool>("umbracoNaviHide") && i.TemplateId != 0 && Umbraco.MemberHasAccess(i.Path))
                             .Select(i =>
                                         {
                                             var item = new NavigationItemModel
                                                            {
                                                                IsCurrentPage = CurrentPage.Id.Equals(i.Id),
                                                                IsCurrentPageOrAncestor = CurrentPage.Path.Contains(i.Id.ToString()),
                                                            };
                                             Mapper.Map(i, item);
                                             if (currentLevel < maxLevel)
                                             {
                                                 item.Items = GetMenuItems(i, currentLevel + 1, maxLevel);
                                             }

                                             return item;
                                         });
            return menu;
        }

        #endregion
    }
}
