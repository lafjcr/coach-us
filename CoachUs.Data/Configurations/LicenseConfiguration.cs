using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class LicenseConfiguration : EntityBaseConfiguration<License>
    {
        public LicenseConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.Active).IsRequired();
            Property(u => u.CreatedDate).IsRequired();

            HasRequired(u => u.Owner).WithMany(ur => ur.Licenses).HasForeignKey(k => k.OwnerId);
        }
    }
}
