using Domain.Entities;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWorkQuery
    {
        bool Any<TEntity>() where TEntity : class, IBaseEntity, new();
        Task<bool> AnyAsync<TEntity>() where TEntity : class, IBaseEntity, new();

        int GetCount<TEntity>() where TEntity : class, IBaseEntity, new();
        int GetCount<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IBaseEntity, new();     

        Task<TEntity> GetById<TEntity>(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null) where TEntity : class, IBaseEntity, new();
        Task<TEntity> GetById<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class, IBaseEntity, new();

        Task<List<TEntity>> GetList<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null, bool AsNoTracking = false) where TEntity : class, IBaseEntity, new();
        Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null, bool AsNoTracking = false) where TEntity : class, IBaseEntity, new();

    }
}
