using System;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route]
        [HttpPost]
        public void CreateOption(Guid productId, DTOs.ProductOption option)
        {
            this.ProductOptionsService.CreateOption(productId, option);
        }
    }
}
