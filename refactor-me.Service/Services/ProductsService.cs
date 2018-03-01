using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class ProductsService : ServiceBase
    {
        public ProductsService(DependencyDTO dependencies) : base(dependencies)
        {
        }

        public IList<DTOs.Product> GetAll()
        {
            return this.Mapper.Map<List<DTOs.Product>>(this.DBContext.Products); ;
        }

        public IList<DTOs.Product> SearchByName(string name)
        {
            var products = this.DBContext.Products.Where(x => x.Name == name).ToList();

            return this.Mapper.Map<List<DTOs.Product>>(products);
        }

        public DTOs.Product GetProduct(Guid id)
        {
            var product = this.DBContext.Products.Find(id);

            return this.Mapper.Map<DTOs.Product>(product);
        }

        public void Create(DTOs.Product product)
        {
            this.DBContext.Products.Add(this.Mapper.Map<Product>(product));

            this.DBContext.SaveChanges();
        }

        public void Update(Guid id, DTOs.Product newProduct)
        {
            this.CRUDHelper.UpdateById(this.DBContext.Products, id, newProduct);
        }

        public void Delete(Guid id)
        {
            this.CRUDHelper.DeleteById(this.DBContext.Products, id);
        }
    }
}