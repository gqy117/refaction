using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class DependencyDTO
    {
        public readonly IMapper Mapper;
        public readonly RefactorContext RefactorContext;
        public readonly CRUDHelper CrudHelper;

        public DependencyDTO(IMapper mapper, RefactorContext refactorContext, CRUDHelper crudHelper)
        {
            this.Mapper = mapper;
            this.RefactorContext = refactorContext;
            this.CrudHelper = crudHelper;
        }
    }
}