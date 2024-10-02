using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser {
                    Id= "f89eee96-b676-4dc4-be8c-afdc47c6d3af",
                    Email="admin@localhost.com",
                    NormalizedEmail="ADMIN@LOCALHOST.COM",
                    FirstName="Admin" ,
                    LastName="Localhost",
                    UserName= "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash=hasher.HashPassword(null,"123Asd//"),
                    EmailConfirmed=true 
                }
                , new ApplicationUser { 
                    Id = "d2c78267-27a2-40be-bdf0-e645ecd9d7aa",
                    Email = "user@localhost.com", 
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User", 
                    UserName = "user@localhost.com", 
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "123Asd//"), 
                    EmailConfirmed = true
                }
            );
        }
    }
}
