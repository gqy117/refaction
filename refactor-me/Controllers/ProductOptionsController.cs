﻿using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.ProductOptions.ProductsRoute)]
    public class ProductOptionsController : ApiController
    {
        [Route]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return new ProductOptions(productId);
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var option = new ProductOption(id);
            if (option.IsNew)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return option;
        }

        [Route]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;
            option.Save();
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            var orig = new ProductOption(id)
            {
                Name = option.Name,
                Description = option.Description
            };

            if (!orig.IsNew)
                orig.Save();
        }

        [Route(Consts.ProductOptions.Id)]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            var opt = new ProductOption(id);
            opt.Delete();
        }
    }
}
