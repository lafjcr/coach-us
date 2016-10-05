using CoachUs.Common.Data;
using System;
using System.Collections.Generic;

namespace CoachUs.Data.Entities
{
    public class License : IEntityBase
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public bool Active{ get; set; }
        public DateTime CreatedDate{ get; set; }

        public virtual UserDetail Owner { get; set; }
        public virtual ICollection<LicensePaymentOrder> LicensePaymentOrders { get; set; }
        public virtual ICollection<LicenseHistory> LicenseHistories { get; set; }
    }
}
