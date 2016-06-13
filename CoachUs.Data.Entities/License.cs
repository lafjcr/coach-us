using CoachUs.Common.Data;
using System;

namespace CoachUs.Data.Entities
{
    public class License : IEntityBase
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public bool Active{ get; set; }
        public DateTime CreatedDate{ get; set; }

        public virtual UserDetail Owner { get; set; }
    }
}
