﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace refactor_me.Service
{
    public abstract class ServiceBase
    {
        protected readonly DependencyDTO DependencyDTO;
        protected readonly IMapper Mapper;

        public ServiceBase(DependencyDTO dependencyDTO)
        {
            this.DependencyDTO = dependencyDTO;
            this.Mapper = this.DependencyDTO.Mapper;
        }
    }
}