using System.Data.Entity;

namespace CoachUs.Common.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
        void Commit();
    }
}
