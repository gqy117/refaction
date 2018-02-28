using System;
using System.Collections.Generic;
using System.Net;
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
            var option = this.ProductOptionsService.GetOption(id);

            if (option == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return option;
        }
    }
}
