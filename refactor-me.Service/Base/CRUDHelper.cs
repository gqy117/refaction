using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Repository;

namespace refactor_me.Service
{
    public class CRUDHelper
    {
        public readonly RefactorContext DBContext;

        public CRUDHelper(RefactorContext refactorContext)
        {
            this.DBContext = refactorContext;
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
