﻿using Application.Common.Adapters;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public void RemoveRange(IEnumerable<TEntity> entity) => _unitOfWork.RemoveRange(entity);

        public void Update(TEntity entity) => _unitOfWork.Update(entity);

        public async Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken()) => await _unitOfWork.SaveChanges(cancellationToken);

        public void BulkSaveChanges(IList<TEntity> entities, string metaTimestampKey = null, List<string> propertiesToInclude = null) =>
            _unitOfWork.BulkSaveChanges(entities, metaTimestampKey, propertiesToInclude);
    }
}
