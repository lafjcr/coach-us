using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;

namespace CoachUs.Common.Data.Services
{
    //public class BaseService<C, T>
    public abstract class BaseService<T>
            //where C : CoachUsContext
            where T : class//, IEntityBase, new()
    {
        IUnitOfWork unitOfWork = null;
        protected EntityBaseRepository<T> repository;

        //public BaseService(IDbFactory<C> dbFactory)
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //repository = new EntityBaseRepository<T>(dbFactory);
            repository = new EntityBaseRepository<T>(unitOfWork);
        }

        protected void Commit()
        {
            unitOfWork.Commit();
        }
    }
}
