namespace Zone.UmbracoTemplateEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    public static class TemplateResolver
    {
        #region Fields

        private static IEnumerable<TemplateActionInfo> _templates;

        #endregion

        #region Constructor

        static TemplateResolver()
        {
            BuildReference();
        }

        #endregion

        #region Methods

        public static string ResolveTemplate(string contentType, string[] tags)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException("contentType");
            }

            var contentMatches = _templates.Where(i => i.Controller.ToLower() == contentType.ToLower());
            var tagMatches = contentMatches.Select(i => new
                                                            {
                                                                i.Action,
                                                                MatchingTags = i.Tags.Intersect(tags).ToArray(),
                                                            })
                                           .Where(i => i.MatchingTags.Any())
                                           .OrderByDescending(i => i.MatchingTags.Count());
            return tagMatches.Select(i => i.Action).FirstOrDefault();
        }

        #endregion

        #region Helpers

        private static void BuildReference()
        {
            var templates = new List<TemplateActionInfo>();
            foreach (var controllerType in AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.GetTypes()).Where(i => typeof(IController).IsAssignableFrom(i)))
            {
                foreach (var method in controllerType.GetMethods())
                {
                    var descriptor = method.GetCustomAttributes<TemplateDescriptorAttribute>().FirstOrDefault();
                    if (descriptor == null)
                    {
                        continue;
                    }

                    templates.Add(new TemplateActionInfo
                                      {
                                          Controller = Regex.Replace(controllerType.Name, "Controller$", string.Empty),
                                          Action = method.Name,
                                          Tags = descriptor.Tags,
                                      });
                }
            }

            _templates = templates;
        }

        #endregion

        #region Classes

        private class TemplateActionInfo
        {
            public string Controller { get; set; }

            public string Action { get; set; }

            public string[] Tags { get; set; }
        }

        #endregion
    }
}
