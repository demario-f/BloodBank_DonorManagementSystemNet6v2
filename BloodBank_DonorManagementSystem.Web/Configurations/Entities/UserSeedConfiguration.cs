using BloodBank_DonorManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank_DonorManagementSystem.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "aa382e62-0a64-4de6-bef5-539fc21c89d0",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    UserName = "admin@test.com",
                    FirstName = "Admin",
                    LastName = "Test",
                    PasswordHash = hasher.HashPassword(null, "Password#123"),
                    EmailConfirmed= true,
                });
        }
    }
}