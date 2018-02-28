using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public abstract class ServiceBase
    {
        protected readonly DependencyDTO DependencyDTO;
        protected readonly IMapper Mapper;
        protected readonly RefactorContext DBContext;

        public ServiceBase(DependencyDTO dependencyDTO)
        {
            this.DependencyDTO = dependencyDTO;
            this.Mapper = this.DependencyDTO.Mapper;
            this.DBContext = this.DependencyDTO.RefactorContext;
        }
    }
}