using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "ec3363f3-991f-47bb-83ed-d41ba8c15e81",
                    RoleId = "2cd256c9-95f1-4eeb-8d42-d95cb041dd65"
                },
                new IdentityUserRole<string>
                {
                    UserId = "ec3363f3-991f-47bb-78ed-d41ba8c15e81",
                    RoleId = "6fedbd79-49b2-45c9-9af7-ed61b7de5a08"
                }
            );
        }
    }
}
