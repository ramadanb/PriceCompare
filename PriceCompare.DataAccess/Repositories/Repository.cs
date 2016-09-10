using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected  DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Context = context;
            DbSet = Context.Set<TEntity>();
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

           Context.Set<TEntity>().Add(entity);
        }

        public TEntity AddIfNotExists(TEntity entity, Expression<Func<TEntity, bool>> predicate = null) 
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var exists = predicate != null ? DbSet.Any(predicate) : DbSet.Any();

            return !exists ? DbSet.Add(entity) :null;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Edit(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
