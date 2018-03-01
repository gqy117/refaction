using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using Effort.Provider;
using FluentAssertions;
using NUnit.Framework;
using refactor_me.Repository;

namespace refactor_me.Service.Tests
{
    [TestFixture]
    public class ProductsServiceTest : TestBase
    {
        private ProductsService ProductsService;

        [SetUp]
        public new void Init()
        {
            this.ProductsService = new ProductsService(this.DependencyDTO);
        }

        [Test]
        public void GetAll_ShouldReturn2Records()
        {
            // Arrange

            // Act
            var actual = this.ProductsService.GetAll();

            // Assert
            actual.Count.Should().Be(2);
        }

        [Test]
        public void SearchByName_ShouldReturn1Record_WhenItExists()
        {
            // Arrange

            // Act
            var actual = this.ProductsService.SearchByName("Samsung Galaxy S7");

            // Assert
            actual.Count.Should().Be(1);
        }

        [Test]
        public void SearchByName_ShouldReturnEmptyList_WhenItDoesNotExist()
        {
            // Arrange

            // Act
            var actual = this.ProductsService.SearchByName("xxxx");

            // Assert
            actual.Should().BeEmpty();
        }

        [Test]
        public void GetProduct_ShouldReturn1Record_WhenItExists()
        {
            // Arrange

            // Act
            var actual = this.ProductsService.GetProduct(new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"));

            // Assert
            actual.Should().NotBeNull();
        }

        [Test]
        public void GetProduct_ShouldReturnEmptyList_WhenItDoesNotExist()
        {
            // Arrange

            // Act
            var actual = this.ProductsService.GetProduct(Guid.Empty);

            // Assert
            actual.Should().BeNull();
        }

        [Test]
        public void Create_ShouldCreateAProduct()
        {
            // Arrange
            DTOs.Product product = new DTOs.Product
            {
                Id = new Guid("123e9176-35ee-4f0a-ae55-83023d2db1a3"),
                Name = "Samsung Galaxy S7",
                Description = "Newest mobile product from Samsung.",
                Price = 1024.99M,
                DeliveryPrice = 16.99M
            };

            // Act
            this.ProductsService.Create(product);

            // Assert
            this.DBContext.Products.Where(x => x.Id == new Guid("123e9176-35ee-4f0a-ae55-83023d2db1a3")).Should().NotBeEmpty();
        }
    }
}
