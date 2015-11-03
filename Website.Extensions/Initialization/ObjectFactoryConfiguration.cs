using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Umbraco.Web;
using Zone.UmbracoMapper;
using Zone.UmbracoTemplateEngine.Website.Services;

namespace Zone.UmbracoTemplateEngine.Website.Initialization
{
    public static class ObjectFactoryConfiguration
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            // Register Umbraco context, MVC controllers and API controllers
            builder.Register(c => UmbracoContext.Current).AsSelf();
            builder.RegisterControllers(typeof(ObjectFactoryConfiguration).Assembly);
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            // Register application-specific types 
            RegisterTypes(builder);

            // Build container and set as default resolver
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceCollection>();

            builder.RegisterType<UmbracoMapper.UmbracoMapper>()
                   .As<IUmbracoMapper>();
        }
    }
}