using System;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route(Consts.Products.Id)]
        [HttpPut]
        public void Update(Guid id, DTOs.Product product)
        {
            this.ProductsService.Update(id, product);
        }
    }
}
