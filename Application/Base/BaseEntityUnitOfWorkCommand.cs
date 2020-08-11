using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Base
{
    public class BaseEntityUnitOfWorkCommand<TEntity> : IEntityUnitOfWorkCommand<TEntity> where TEntity : class, IBaseEntity, new()
    {
        private readonly IUnitOfWorkCommand _unitOfWork;

        public BaseEntityUnitOfWorkCommand(IUnitOfWorkCommand unitOfWork) => _unitOfWork = unitOfWork;

        public void Add(TEntity entity) => _unitOfWork.Add(entity);

        public void AddRange(IEnumerable<TEntity> entity) => _unitOfWork.AddRange(entity);

        public void AttachAndUpdate(TEntity entity, params string[] propertiesChanged) => _unitOfWork.AttachAndUpdate(entity, propertiesChanged);

        public void Remove(TEntity entity) => _unitOfWork.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entity) =>  _unitOfWork.RemoveRange(entity);

        public void Update(TEntity entity) => _unitOfWork.Update(entity);

        public void SaveChanges() => _unitOfWork.SaveChangesAsync();

        public void BulkSaveChanges(IList<TEntity> entities, string metaTimestampKey = null, List<string> propertiesToInclude = null) => 
            _unitOfWork.BulkSaveChanges(entities, metaTimestampKey, propertiesToInclude);
    }
}
