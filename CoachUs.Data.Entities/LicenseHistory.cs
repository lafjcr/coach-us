using System;

namespace CoachUs.Data.Entities
{
    public class LicenseHistory : BaseEntity
    {
        public int LicenseId { get; set; }
        public int LicensePackageId { get; set; }
        public int MaxUsers { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime ExpirationDate{ get; set; }

        public virtual License License { get; set; }
        public virtual LicensePackage LicensePackage { get; set; }
    }
}
