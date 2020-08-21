using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base
{
    public interface IEntityUnitOfWorkCommand<TEntity> where TEntity : class, IBaseEntity, new()
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void AttachAndUpdate(TEntity entity, params string[] propertiesChanged);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        Task<int> SaveChanges();
        void BulkSaveChanges(IList<TEntity> entity, string metaTimestampKey = null, List<string> propertiesToInclude = null);
    }
}
