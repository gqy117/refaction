using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using refactor_me.AutoMapper;
using refactor_me.Repository;
using refactor_me.Service;

namespace refactor_me.Config
{
    public class DependencyInjection
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            DIHelper.RegisterDBContext(builder);
            DIHelper.RegisterServices(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}