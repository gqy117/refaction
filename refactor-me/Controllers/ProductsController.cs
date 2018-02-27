using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.Products.ProductsRoute)]
    public class ProductsController : ApiController
    {
        public ProductsService ProductsService { get; set; } = new ProductsService();

        [Route]
        [HttpGet]
        public Products GetAll()
        {
            return this.ProductsService.GetAll();
        }

        [Route]
        [HttpGet]
        public Products SearchByName(string name)
        {
            return this.ProductsService.SearchByName(name);
        }

        [Route(Consts.Products.Id)]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            return this.ProductsService.GetProduct(id);
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            this.ProductsService.Create(product);
        }

        [Route(Consts.Products.Id)]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            this.ProductsService.Update(id, product);
        }

        [Route(Consts.Products.Id)]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this.ProductsService.Delete(id);
        }
    }
}
