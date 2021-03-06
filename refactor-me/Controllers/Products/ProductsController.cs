﻿using System.Web.Http;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.Products.ProductsRoute)]
    public partial class ProductsController : ApiController
    {
        private readonly ProductsService ProductsService;

        public ProductsController(ProductsService productsService)
        {
            this.ProductsService = productsService;
        }
    }
}
