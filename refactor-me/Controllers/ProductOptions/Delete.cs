using System;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public partial class ProductOptionsController
    {
        [Route(Consts.ProductOptions.Id)]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            this.ProductOptionsService.DeleteOption(id);
        }
    }
}
