using Application.Common.Adapters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Base
{
    public class BaseEntityUnitOfWorkQuery<TEntity>: IEntityUnitOfWorkQuery<TEntity> where TEntity : class, IBaseEntity, new()
    {
        private readonly IUnitOfWorkQuery _unitOfWork;

        public BaseEntityUnitOfWorkQuery(IUnitOfWorkQuery unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TEntity> GetById(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null) => 
             await _unitOfWork.GetById(id, includeFunc);

        public async Task<TEntity> GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions) => 
            await _unitOfWork.GetById(id, includeExpressions);

        public async Task<List<TEntity>> GetList(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null) =>
            await _unitOfWork.GetList(includeFunc);

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, 
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null) => 
                await _unitOfWork.GetList(predicate, includeFunc);
    }
}
