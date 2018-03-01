using System;
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
            CreateMap<Repository.Product, DTOs.Product>().ReverseMap();
        }

        private void MapProductOption()
        {
            CreateMap<Repository.ProductOption, DTOs.ProductOption>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => !(srcMember is Guid && (Guid)srcMember == Guid.Empty)));
        }
    }
}