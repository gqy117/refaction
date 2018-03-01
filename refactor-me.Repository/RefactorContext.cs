using System.Data.Common;

namespace refactor_me.Repository
{
    using System.Data.Entity;

    public partial class RefactorContext : DbContext
    {
        public RefactorContext()
            : base("name=RefactorContext")
        {
        }

        public RefactorContext(DbConnection connection) : base(connection, true)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOptions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
