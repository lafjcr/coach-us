using CoachUs.Common.Enums;
using System;

namespace CoachUs.Data.Entities
{
    public class LicensePaymentOrder : BaseEntity
    {
        public int LicenseId { get; set; }
        public int LicensePackagePriceId { get; set; }
        public string PaymentOrderType { get; set; }
        public int Qty { get; set; }
        public int Users { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal UpgradeCredit { get; set; }
        public decimal TotalAmount { get { return (UnitAmount * Qty) - UpgradeCredit; } internal set { } }
        public Nullable<DateTime> PaidDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentReference { get; set; }
        public bool PaymentConfirmed { get; set; }

        public Nullable<PaymentOrderType> PaymentOrderTypeValue
        {
            get
            {
                if (PaymentOrderType != null)
                    return (PaymentOrderType)PaymentOrderType[0];
                return null;
            }
            set
            {
                PaymentOrderType = ((char)value).ToString();
            }
        }

        public Nullable<PaymentType> PaymentTypeValue
        {
            get
            {
                if (PaymentType != null)
                    return (PaymentType)PaymentType[0];
                return null;
            }
            set
            {
                PaymentType = ((char)value).ToString();
            }
        }


        public virtual License License { get; set; }
        public virtual LicensePackagePrice LicensePackagePrice { get; set; }
    }
}
