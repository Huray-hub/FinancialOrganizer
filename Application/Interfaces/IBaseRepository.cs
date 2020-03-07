using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
