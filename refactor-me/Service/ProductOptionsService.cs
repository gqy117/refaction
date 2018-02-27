using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using refactor_me.Models;

namespace refactor_me.Service
{
    public class ProductOptionsService : ServiceBase
    {
        public ProductOptionsService(IMapper mapper) : base(mapper)
        {
        }

        public ProductOptions GetOptions(Guid productId)
        {
            return new ProductOptions(productId);
        }

        public ProductOption GetOption(Guid id)
        {
            var option = new ProductOption(id);
            if (option.IsNew)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return option;
        }

        public void CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;
            option.Save();
        }

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

        public void DeleteOption(Guid id)
        {
            var opt = new ProductOption(id);
            opt.Delete();
        }
    }
}