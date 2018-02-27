using System.Collections.Generic;
using AutoMapper;

namespace refactor_me.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            MapProductOption();
            MapProduct();
        }

        private void MapProduct()
        {
            CreateMap<Models.Product, DTOs.Product>();
            CreateMap<IList<Models.Product>, IList<DTOs.Product>>();
        }

        private void MapProductOption()
        {
            CreateMap<Models.ProductOption, DTOs.ProductOption>();
            CreateMap<IList<Models.ProductOption>, IList<DTOs.ProductOption>>();
        }
    }
}