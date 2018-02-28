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
            CreateMap<Models.Product, DTOs.Product>().ReverseMap();
        }

        private void MapProductOption()
        {
            CreateMap<Models.ProductOption, DTOs.ProductOption>().ReverseMap();
        }
    }
}