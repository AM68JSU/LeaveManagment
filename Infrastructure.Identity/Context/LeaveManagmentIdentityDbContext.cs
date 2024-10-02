using Infrastructure.Identity.Configurations;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Context
{
    public class LeaveManagmentIdentityDbContextFactory : IDesignTimeDbContextFactory<LeaveManagmentIdentityDbContext>
    {
        public LeaveManagmentIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeaveManagmentIdentityDbContext>();
            optionsBuilder.UseSqlServer("Password=123asd/;Persist Security Info=True;User ID=sa;Initial Catalog=LeaveManagmentIdentity_db;Data Source=.");

            return new LeaveManagmentIdentityDbContext(optionsBuilder.Options);
        }
    }
    public class LeaveManagmentIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeaveManagmentIdentityDbContext(DbContextOptions<LeaveManagmentIdentityDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
