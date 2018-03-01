using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class DependencyDTO
    {
        public IMapper Mapper;
        public RefactorContext RefactorContext;
        public CRUDHelper CrudHelper;

        public DependencyDTO(IMapper mapper, RefactorContext refactorContext, CRUDHelper crudHelper)
        {
            this.Mapper = mapper;
            this.RefactorContext = refactorContext;
            this.CrudHelper = crudHelper;
        }
    }
}