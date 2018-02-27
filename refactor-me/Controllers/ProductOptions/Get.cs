using System;
using System.Collections.Generic;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route]
        [HttpGet]
        public IList<DTOs.ProductOption> GetOptions(Guid productId)
        {
            return this.ProductOptionsService.GetOptions(productId);
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpGet]
        public DTOs.ProductOption GetOption(Guid productId, Guid id)
        {
            return this.ProductOptionsService.GetOption(id);
        }
    }
}
