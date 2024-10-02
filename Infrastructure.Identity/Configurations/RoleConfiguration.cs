using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            { Id= "7a2d99ea-8be9-4420-ac39-c2613816509e",Name="Employee",NormalizedName="EMPLOYEE" },
            new IdentityRole
            { Id = "1dd9f630-3737-4b15-9720-847dbc3b019c", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );
                
           }
    }
}
