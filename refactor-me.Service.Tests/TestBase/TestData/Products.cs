using System;
using System.Collections.Generic;
using refactor_me.Repository;

namespace refactor_me.Service.Tests
{
    public partial class TestData
    {
        public static IEnumerable<Product> Products = new List<Product>
        {
            ProductSamsung,
            ProductApple,
        };

        public static Product ProductSamsung => new Product
        {
            Id = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),
            Name = "Samsung Galaxy S7",
            Description = "Newest mobile product from Samsung.",
            Price = 1024.99M,
            DeliveryPrice = 16.99M
        };

        public static Product ProductApple => new Product
        {
            Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"),
            Name = "Apple iPhone 6S",
            Description = "Newest mobile product from Apple.",
            Price = 1299.99M,
            DeliveryPrice = 15.99M
        };
    }
}
