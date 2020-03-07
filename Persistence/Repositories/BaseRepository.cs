using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces;

namespace Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() => dbSet.ToList();
        public TEntity GetById(Guid id) => dbSet.Find(id);
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => dbSet.Where(predicate).ToList();

        public void Insert(TEntity entity) => _context.Set<TEntity>().Add(entity);
        public void InsertRange(IEnumerable<TEntity> entities) => dbSet.AddRange(entities);

        public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(TEntity entity) => dbSet.Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);
    }
}
