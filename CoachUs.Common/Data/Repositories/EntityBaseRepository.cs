using CoachUs.Common.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CoachUs.Common.Data.Repositories
{
    public abstract class BaseRepository
    {
        public abstract Type Type { get; }
    }

    //public class EntityBaseRepository<C, T> : IEntityBaseRepository<T>
    public class EntityBaseRepository<T> : BaseRepository, IEntityBaseRepository<T>
            //where C : DbContext
            where T : class, IEntityBase//, new()
    {

        private DbContext dataContext;

        //public T Value { get; set; }

        public override Type Type
        {
            get { return typeof(T); }
        }

        //public EntityBaseRepository(IDbFactory<DbContext> dbFactory)
        //{
        //    DbFactory = dbFactory;
        //}
        public EntityBaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region Properties
        protected IDbFactory<DbContext> DbFactory
        {
            get;
            private set;
        }

        protected IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        protected DbContext DbContext
        {
            //get { return dataContext ?? (dataContext = DbFactory.Init()); }
            get { return dataContext ?? (dataContext = UnitOfWork.DbContext); }
        }
        #endregion

        public virtual IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual IDbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual T Insert(T entity)
        {
            //var dbEntityEntry = DbContext.Entry<T>(entity);
            //dbEntityEntry.State = EntityState.Added;
            //var result = dbEntityEntry.Entity;
            var result = DbSet.Add(entity);
            //DbContext.SaveChanges();
            return result;
        }
        public virtual void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            //DbContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            //var dbEntityEntry = DbContext.Entry<T>(entity);
            //dbEntityEntry.State = EntityState.Deleted;

            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
            //DbContext.SaveChanges();
        }

        public virtual void LoadReference<TProperty>(T entity, Expression<Func<T, TProperty>> navigationProperty) where TProperty : class
        {
            DbContext.Entry<T>(entity).Reference(navigationProperty).Load();
        }
    }

    public class EntityBaseRepositoryCollection
    {
        readonly IUnitOfWork unitOfWork = null;
        private Dictionary<Type, BaseRepository> dictionary;

        public EntityBaseRepositoryCollection(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dictionary = new Dictionary<Type, BaseRepository>();
        }

        public void Put<T>(EntityBaseRepository<T> item) where T : class, IEntityBase
        {
            dictionary[typeof(T)] = item;
        }

        public void Add<T>() where T : class, IEntityBase
        {
            dictionary[typeof(T)] = new EntityBaseRepository<T>(unitOfWork);
        }

        public EntityBaseRepository<T> Get<T>() where T : class, IEntityBase
        {
            return dictionary[typeof(T)] as EntityBaseRepository<T>;
        }
    }
}
