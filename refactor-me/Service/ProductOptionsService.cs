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
        public ProductOptionsService(DependencyDTO dependencies) : base(dependencies)
        {
        }

        public IList<DTOs.ProductOption> GetOptions(Guid productId)
        {
            var productionOptions = new ProductOptions(productId);

            return this.Mapper.Map<List<DTOs.ProductOption>>(productionOptions.Items);
        }

        public DTOs.ProductOption GetOption(Guid id)
        {
            var option = new ProductOption(id);
            if (option.IsNew)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return this.Mapper.Map<DTOs.ProductOption>(option);
        }

        public void CreateOption(Guid productId, DTOs.ProductOption option)
        {
            var newOption = this.Mapper.Map<Models.ProductOption>(option);

            newOption.ProductId = productId;
            newOption.Save();
        }

        public void UpdateOption(Guid id, DTOs.ProductOption option)
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