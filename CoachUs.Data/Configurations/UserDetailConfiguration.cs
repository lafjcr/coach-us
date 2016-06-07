using CoachUs.Common.Data;
using CoachUs.Data.Entities;

namespace CoachUs.Data.Configurations
{
    public class UserDetailConfiguration : EntityBaseConfiguration<UserDetail>
    {
        public UserDetailConfiguration()
        {
            HasKey(e => e.UserId);
            Property(u => u.Name).IsRequired().HasMaxLength(100);
            Property(u => u.LastName).IsRequired().HasMaxLength(100);
            Property(u => u.BirthDate).IsOptional();
            Property(u => u.Gender).IsOptional().HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(u => u.Laterality).IsOptional().HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(u => u.Country).IsRequired().HasMaxLength(100);
            Property(u => u.Address).IsRequired().HasMaxLength(150);

            Ignore(u => u.GenderValue);
            Ignore(u => u.LateralityValue);
        }
    }
}
