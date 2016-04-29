using CoachUs.Common.Data;
using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Data.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace CoachUs.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {

        private CoachUsContext dataContext;

        #region Properties
        protected IDbFactory<CoachUsContext> DbFactory
        {
            get;
            private set;
        }

        protected CoachUsContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public EntityBaseRepository(IDbFactory<CoachUsContext> dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            //DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }
        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;

            //DbContext.Set<T>().Remove(entity);
        }
    }
}
