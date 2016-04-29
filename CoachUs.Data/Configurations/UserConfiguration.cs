using CoachUs.Common.Data;
using CoachUs.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoachUs.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(e => e.Id);
            Property(e => e.UserDetailId).IsOptional();
            HasMany(e => e.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
        }
    }

    public class IdentityRoleConfiguration : EntityBaseConfiguration<IdentityRole>
    {
        public IdentityRoleConfiguration()
        {
            ToTable("AspNetRoles");
            HasKey(e => e.Id);
            HasMany(e => e.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityBaseConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            ToTable("AspNetUserRoles");            
            HasKey(e => new { e.UserId, e.RoleId });
        }
    }

    public class IdentityUserLoginConfiguration : EntityBaseConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            ToTable("AspNetUserLogins");
            HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });
        }
    }

    public class IdentityUserClaimConfiguration : EntityBaseConfiguration<IdentityUserClaim>
    {
        public IdentityUserClaimConfiguration()
        {
            ToTable("AspNetUserClaims");
            HasKey(e => e.Id);
        }
    }
}
