﻿using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix(Consts.ProductOptions.ProductOptionsRoute)]
    public partial class ProductOptionsController : ApiController
    {
        public ProductOptionsService ProductOptionsService { get; set; } = new ProductOptionsService();
    }
}