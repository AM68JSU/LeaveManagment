using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1dd9f630-3737-4b15-9720-847dbc3b019c",
                    UserId = "f89eee96-b676-4dc4-be8c-afdc47c6d3af"

                },
               new IdentityUserRole<string>
               {
                RoleId = "7a2d99ea-8be9-4420-ac39-c2613816509e",
                UserId = "d2c78267-27a2-40be-bdf0-e645ecd9d7aa"
               }
            );
        }
    }
}
