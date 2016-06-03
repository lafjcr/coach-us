using CoachUs.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoachUs.Models
{
    public static class UserExtensions
    {
        public static UserModel ToModel(this User entity, UserModel result = null)
        {
            if (entity == null) return null;
            result = result ?? new UserModel();

            result.Id = entity.Id;
            result.UserName = entity.UserName;

            return result;
        }

        public static ICollection<UserModel> ToModelList(this ICollection<User> entities)
        {
            if (entities == null) return null;
            return entities.Select(item => item.ToModel()).ToList();
        }

        public static User ToEntity(this UserModel model, User result = null)
        {
            if (model == null) return null;
            result = result ?? new User();

            result.Id = result.Id ?? model.Id;
            result.Email = result.UserName = model.UserName;

            return result;
        }
    }
}
