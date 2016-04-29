using CoachUs.Common.Data;
using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Data;
using CoachUs.Data.Entities;
using CoachUs.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachUs.Services
{
    //public class BaseService<C, T>
    public class BaseService<T>
            //where C : CoachUsContext
            where T : class//, IEntityBase, new()
    {
        protected EntityBaseRepository<CoachUsContext, T> repository;

        //public BaseService(IDbFactory<C> dbFactory)
        public BaseService()
        {
            var dbFactory = new DbFactory();
            repository = new EntityBaseRepository<CoachUsContext, T>(dbFactory);
        }
    }
}
