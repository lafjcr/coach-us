using System;
using System.Data.Entity;

namespace CoachUs.Common.Data.Infrastructure
{
    public interface IDbFactory<T> : IDisposable where T : DbContext
    {
        T Init();
    }
}
