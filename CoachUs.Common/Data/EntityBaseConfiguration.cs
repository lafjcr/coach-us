using System.Data.Entity.ModelConfiguration;

namespace CoachUs.Common.Data
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class//, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            //HasKey(e => e.Id);
        }
    }
}
