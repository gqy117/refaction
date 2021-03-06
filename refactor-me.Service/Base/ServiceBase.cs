﻿using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public abstract class ServiceBase
    {
        protected readonly DependencyDTO DependencyDTO;
        protected readonly IMapper Mapper;
        protected readonly RefactorContext DBContext;
        protected readonly CRUDHelper CRUDHelper;

        public ServiceBase(DependencyDTO dependencyDTO)
        {
            this.DependencyDTO = dependencyDTO;
            this.Mapper = this.DependencyDTO.Mapper;
            this.DBContext = this.DependencyDTO.RefactorContext;
            this.CRUDHelper = this.DependencyDTO.CrudHelper;
        }
    }
}