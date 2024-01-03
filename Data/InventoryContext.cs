using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<Detail> Details { get; set; }
        public DbSet<InventoryMedia> InventoryMedias { get; set; }
        public DbSet<InventoryDetail> InventoryDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>().HasData(
                new Detail { DetailId = 1, Name = "Dimension", CreatedAt = DateTime.Now },
                new Detail { DetailId = 2, Name = "Weight", CreatedAt = DateTime.Now },
                new Detail { DetailId = 3, Name = "Sell Price", CreatedAt = DateTime.Now },
                new Detail { DetailId = 4, Name = "Warehouse", CreatedAt = DateTime.Now });
            modelBuilder.Entity<Detail>().ToTable("Detail");
            modelBuilder.Entity<InventoryMedia>().ToTable("InventoryMedia");
            modelBuilder.Entity<InventoryDetail>().ToTable("InventoryDetail");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
        }
    }
}
