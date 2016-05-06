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
            Property(u => u.Gender).IsRequired().HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(u => u.Laterality).IsRequired().HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(u => u.Country).IsRequired().HasMaxLength(100);
            Property(u => u.Address).IsRequired().HasMaxLength(150);
            Property(u => u.PictureID).IsOptional();

            Ignore(u => u.GenderValue);
            Ignore(u => u.LateralityValue);
        }
    }
}
