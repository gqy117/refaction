using System;
using System.Collections.Generic;

namespace refactor_me.Service
{
    public class ProductOptionsService : ServiceBase
    {
        public ProductOptionsService(DependencyDTO dependencies) : base(dependencies)
        {
        }

        public IList<DTOs.ProductOption> GetOptions(Guid productId)
        {
            return this.Mapper.Map<List<DTOs.ProductOption>>(this.DBContext.Products.Find(productId).ProductOptions);
        }

        public DTOs.ProductOption GetOption(Guid id)
        {
            return this.Mapper.Map<DTOs.ProductOption>(this.DBContext.ProductOptions.Find(id));
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