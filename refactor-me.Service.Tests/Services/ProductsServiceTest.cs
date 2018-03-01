using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using Effort.Provider;
using NUnit.Framework;
using refactor_me.Repository;

namespace refactor_me.Service.Tests
{
    [TestFixture]
    public class ProductsServiceTest : TestBase
    {
        [Test]
        public void TestCase1()
        {
            Product productSamsung = new Product
            {
                Id = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),
                Name = "Samsung Galaxy S7",
                Description = "Newest mobile product from Samsung.",
                Price = 1024.99M,
                DeliveryPrice = 16.99M
            };

            Product productApple = new Product
            {
                Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"),
                Name = "Apple iPhone 6S",
                Description = "Newest mobile product from Apple.",
                Price = 1299.99M,
                DeliveryPrice = 15.99M
            };

            ProductOption productOptionSamsung1 = new ProductOption
            {
                Id = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9"),
                ProductId = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),
                Name = "White",
                Description = "White Samsung Galaxy S7",
            };

            var data = new List<Product>
            {
                new Product { Id = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),Name = "Samsung Galaxy S7",Description = "Newest mobile product from Samsung.", Price = 1024.99M, DeliveryPrice = 16.99M},
                new Product { Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"),Name = "Apple iPhone 6S",Description = "Newest mobile product from Apple.", Price = 1299.99M, DeliveryPrice = 15.99M},
            }.AsQueryable();

            var products1 = this.DBContext.Products.ToList();
            this.DBContext.Products.Add(productSamsung);

            this.DBContext.ProductOptions.Add(productOptionSamsung1);
            this.DBContext.SaveChanges();

            var products2 = this.DBContext.Products.ToList();
            var productOptions = this.DBContext.ProductOptions.ToList();
        }
    }
}
