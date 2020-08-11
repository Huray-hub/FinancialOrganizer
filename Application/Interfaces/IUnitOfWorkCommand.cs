using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWorkCommand
    {
        void Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new();
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IBaseEntity, new();

        void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new();
        void AttachAndUpdate<TEntity>(TEntity entity, params string[] propertiesChanged) where TEntity : class, IBaseEntity, new();

        void Remove<TEntity>(TEntity entity) where TEntity : class, IBaseEntity, new();
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IBaseEntity, new();
                
        Task SaveChangesAsync();
        void BulkSaveChanges<TEntity>(IList<TEntity> entities, string metaTimestampKey = null, List<string> propertiesToInclude = null) where TEntity : class, IBaseEntity, new();
    }
}
