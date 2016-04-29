using CoachUs.Common.Data.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace CoachUs.Common.Data.Repositories
{
    public class EntityBaseRepository<C, T> : IEntityBaseRepository<T>
            where C : DbContext
            where T : class//, IEntityBase, new()
    {

        private C dataContext;

        #region Properties
        protected IDbFactory<C> DbFactory
        {
            get;
            private set;
        }

        protected C DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public EntityBaseRepository(IDbFactory<C> dbFactory)
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
        //public T GetSingle(int id)
        //{
        //    return GetAll().FirstOrDefault(x => x.Id == id);
        //}
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
