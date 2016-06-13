using System;
using System.Data.Entity;

namespace CoachUs.Common.Data.Infrastructure
{
    public class UnitOfWork<C> : IUnitOfWork
        where C : DbContext
    {
        private readonly IDbFactory<C> dbFactory;
        private C dbContext;

        public UnitOfWork(IDbFactory<C> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbFactory.Dispose();
            dbContext.Dispose();
        }
    }
}
