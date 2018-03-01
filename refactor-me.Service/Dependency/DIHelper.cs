using System.Collections.Generic;
using Autofac;
using AutoMapper;
using refactor_me.AutoMapper;
using refactor_me.Repository;
using refactor_me.Service;

namespace refactor_me.Config
{
    public class DIHelper
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceBase).Assembly)
                .Where(t => t.Name.EndsWith("Service"));

            RegisterDTOs(builder);
            RegisterHelpers(builder);
            RegisterAutoMapper(builder);
        }

        public static void RegisterDBContext(ContainerBuilder builder)
        {
            builder.RegisterType<RefactorContext>().InstancePerRequest();
        }

        private static void RegisterDTOs(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DependencyDTO).Assembly)
                .Where(t => t.Name.EndsWith("DTO"));
        }

        private static void RegisterHelpers(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceBase).Assembly)
                .Where(t => t.Name.EndsWith("Helper"));
        }

        private static void RegisterAutoMapper(ContainerBuilder builder)
        {
            //register your profiles, or skip this if you don't want them in your container
            builder.RegisterAssemblyTypes(typeof(DomainToViewModelMappingProfile).Assembly)
                .Where(t => t.Name.EndsWith("Profile"))
                .As<Profile>();

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