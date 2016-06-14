using System;

namespace CoachUs.Data.Entities
{
    public class LicensePackagePrice : BaseEntity
    {
        public int LicensePackageId { get; set; }
        public int Months { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public virtual LicensePackage LicensePackage { get; set; }
    }
}
