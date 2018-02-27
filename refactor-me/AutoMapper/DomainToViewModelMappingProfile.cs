using AutoMapper;

namespace refactor_me.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Models.ProductOption, DTOs.ProductOption>();
            CreateMap<Models.Product, DTOs.Product>();
        }
    }
}