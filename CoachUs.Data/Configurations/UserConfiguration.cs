using CoachUs.Common.Data;
using CoachUs.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace CoachUs.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(e => e.Id);
            Property(t => t.UserName)
                .HasMaxLength(256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute()));
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
            Property(t => t.Name)
                .HasMaxLength(256)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute()));
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
