using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

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
