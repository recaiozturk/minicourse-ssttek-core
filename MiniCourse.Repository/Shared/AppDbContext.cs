using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Categories;
using MiniCourse.Repository.Courses;
using MiniCourse.Repository.OrderDetails;
using MiniCourse.Repository.Orders;
using MiniCourse.Repository.Payments;
using MiniCourse.Repository.Users;

namespace MiniCourse.Repository.Shared
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,Guid>(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDefaultUserAndRoles(builder);
        }

        void SeedDefaultUserAndRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            Guid ADMIN_ID = Guid.NewGuid();
            Guid ROLE_ID = Guid.NewGuid();
            Guid DEFAULT_ROLE_ID = Guid.NewGuid();

            builder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID.ToString()
            });

            builder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = DEFAULT_ROLE_ID,
                ConcurrencyStamp = DEFAULT_ROLE_ID.ToString()
            });

            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                SecurityStamp  = Guid.NewGuid().ToString()
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Password.123");

            builder.Entity<AppUser>().HasData(appUser);

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
    
}
