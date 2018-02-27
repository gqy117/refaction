using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.Products.ProductsRoute)]
    public partial class ProductsController : ApiController
    {
        public ProductsService ProductsService { get; set; } = new ProductsService();
    }
}
