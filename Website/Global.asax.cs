using System;
using Zone.UmbracoTemplateEngine.Website.Initialization;

namespace Website
{
    public class Global : Umbraco.Web.UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);
            ObjectFactoryConfiguration.Initialize();
        }
    }
}
