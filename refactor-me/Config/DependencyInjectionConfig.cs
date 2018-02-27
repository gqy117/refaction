using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using refactor_me.Service;

namespace refactor_me.Config
{
    public class DependencyInjection
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductsService>();
            builder.RegisterType<ProductOptionsService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}