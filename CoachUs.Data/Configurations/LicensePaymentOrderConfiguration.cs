using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class LicensePaymentOrderConfiguration : EntityBaseConfiguration<LicensePaymentOrder>
    {
        public LicensePaymentOrderConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.LicenseId).IsRequired();
            Property(u => u.LicensePackagePriceId).IsRequired();
            Property(u => u.Qty).IsRequired();
            Property(u => u.Users).IsRequired();
            Property(u => u.UnitAmount).IsRequired();
            Property(u => u.TotalAmount).IsRequired();
            Property(u => u.PaidDate).IsOptional();
            Property(u => u.PaymentType).IsOptional().HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(u => u.PaymentReference).IsOptional();
            Property(u => u.PaymentConfirmed).IsRequired();
            Property(u => u.CreatedDate).IsRequired();
            Property(u => u.ModifiedDate).IsRequired();

            HasRequired(u => u.License).WithMany(ur => ur.LicensePaymentOrders).HasForeignKey(k => k.LicenseId);

            Ignore(u => u.PaymentTypeValue);
        }
    }
}
