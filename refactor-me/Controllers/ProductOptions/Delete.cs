using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

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
