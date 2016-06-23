using CoachUs.Data.Configurations;
using CoachUs.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoachUs.Data
{
    public class CoachUsContext : DbContext
    {
        public CoachUsContext()
            : base("CoachUs")
        {
            Database.SetInitializer<CoachUsContext>(null);
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<IdentityUserRole> UserRoles { get; set; }
        public IDbSet<License> Licenses { get; set; }
        public IDbSet<LicensePackage> LicensePackages { get; set; }
        public IDbSet<LicensePackagePrice> LicensePackagePrices { get; set; }
        public IDbSet<LicensePaymentOrder> LicensePaymentOrders { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Identity
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserClaimConfiguration());
            modelBuilder.Configurations.Add(new IdentityRoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Configurations.Add(new UserDetailConfiguration());
            modelBuilder.Configurations.Add(new LicensePackageConfiguration());
            modelBuilder.Configurations.Add(new LicensePackagePriceConfiguration());
            modelBuilder.Configurations.Add(new LicenseConfiguration());
            modelBuilder.Configurations.Add(new LicensePaymentOrderConfiguration());
        }
    }
}
