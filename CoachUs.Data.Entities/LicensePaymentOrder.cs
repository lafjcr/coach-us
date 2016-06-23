using CoachUs.Common.Enums;
using System;

namespace CoachUs.Data.Entities
{
    public class LicensePaymentOrder : BaseEntity
    {
        public int LicenseId { get; set; }
        public int LicensePackagePriceId { get; set; }
        public int Qty { get; set; }
        public int Users { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentReference { get; set; }
        public bool PaymentConfirmed { get; set; }

        public PaymentType PaymentTypeValue
        {
            get
            {
                return (PaymentType)PaymentType[0];
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
