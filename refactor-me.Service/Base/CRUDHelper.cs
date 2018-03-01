using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class CRUDHelper
    {
        private readonly RefactorContext DBContext;
        private readonly IMapper Mapper;

        public CRUDHelper(RefactorContext refactorContext, IMapper mapper)
        {
            this.DBContext = refactorContext;
            this.Mapper = mapper;
        }

        public void Create<TEntity, TDTO>(DbSet<TEntity> entities, TDTO dto) where TEntity : class
        {
            entities.Add(Mapper.Map<TEntity>(dto));

            DBContext.SaveChanges();
        }

        public void UpdateById<TEntity, TDTO>(DbSet<TEntity> entities, Guid id, TDTO newEntity) where TEntity : class
        {
            var oldEntity = entities.Find(id);

            if (oldEntity != null)
            {
                this.Mapper.Map(newEntity, oldEntity);
                this.DBContext.Entry(oldEntity).State = EntityState.Modified;
                this.DBContext.SaveChanges();
            }
        }

        public void DeleteById<T>(DbSet<T> entities, Guid id) where T : class
        {
            var entity = entities.Find(id);

            if (entity != null)
            {
                entities.Remove(entity);

                this.DBContext.SaveChanges();
            }
        }
    }
}
