using System.Data.Entity;
using refactor_me.Models;

namespace refactor_me.Models
{
    public class RefactorContext : DbContext
    {
        public RefactorContext()
            : base("name=RefactorContext1")
        {
        }

        public virtual DbSet<refactor_me.Models.Product> Products { get; set; }
        //public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
