using FuhoCommerce.Persistence.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public class FuhoIdentityDbContext : IdentityDbContext<AppUser>
    {
        public FuhoIdentityDbContext(DbContextOptions<FuhoIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { 
                    Name = Constants.Roles.Consumer, 
                    NormalizedName = Constants.Roles.Consumer.ToUpper() 
                },
                new IdentityRole
                {
                    Name = Constants.Roles.Buyer,
                    NormalizedName = Constants.Roles.Buyer.ToUpper()
                },
                new IdentityRole
                {
                    Name = Constants.Roles.Supplier,
                    NormalizedName = Constants.Roles.Supplier.ToUpper()
                });
        }
    }
}
