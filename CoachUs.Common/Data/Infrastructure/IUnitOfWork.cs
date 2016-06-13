using System;
using System.Data.Entity;

namespace CoachUs.Common.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        void Commit();
    }
}
