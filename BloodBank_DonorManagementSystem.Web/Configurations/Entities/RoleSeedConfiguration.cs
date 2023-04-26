using BloodBank_DonorManagementSystem.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank_DonorManagementSystem.Web.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "aa382f62-0a46-4de6-bef5-539fd28c82d0",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "aa745f62-0a46-4de6-bef5-539bb28c83d0",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
              );
            ;
        }
    }
}