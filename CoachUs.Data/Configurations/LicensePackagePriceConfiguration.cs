using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class LicensePackagePriceConfiguration : EntityBaseConfiguration<LicensePackagePrice>
    {
        public LicensePackagePriceConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.LicensePackageId).IsRequired();
            Property(u => u.Months).IsRequired();
            Property(u => u.Price).IsRequired();
            Property(u => u.Active).IsRequired();
            Property(u => u.CreatedDate).IsRequired();
            Property(u => u.ModifiedDate).IsRequired();

            HasRequired(u => u.LicensePackage).WithMany(ur => ur.LicensePackagePrices).HasForeignKey(k => k.LicensePackageId);
        }
    }
}
