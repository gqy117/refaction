using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    public partial class ProductsController
    {
        [Route(Consts.Products.Id)]
        [HttpDelete]
        public void Delete(Guid id)
        {
            this.ProductsService.Delete(id);
        }
    }
}
