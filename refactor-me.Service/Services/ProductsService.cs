using System;
using System.Collections.Generic;
using System.Linq;

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
            return this.Mapper.Map<List<DTOs.Product>>(this.DBContext.Products.Where(x => x.Name == name));
        }

        public DTOs.Product GetProduct(Guid id)
        {
            return this.Mapper.Map<DTOs.Product>(this.DBContext.Products.Find(id));
        }

        public void Create(DTOs.Product product)
        {
            this.CRUDHelper.Create(this.DBContext.Products, product);
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