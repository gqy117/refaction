using System;
using System.Web.Http;
using refactor_me.DTOs;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            this.ProductOptionsService.CreateOption(productId, option);
        }
    }
}
