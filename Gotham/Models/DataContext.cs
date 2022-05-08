using System;
using Microsoft.EntityFrameworkCore;

namespace Gotham.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Metal> Metals { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
