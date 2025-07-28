using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "6fedbd79-49b2-45c9-9af7-ed61b7de5a08",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
            new IdentityRole
            {
                Id = "2cd256c9-95f1-4eeb-8d42-d95cb041dd65",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            );
        }
    }
}
