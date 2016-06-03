using CoachUs.Models;
using System.Collections.Generic;

namespace CoachUs.Services
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUser(string id);
        UserModel AddUser(UserModel model);
        void UpdateUser(UserModel model);
        void DeleteUser(string id);

        UserDetailModel GetUserDetails(string id);
        void SaveUserDetails(UserDetailModel model);
    }
}