using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Entities;
using DAL.Entities.Students;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    /// <summary>
    /// Implementation of the Generic Repository pattern
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : class
    {
        private readonly StudentsContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public CommonRepository(StudentsContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _dbSet;

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            return navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
        }

        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return predicate != null ? _dbSet.Where(predicate) : null;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return entity != null ? _dbSet.Add(entity) : null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            TEntity updatedEntity = _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return updatedEntity;
        }

        public virtual TEntity Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);

            return Delete(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            return _dbSet.Remove(entity);
        }
    }
}
