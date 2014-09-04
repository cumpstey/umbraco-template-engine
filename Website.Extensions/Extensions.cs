namespace Zone.UmbracoTemplateEngine.Website
{
    using System.Web;
    using Ninject;

    public static class Extensions
    {
        #region IKernel

        public static T GetService<T>(this IKernel kernel)
        {
            return (T)kernel.GetService(typeof(T));
        }

        #endregion

        #region HttpRequestBase

        public static bool IsBackOfficeMacroRendering(this HttpRequestBase request)
        {
            return request == null || request.Url == null ? false : request.Url.AbsolutePath == "/umbraco/backoffice/UmbracoApi/Macro/GetMacroResultAsHtmlForEditor";
        }

        #endregion
    }
}
