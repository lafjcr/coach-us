using CoachUs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Models
{
    public static class UserExtensions
    {
        public static UserModel ToModel(this User entity)
        {
            var result = new UserModel();
            result.Id = entity.Id;
            result.Username = entity.UserName;
            return result;
        }

        public static List<UserModel> ToModelList(this List<User> entities)
        {
            var result = new List<UserModel>();
            entities.ForEach(i => result.Add(i.ToModel()));
            return result;
        }
    }
}
