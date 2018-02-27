using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace refactor_me.Service
{
    public abstract class ServiceBase
    {
        protected readonly IMapper Mapper;

        protected ServiceBase(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}