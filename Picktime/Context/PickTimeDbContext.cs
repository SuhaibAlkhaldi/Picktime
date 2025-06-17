using Microsoft.EntityFrameworkCore;
using Picktime.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Picktime.Context
{
    public class PickTimeDbContext : DbContext
    {
        public DbSet<LockUpType> LockUpType { get; set; }
        public DbSet<LockUpItems> LockUpItems { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<ServicesEntity> Services { get; set; }

        public DbSet<Providers> ServiceProviders { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> categories { get; set; }
        public PickTimeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //LookupType
            modelBuilder.Entity<LockUpType>().HasData(
                new LockUpType { Id = 1, Name = "Coupon" }
                );
            //LookupItem
            modelBuilder.Entity<LockUpItems>().HasData(
                new LockUpItems { Id = 1, Points = 100, Discount = 0.1f , LockUpTypeId = 1 },
                new LockUpItems { Id = 2, Points = 200, Discount = 0.2f, LockUpTypeId = 1 },
                new LockUpItems { Id = 3, Points = 300, Discount = 0.3f, LockUpTypeId = 1 }
                
                );
        }
    }
}