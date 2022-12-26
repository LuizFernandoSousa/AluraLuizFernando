using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser,IdentityRole<int>,int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<CustomIdentityUser> haster = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = haster.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));   

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN"}
                
                );

            builder.Entity<IdentityRole<int>>().HasData(

                new IdentityRole<int> { Id = 99997, Name = "regular", NormalizedName = "REGULAR" }

                );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999}
                );



        }

    }
}
