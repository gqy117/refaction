using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.ProductOptions.ProductOptionsRoute)]
    public class ProductOptionsController : ApiController
    {
        public ProductOptionsService ProductOptionsService { get; set; } = new ProductOptionsService();
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

        [Route]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            this.ProductOptionsService.CreateOption(productId, option);
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            this.ProductOptionsService.UpdateOption(id, option);
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            this.ProductOptionsService.DeleteOption(id);
        }
    }
}
