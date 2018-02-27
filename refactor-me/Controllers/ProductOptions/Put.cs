using System;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route(Consts.ProductOptions.Id)]
        [HttpPut]
        public void UpdateOption(Guid id, DTOs.ProductOption option)
        {
            this.ProductOptionsService.UpdateOption(id, option);
        }
    }
}
