using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using refactor_me.Models;

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

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return this.Mapper.Map<DTOs.Product>(product);
        }

        public void Create(DTOs.Product product)
        {
            this.DBContext.Products.Add(this.Mapper.Map<Product>(product));

            this.DBContext.SaveChanges();
        }

        public void Update(Guid id, DTOs.Product newProduct)
        {
            var product = this.DBContext.Products.Find(newProduct.Id);

            if (product != null)
            {
                this.Mapper.Map(newProduct, product);

                this.DBContext.Entry(product).State = EntityState.Modified;

                this.DBContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var product = this.DBContext.Products.Find(id);

            if (product != null)
            {
                this.DBContext.Products.Remove(product);

                this.DBContext.SaveChanges();
            }
        }
    }
}