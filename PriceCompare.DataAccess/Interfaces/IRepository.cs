using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        TEntity AddIfNotExists(TEntity entity, Expression<Func<TEntity, bool>> predicate = null);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);

        void Save();


    }
}
