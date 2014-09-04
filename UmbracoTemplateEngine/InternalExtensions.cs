namespace Zone.UmbracoTemplateEngine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class InternalExtensions
    {
        #region Methods

        public static IEnumerable<T> GetCustomAttributes<T>(this MethodInfo info)
        {
            return info.GetCustomAttributes(typeof(T)).Cast<T>();
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this MethodInfo info, bool inherit)
        {
            return info.GetCustomAttributes(typeof(T), inherit).Cast<T>();
        }

        #endregion
    }
}
