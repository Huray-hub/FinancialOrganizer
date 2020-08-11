using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Base
{
    public interface IEntityUnitOfWorkQuery<TEntity> where TEntity : class, IBaseEntity, new()
    {
        Task<TEntity> GetById(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);

        Task<TEntity> GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions);

        Task<List<TEntity>> GetList(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);
    }
}
