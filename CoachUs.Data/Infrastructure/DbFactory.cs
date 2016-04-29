using CoachUs.Common.Data.Infrastructure;

namespace CoachUs.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory<CoachUsContext>
    {
        CoachUsContext dbContext;

        public CoachUsContext Init()
        {
            return dbContext ?? (dbContext = new CoachUsContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
