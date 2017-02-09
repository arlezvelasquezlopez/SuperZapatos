using SuperZapatos.InventoryContro.Library.Entities;
using System.Data.Entity;

namespace SuperZapatos.InvetoryControl.Infrastructure.Context
{
    public class InventoryControlContext: DbContext
    {
        public InventoryControlContext() : base("name=InventoryControlDBConnectionString")
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
