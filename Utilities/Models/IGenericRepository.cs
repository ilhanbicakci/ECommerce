using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public interface IGenericRepository<T> where T : class
    {
        void CreateOne(T entity);
        void CreateMany(IEnumerable<T> entities);

        void UpdateOne(T entity);
        void UpdateMany(IEnumerable<T> entities);

        void DeleteOne(T entity);
        void DeleteOne(object entityKey);

        void DeleteMany(IEnumerable<T> entities);
        void DeleteMany(Expression<Func<T, bool>> predicate = null);

        T ReadOne(object entityKey);
        T ReadFirst(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> ReadMany(Expression<Func<T, bool>> predicate = null, string[] includes = null);

        bool Any(Expression<Func<T, bool>> predicate = null);
        int Count(Expression<Func<T, bool>> predicate = null);

    }



}

