using System.Web.Http;
using refactor_me.Models;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            this.ProductsService.Create(product);
        }
    }
}
