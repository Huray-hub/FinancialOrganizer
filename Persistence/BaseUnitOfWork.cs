using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Persistence
{
    public class BaseUnitOfWork
    {
        private protected readonly object _syncObject = new object();
        private protected readonly IDbContext _dbContext;

        private readonly Dictionary<Type, object> _dbSets;

        public BaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSets = new Dictionary<Type, object>();
        }

        private protected DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity
        {
            var type = typeof(TEntity);
            DbSet<TEntity> dbSet;
            if (_dbSets.ContainsKey(type))
                dbSet = (DbSet<TEntity>)_dbSets[type];
            else
            {
                dbSet = _dbContext.Set<TEntity>();
                _dbSets.Add(type, dbSet);
            }

            return dbSet;
        }
    }
}
