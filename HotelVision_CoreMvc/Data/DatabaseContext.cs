using HotelVision_CoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelVision_CoreMvc.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {                
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(c =>
            {
                c.HasMany(t => t.Transactions)
                    .WithOne()
                    .HasForeignKey(fk => fk.CustomerId)
                    .IsRequired();
            });
        }
    }
}