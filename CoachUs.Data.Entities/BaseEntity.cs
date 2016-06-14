using CoachUs.Common.Data;
using System;

namespace CoachUs.Data.Entities
{
    public abstract class BaseEntity : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
