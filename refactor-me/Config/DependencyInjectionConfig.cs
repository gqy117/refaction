using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using refactor_me.AutoMapper;
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

            builder.RegisterType<DomainToViewModelMappingProfile>();
            builder.RegisterType<ProductsService>();
            builder.RegisterType<ProductOptionsService>();

            RegisterAutoMapper(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterAutoMapper(ContainerBuilder builder)
        {
            //register your profiles, or skip this if you don't want them in your container
            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile));

            //register your configuration as a single instance
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                //add your profiles (either resolve from container or however else you acquire them)
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            //register your mapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}