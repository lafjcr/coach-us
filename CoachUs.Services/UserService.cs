using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Common.Data.Services;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Data.Infrastructure;
using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Services
{
    class UsersService : BaseService<User>, IUsersService
    {
        //EntityBaseRepository<CoachUsContext, User> userRepository = new EntityBaseRepository<CoachUsContext, User>(new DbFactory());

        bool IsAdmin { get; set; }

        //public UserService(IDbFactory<CoachUsContext> dbFactory) : base(dbFactory)
        public UsersService(bool isAdmin, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            IsAdmin = isAdmin;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            ICollection<UserModel> result = null;
            if (IsAdmin)
                result = repository.Get().ToList().ToModelList();
            return result;
        }

        public UserModel GetUser(string id)
        {
            UserModel result = null;
            if (IsAdmin)
                result = repository.GetById(id).ToModel();
            return result;
        }

        /// <summary>
        /// This method is temporaly just for dev testing purpose
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserModel AddUser(UserModel model)
        {
            if (IsAdmin)
            {
                var user = model.ToEntity();
                user.Id = model.Id ?? Guid.NewGuid().ToString();
                user.PasswordHash = "AGxd3a+TeF3CNTr6PMh5kQiT4T8tKqgRlwXDANi4AExIQSG1QegV/IDxCOA3UyIcAw==";
                user.Email = user.UserName;
                user.SecurityStamp = "9828d4db-cf13-49b9-a395-344bc00a5af4";

                user = repository.Insert(user);
                Commit();
                model = user.ToModel();                
                return model;
            }
            return null;
        }

        public void UpdateUser(string id, UserModel model)
        {
            var entity = repository.GetById(id);
            entity = model.ToEntity(entity);
            repository.Update(entity);
            Commit();
        }

        public void DeleteUser(string id)
        {
            var entity = repository.GetById(id);
            repository.Delete(entity);
            Commit();
        }
    }
}
