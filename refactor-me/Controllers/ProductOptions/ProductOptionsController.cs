using System;
using System.Net;
using System.Web.Http;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.ProductOptions.ProductOptionsRoute)]
    public partial class ProductOptionsController : ApiController
    {
        private readonly ProductOptionsService ProductOptionsService;

        public ProductOptionsController(ProductOptionsService productOptionsService)
        {
            this.ProductOptionsService = productOptionsService;
        }
    }
}
