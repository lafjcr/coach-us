using CoachUs.Common.Data.Infrastructure;

namespace CoachUs.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory<CoachUsContext> dbFactory;
        private CoachUsContext dbContext;

        public UnitOfWork(IDbFactory<CoachUsContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public CoachUsContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
