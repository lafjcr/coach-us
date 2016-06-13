using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CoachUs.Common.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase//, new()
    {
        IDbSet<T> DbSet { get; }
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(object id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void LoadReference<TProperty>(T entity, Expression<Func<T, TProperty>> navigationProperty) where TProperty : class;
    }
}
