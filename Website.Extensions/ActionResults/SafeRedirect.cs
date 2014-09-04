namespace Zone.UmbracoTemplateEngine.Website.ActionResults
{
    using System.Web.Mvc;

    public class SafeRedirectResult : RedirectResult
    {
        #region Constructor

        public SafeRedirectResult(string url)
            : base(GetSafeRedirectUrl(url))
        {
        }

        public SafeRedirectResult(string url, bool permanent)
            : base(GetSafeRedirectUrl(url), permanent)
        {
        }

        #endregion

        #region Helpers

        protected static string GetSafeRedirectUrl(string url)
        {
            if (url == null || url.Contains("//") || url.Contains("%2f%2f"))
            {
                return "/";
            }

            return url;
        }

        #endregion
    }
}
