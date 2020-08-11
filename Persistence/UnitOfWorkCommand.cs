using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWorkCommand : BaseUnitOfWork, IUnitOfWorkCommand
    {
        public UnitOfWorkCommand(IDbContext dbContext) : base(dbContext) { }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            dbSet.Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            dbSet.AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            dbSet.Update(entity);
        }

        public void AttachAndUpdate<TEntity>(TEntity entity, params string[] propertiesChanged) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            var alreadyAttached = dbSet.Local.Any(o => o.Id == entity.Id);

            if (alreadyAttached)
            {
                var entry = _dbContext.Entry(dbSet.Local.First(o => o.Id == entity.Id));
                foreach (var s in propertiesChanged)
                {
                    var property = entry.Property(s);
                    property.CurrentValue = entity.GetType().GetProperty(s).GetValue(entity, null);
                    property.IsModified = true;
                }
                _dbContext.SaveChanges();
            }
            else
            {
                var entry = dbSet.Attach(entity);
                foreach (var s in propertiesChanged)
                    entry.Property(s).IsModified = true;

                _dbContext.SaveChanges();
                entry.State = EntityState.Detached;
            }
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            dbSet.Remove(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IBaseEntity, new()
        {
            DbSet<TEntity> dbSet = GetDbSet<TEntity>();
            dbSet.RemoveRange(entities);
        }

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public void BulkSaveChanges<TEntity>(IList<TEntity> entities, string metaTimestampKey, List<string> propertiesToInclude)
            where TEntity : class, IBaseEntity, new() =>
            _dbContext.BulkSaveChanges(entities, metaTimestampKey, propertiesToInclude);
    }
}
