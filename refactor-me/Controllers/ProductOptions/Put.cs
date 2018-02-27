using System;
using System.Web.Http;
using refactor_me.DTOs;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route(Consts.ProductOptions.Id)]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            this.ProductOptionsService.UpdateOption(id, option);
        }
    }
}
