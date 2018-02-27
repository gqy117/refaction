using AutoMapper;

namespace refactor_me.Service
{
    public class DependencyDTO
    {
        public readonly IMapper Mapper;

        public DependencyDTO(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}