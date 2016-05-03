using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class UserDetailConfiguration : EntityBaseConfiguration<UserDetail>
    {
        public UserDetailConfiguration()
        {
            HasKey(e => e.Id);
            Property(u => u.Id).IsRequired();
            Property(u => u.Name).IsRequired().HasMaxLength(100);
            Property(u => u.LastName).IsRequired().HasMaxLength(100);
            Property(u => u.BirthDate).IsRequired();
            Property(u => u.Gender).IsRequired();
            Property(u => u.Laterality).IsRequired();
            Property(u => u.Country).IsRequired().HasMaxLength(100);
            Property(u => u.Address).IsRequired().HasMaxLength(150);
            Property(u => u.PictureID).IsOptional();
        }
    }
}
