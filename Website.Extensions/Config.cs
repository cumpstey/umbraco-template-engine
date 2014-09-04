namespace Zone.UmbracoTemplateEngine.Website
{
    using System;
    using System.Configuration;
    using System.Web.Configuration;

    public static class Config
    {
        #region Constructor

        static Config()
        {
            var compilationSection = (CompilationSection)ConfigurationManager.GetSection(@"system.web/compilation");

            Debug = compilationSection.Debug;
        }

        #endregion

        #region Properties

        public static bool Debug { get; private set; }

        #endregion
    }
}
