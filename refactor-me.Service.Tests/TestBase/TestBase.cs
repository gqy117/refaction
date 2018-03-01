using System;
using System.Linq;
using Effort;
using NUnit.Framework;
using refactor_me.Repository;

namespace refactor_me.Service.Tests
{
    public abstract class TestBase
    {
        protected RefactorContext DBContext;

        [SetUp]
        public void Init()
        {
            var connection = DbConnectionFactory.CreateTransient();
            this.DBContext = new RefactorContext(connection);
            

            var products1 = this.DBContext.Products.ToList();
            this.DBContext.Products.Add(TestData.);

            this.DBContext.ProductOptions.Add(productOptionSamsung1);
            this.DBContext.SaveChanges();
        }
    }
}
