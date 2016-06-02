using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Common.Data.Services;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Data.Infrastructure;
using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
            {
                result = repository.Get().ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public UserModel GetUser(string id)
        {
            UserModel result = null;
            if (IsAdmin)
            {
                result = repository.GetById(id).ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
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
                if (model == null)
                    throw new ArgumentNullException("model");
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
            throw new UnauthorizedAccessException();
        }

        public void UpdateUser(UserModel model)
        {
            if (IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");
                var entity = repository.GetById(model.Id);
                if (entity == null)
                    throw new ObjectNotFoundException();
                entity = model.ToEntity(entity);
                repository.Update(entity);
                Commit();
            }
            throw new UnauthorizedAccessException();
        }

        public void DeleteUser(string id)
        {
            if (IsAdmin)
            {
                var entity = repository.GetById(id);
                if (entity == null)
                    throw new ObjectNotFoundException();
                repository.Delete(entity);
                Commit();
            }
            throw new UnauthorizedAccessException();
        }
    }
}
