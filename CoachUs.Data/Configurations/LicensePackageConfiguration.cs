using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class LicensePackageConfiguration : EntityBaseConfiguration<LicensePackage>
    {
        public LicensePackageConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.Name).IsRequired();
            Property(u => u.Users).IsRequired();
            Property(u => u.MinUsers).IsRequired();
            Property(u => u.MaxUsers).IsRequired();
            Property(u => u.Active).IsRequired();
            Property(u => u.CreatedDate).IsRequired();
        }
    }
}
