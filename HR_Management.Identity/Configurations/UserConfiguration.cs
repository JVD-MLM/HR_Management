using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "ec3363f3-991f-47bb-83ed-d41ba8c15e81",
                    Email = "test@test.com",
                    NormalizedEmail = "TEST@TEST.COM",
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "test@test.com",
                    NormalizedUserName = "TEST@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "testPasswordAdmin"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "ec3363f3-991f-47bb-78ed-d41ba8c15e81",
                    Email = "test@test.com",
                    NormalizedEmail = "TEST@TEST.COM",
                    FirstName = "user",
                    LastName = "user",
                    UserName = "test@test.com",
                    NormalizedUserName = "TEST@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "testPasswordUser"),
                    EmailConfirmed = true,
                }
            );
        }
    }
}
