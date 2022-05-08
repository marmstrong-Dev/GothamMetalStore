using System;
using Microsoft.EntityFrameworkCore;

namespace Gotham.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classification>()
                .HasMany(c => c.classifiedMetals)
                .WithOne(m => m.metalClassification)
                .HasForeignKey(m => m.classificationId);
            
            modelBuilder.Entity<Order>().HasOne(o => o.orderVendor);
            modelBuilder.Entity<Order>().HasOne(o => o.orderedMetal);
        }

        public DbSet<Metal> Metals { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
