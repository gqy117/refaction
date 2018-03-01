using System;
using System.Web.Http;
using refactor_me.DTOs;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route(Consts.Products.Id)]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            this.ProductsService.Update(id, product);
        }
    }
}
