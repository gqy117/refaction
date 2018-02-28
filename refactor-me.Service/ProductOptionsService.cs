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
            this.DBContext.ProductOptions.Add(this.Mapper.Map<ProductOption>(option));

            this.DBContext.SaveChanges();
        }

        public void UpdateOption(Guid id, DTOs.ProductOption newOption)
        {
            var option = this.DBContext.ProductOptions.Find(id);

            if (option != null)
            {
                this.Mapper.Map(newOption, option);
                this.DBContext.Entry(option).State = EntityState.Modified;
                this.DBContext.SaveChanges();
            }
        }

        public void DeleteOption(Guid id)
        {
            var option = this.DBContext.ProductOptions.Find(id);

            if (option != null)
            {
                this.DBContext.ProductOptions.Remove(option);

                this.DBContext.SaveChanges();
            }
        }
    }
}