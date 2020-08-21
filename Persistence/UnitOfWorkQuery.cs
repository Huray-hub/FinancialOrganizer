using Application.Common.Adapters;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWorkQuery : BaseUnitOfWork, IUnitOfWorkQuery
    {
        public UnitOfWorkQuery(IDbContext dbContext) : base(dbContext) { }

        public bool Any<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            return query.Any();
        }

        public async Task<bool> AnyAsync<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            return await query.AnyAsync();
        }

        int IUnitOfWorkQuery.GetCount<TEntity>()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            int count = -1;
            lock (_syncObject)
            {
                count = query.Count();
            }
            return count;
        }

        int IUnitOfWorkQuery.GetCount<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            int count = -1;
            lock (_syncObject)
                count = query.Where(predicate).Count();

            return count;
        }

        public async Task<TEntity> GetById<TEntity>(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbset = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbset;

            if (includeFunc != null) query = includeFunc(query);

            return await query.FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<TEntity> GetById<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            foreach (var expression in includeExpressions)
                query = query.Include(expression);

            return await query.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<List<TEntity>> GetList<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null,
            bool asNoTracking = false) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            if (includeFunc != null) query = includeFunc(query);

            return asNoTracking ? await query.AsNoTracking().ToListAsync() 
                                : await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null,
            bool asNoTracking = false) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            IQueryable<TEntity> query = dbSet;

            if (includeFunc != null) query = includeFunc(query);

            return asNoTracking ? await query.Where(predicate).AsNoTracking().ToListAsync()
                                : await query.Where(predicate).ToListAsync();
        }
    }
}
