using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Services
{
    //public class UserService : BaseService<CoachUsContext, User>
    public class UserService : BaseService<User>
    {
        //EntityBaseRepository<CoachUsContext, User> userRepository = new EntityBaseRepository<CoachUsContext, User>(new DbFactory());

        //public UserService(IDbFactory<CoachUsContext> dbFactory) : base(dbFactory)
        public UserService()
        {
        }

        public IQueryable<User> GetUsers()
        {
            return repository.GetAll();
        }
    }

    public class RoleService : BaseService<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
    {
        public IQueryable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> GetRoles()
        {
            return repository.GetAll();
        }
    }
}
