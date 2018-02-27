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
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return this.ProductOptionsService.GetOptions(productId);
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            return this.ProductOptionsService.GetOption(id);
        }
    }
}
