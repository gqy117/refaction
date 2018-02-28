namespace refactor_me.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RefactorContext : DbContext
    {
        public RefactorContext()
            : base("name=RefactorContext")
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
