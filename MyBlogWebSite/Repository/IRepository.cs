using MyBlogWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlogWebSite.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll(Expression<Func<T, bool>> expression = null,
                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                      string includeProperties = null
                      );
        //T Get(int id);
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Edit(T entity);

    }
}
