﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using refactor_me.DTOs;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route]
        [HttpGet]
        public IList<Product> GetAll()
        {
            return this.ProductsService.GetAll();
        }

        [Route]
        [HttpGet]
        public IList<Product> SearchByName(string name)
        {
            return this.ProductsService.SearchByName(name);
        }

        [Route(Consts.Products.Id)]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            var product = this.ProductsService.GetProduct(id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }
    }
}
