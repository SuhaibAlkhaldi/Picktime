using Microsoft.EntityFrameworkCore;
using Picktime.Entities;

namespace Picktime.Context
{
    public class PickTimeDbContext : DbContext
    {
        public DbSet<LockUpType> LockUpType { get; set; }
        public DbSet<LockUpItems> LockUpItems { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ProviderService> ProviderServices { get; set; }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<UserReviewService> UserReviewServices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> categories { get; set; }
        public PickTimeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
            ConfigureBookingEntity(modelBuilder);
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

            modelBuilder.Entity<Category>().HasData(
               new Category {Icon = "fa-solid fa-building-columns",CategoryName = "Bank" ,Id = 1 , IsActive = true,CreatedBy = "Seed", CreationDate = DateTime.UtcNow});

            modelBuilder.Entity<Provider>().HasData(
                new Provider {CategoryId = 1 , CreatedBy = "Seed", CreationDate = DateTime.UtcNow , IsActive = true ,Id=1,Logo= "fa-solid fa-kaaba",Description= "Arab Bank",Name = "Arab Bank"});

            modelBuilder.Entity<ProviderService>().HasData(
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 1, Description = "Service Time 1m ", Name = "1M Service", ActualEstimatedTime = new TimeOnly(0, 1, 30), ExpectedEstimatedTime = new TimeOnly(0, 1, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 2, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 2, 0), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 3, Description = "Service Time 1m ", Name = "1m Service", ActualEstimatedTime = new TimeOnly(0, 1, 0), ExpectedEstimatedTime = new TimeOnly(0, 1, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 4, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 1, 30), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 5, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 1, 0), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 6, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 1, 0), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.Completed },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 7, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 1, 0), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.InProgress },
                new ProviderService { CreatedBy = "Seed", CreationDate = DateTime.UtcNow, IsActive = true, Id = 8, Description = "Service Time 2m ", Name = "2m Service", ActualEstimatedTime = new TimeOnly(0, 1, 0), ExpectedEstimatedTime = new TimeOnly(0, 2, 0), ProviderId = 1, Status = Heplers.Enums.EServicesActions.UnCompleted });

            //modelBuilder.Entity<User>().HasData(
            //    new User { CreatedBy = "System", CreationDate = DateTime.UtcNow, IsActive = true, Id = 1,Email="Seed@PicTime.com",FirstName="seed",IsAdmin=true,IsLoggedIn=false,PhoneNumber="07777777777" ,SelectedLanguage=0,Points=0,Birthdate= DateOnly.Parse("2002-04-11"), LastName="Root",Password="0000000000",Gender="Robo"});



        }

        private void ConfigureBookingEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(b => b.Status)
                      .HasConversion<int>(); // Store enum (status) as int
            });
        }
    }
}