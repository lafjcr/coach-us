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

        readonly CallerUserInfo callerUserInfo;

        //public UserService(IDbFactory<CoachUsContext> dbFactory) : base(dbFactory)
        public UsersService(CallerUserInfo callerUserInfo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.callerUserInfo = callerUserInfo;
        }

        #region Users
        public IEnumerable<UserModel> GetUsers()
        {
            ICollection<UserModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = repository.Get().ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public UserModel GetUser(string id)
        {
            UserModel result = null;
            if (callerUserInfo.IsAdmin || callerUserInfo.UserId == id)
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
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = model.ToEntity();
                entity.Id = model.Id ?? Guid.NewGuid().ToString();
                entity.PasswordHash = "AGxd3a+TeF3CNTr6PMh5kQiT4T8tKqgRlwXDANi4AExIQSG1QegV/IDxCOA3UyIcAw==";
                entity.Email = entity.UserName;
                entity.SecurityStamp = "9828d4db-cf13-49b9-a395-344bc00a5af4";

                entity = repository.Insert(entity);
                Commit();

                model = entity.ToModel();
                return model;
            }
            throw new UnauthorizedAccessException();
        }

        public void UpdateUser(UserModel model)
        {
            if (callerUserInfo.IsAdmin)
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
            else throw new UnauthorizedAccessException();
        }

        public void DeleteUser(string id)
        {
            if (callerUserInfo.IsAdmin)
            {
                var entity = repository.GetById(id);
                if (entity == null)
                    throw new ObjectNotFoundException();
                repository.Delete(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }
        #endregion

        #region UserDetails
        public UserDetailModel GetUserDetails(string id)
        {
            if (callerUserInfo.IsAdmin || callerUserInfo.UserId == id)
            {
                var entity = repository.GetById(id);
                if (entity == null)
                    throw new ObjectNotFoundException();

                var result = entity.UserDetail.ToModel();
                result = result ?? new UserDetailModel();
                result.UserId = entity.Id;
                result.PhoneNumber = entity.PhoneNumber;

                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public void SaveUserDetails(UserDetailModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (model.UserId != callerUserInfo.UserId)
                throw new UnauthorizedAccessException();

            var entity = repository.GetById(model.UserId);
            if (entity == null)
                throw new ObjectNotFoundException();

            entity.UserDetail = model.ToEntity(entity.UserDetail);
            entity.PhoneNumber = model.PhoneNumber;
            repository.Update(entity);
            Commit();
        }
        #endregion
    }
}
