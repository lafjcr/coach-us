using System;
using System.Collections.Generic;

namespace CoachUs.Data.Entities
{
    public class LicensePackage : BaseEntity
    {
        public string Name { get; set; }
        public int Users { get; set; }
        public int MinUsers { get; set; }
        public int MaxUsers { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<LicensePackagePrice> LicensePackagePrices { get; set; }
    }
}
