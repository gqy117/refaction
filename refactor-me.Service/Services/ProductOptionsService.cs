using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class ProductOptionsService : ServiceBase
    {
        public ProductOptionsService(DependencyDTO dependencies) : base(dependencies)
        {
        }

        public IList<DTOs.ProductOption> GetOptions(Guid productId)
        {
            var product = this.DBContext.Products.Find(productId);
            var options = product.ProductOptions.ToList();

            return this.Mapper.Map<List<DTOs.ProductOption>>(options);
        }

        public DTOs.ProductOption GetOption(Guid id)
        {
            var option = this.DBContext.ProductOptions.Find(id);

            return this.Mapper.Map<DTOs.ProductOption>(option);
        }

        public void CreateOption(Guid productId, DTOs.ProductOption option)
        {
            option.ProductId = productId;

            this.CRUDHelper.Create(this.DBContext.ProductOptions, option);
        }

        public void UpdateOption(Guid id, DTOs.ProductOption newOption)
        {
            this.CRUDHelper.UpdateById(this.DBContext.ProductOptions, id, newOption);
        }

        public void DeleteOption(Guid id)
        {
            this.CRUDHelper.DeleteById(this.DBContext.ProductOptions, id);
        }
    }
}