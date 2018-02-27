using System;
using System.Collections.Generic;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route]
        [HttpGet]
        public IList<DTOs.Product> GetAll()
        {
            return this.ProductsService.GetAll();
        }

        [Route]
        [HttpGet]
        public IList<DTOs.Product> SearchByName(string name)
        {
            return this.ProductsService.SearchByName(name);
        }

        [Route(Consts.Products.Id)]
        [HttpGet]
        public DTOs.Product GetProduct(Guid id)
        {
            return this.ProductsService.GetProduct(id);
        }
    }
}
