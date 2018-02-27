using System;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route(Consts.Products.Id)]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this.ProductsService.Delete(id);
        }
    }
}
