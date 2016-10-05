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
            Property(u => u.LicensePackagePriceId).IsRequired();
            Property(u => u.LicensePaymentOrderId).IsRequired();
            Property(u => u.MaxUsers).IsRequired();
            Property(u => u.StartDate).IsRequired();
            Property(u => u.ExpirationDate).IsRequired();
            Property(u => u.CreatedDate).IsRequired();
            Property(u => u.ModifiedDate).IsRequired();

            HasRequired(u => u.License).WithMany(ur => ur.LicenseHistories).HasForeignKey(k => k.LicenseId);

            HasRequired(u => u.LicensePaymentOrder).WithMany().WillCascadeOnDelete(false);
        }
    }
}
