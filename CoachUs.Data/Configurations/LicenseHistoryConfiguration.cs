using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class LicenseHistoryConfiguration : EntityBaseConfiguration<LicenseHistory>
    {
        public LicenseHistoryConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.LicenseId).IsRequired();
            Property(u => u.LicensePackageId).IsRequired();
            Property(u => u.MaxUsers).IsRequired();
            Property(u => u.StartDate).IsRequired();
            Property(u => u.ExpirationDate).IsRequired();
            Property(u => u.CreatedDate).IsRequired();

            Ignore(u => u.ModifiedDate);
        }
    }
}
