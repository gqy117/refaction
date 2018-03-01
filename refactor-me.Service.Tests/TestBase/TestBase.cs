using System;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using Effort;
using NUnit.Framework;
using refactor_me.Config;
using refactor_me.Repository;

namespace refactor_me.Service.Tests
{
    public abstract class TestBase
    {
        protected RefactorContext DBContext;
        protected DependencyDTO DependencyDTO;

        [SetUp]
        public void Init()
        {
            this.SetupDBContext();
            this.SetupDependencyDTO();
        }

        private void SetupDependencyDTO()
        {
            var builder = new ContainerBuilder();

            DIHelper.RegisterServices(builder);

            var container = builder.Build();

            var mapper = container.Resolve<IMapper>();
            var crudHelper = new CRUDHelper(this.DBContext, mapper);

            this.DependencyDTO = new DependencyDTO(mapper, this.DBContext, crudHelper);
        }

        private void SetupDBContext()
        {
            var connection = DbConnectionFactory.CreateTransient();
            this.DBContext = new RefactorContext(connection);

            this.DBContext.Products.AddRange(TestData.Products);
            this.DBContext.ProductOptions.AddRange(TestData.ProductOptions);
            this.DBContext.SaveChanges();
        }
    }
}
