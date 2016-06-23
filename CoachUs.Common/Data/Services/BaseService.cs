using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoachUs.Common.Data.Services
{
    //public class BaseService<C, T>
    public abstract class BaseService<T>
            //where C : CoachUsContext
            where T : class, IEntityBase//, new()
    {
        readonly IUnitOfWork unitOfWork = null;
        EntityBaseRepositoryCollection repositories;

        //public BaseService(IDbFactory<C> dbFactory)
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repositories = new EntityBaseRepositoryCollection(unitOfWork);
            //repository = new EntityBaseRepository<T>(dbFactory);
            //repository = new EntityBaseRepository<T>(unitOfWork);
            AddRepository<T>();
        }

        protected EntityBaseRepository<T> MainRepository
        {
            get
            {
                return repositories.Get<T>();
            }
        }

        protected EntityBaseRepository<TRepository> Repository<TRepository>() where TRepository : class, IEntityBase
        {
            return repositories.Get<TRepository>();
        }


        protected void AddRepository<TRepository>() where TRepository : class, IEntityBase
        {
            repositories.Add<TRepository>();
        }

        protected void Commit()
        {
            unitOfWork.Commit();
        }

        protected DbContextTransaction BeginTransaction()
        {
            return unitOfWork.BeginTransaction();
        }
    }
}
