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
        public ProductsService(IMapper mapper) : base(mapper)
        {
        }

        public Products GetAll()
        {
            return new Products();
        }

        public Products SearchByName(string name)
        {
            return new Products(name);
        }

        public Product GetProduct(Guid id)
        {
            var product = new Product(id);
            if (product.IsNew)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }

        public void Create(Product product)
        {
            product.Save();
        }

        public void Update(Guid id, Product product)
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