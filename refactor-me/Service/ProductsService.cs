using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using refactor_me.Models;

namespace refactor_me.Service
{
    public class ProductsService : ServiceBase
    {
        public ProductsService(DependencyDTO dependencies) : base(dependencies)
        {
        }

        public IList<DTOs.Product> GetAll()
        {
            var products = this.DBContext.Products.ToList();

            return this.Mapper.Map<List<DTOs.Product>>(products);
        }

        public IList<DTOs.Product> SearchByName(string name)
        {
            var products = new Products(name);

            return this.Mapper.Map<List<DTOs.Product>>(products.Items);
        }

        public DTOs.Product GetProduct(Guid id)
        {
            var product = this.DBContext.Products.SingleOrDefault(x => x.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return this.Mapper.Map<DTOs.Product>(product);
        }

        public void Create(DTOs.Product product)
        {
            var newProduct = new Models.Product();
            this.Mapper.Map<DTOs.Product, Models.Product>(product, newProduct);
            this.DBContext.Products.Add(newProduct);

            this.DBContext.SaveChanges();
        }

        public void Update(Guid id, DTOs.Product product)
        {
            var orig = new Product(id)
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DeliveryPrice = product.DeliveryPrice
            };

            if (!orig.IsNew)
                orig.Save();
        }

        public void Delete(Guid id)
        {
            var product = new Product(id);
            product.Delete();
        }
    }
}