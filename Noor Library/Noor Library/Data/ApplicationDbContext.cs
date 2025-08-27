using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Noor_Library.Models;

namespace Noor_Library.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "Security");
        }
        public DbSet<Book>books { get; set; }
        public DbSet<Author>Authors { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Slider> Sliders { get; set; }

    }
}