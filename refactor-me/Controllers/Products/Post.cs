using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route]
        [HttpPost]
        public void Create(DTOs.Product product)
        {
            this.ProductsService.Create(product);
        }
    }
}
