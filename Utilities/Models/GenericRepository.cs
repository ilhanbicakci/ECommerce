using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Utilities.Models
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Any(predicate) : _set.Any();
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Count(predicate) : _set.Count(); 
        }

        public void CreateMany(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
        }

        public void CreateOne(T entity)
        {
            _set.Add(entity);

        }

        public void DeleteMany(IEnumerable<T> entities)
        {
           _set.RemoveRange(entities);
        }

        public void DeleteMany(Expression<Func<T, bool>> predicate = null)
        {
            var entities = ReadMany(predicate);
            DeleteMany(entities);
        }

        public void DeleteOne(T entity)
        {
            _set.Remove(entity);
        }

        public void DeleteOne(object entityKey)
        {
            var entity = ReadOne(entityKey);
            DeleteOne(entity);
        }

        public T ReadFirst(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.FirstOrDefault(predicate) : _set.FirstOrDefault();
        }

        public IEnumerable<T> ReadMany(Expression<Func<T, bool>> predicate = null, string[] includes = null)
        {
            IQueryable<T> entities = predicate != null ? _set.Where(predicate) : _set;

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    entities = entities.Include(include);
                }
            }
            return entities;
        }

        public T ReadOne(object entityKey)
        {
            return _set.Find(entityKey);
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            _context.Entry(entities).State = EntityState.Modified;
        }

        public void UpdateOne(T entity)
        {
            
            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}

