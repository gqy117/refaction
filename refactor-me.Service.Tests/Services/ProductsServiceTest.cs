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
    }
}
