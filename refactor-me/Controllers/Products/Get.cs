using System;
using System.Web.Http;
using refactor_me.Models;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
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
    }
}
