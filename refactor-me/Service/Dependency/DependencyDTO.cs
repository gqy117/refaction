using AutoMapper;
using refactor_me.Models;

namespace refactor_me.Service
{
    public class DependencyDTO
    {
        public readonly IMapper Mapper;
        public readonly RefactorContext RefactorContext;

        public DependencyDTO(IMapper mapper, RefactorContext refactorContext)
        {
            this.Mapper = mapper;
            this.RefactorContext = refactorContext;
        }
    }
}