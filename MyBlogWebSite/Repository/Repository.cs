using Microsoft.EntityFrameworkCore;
using MyBlogWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlogWebSite.Repository
{
    /*
 * Not: Bu sınıf, doğrudan DbContext ile çalışabilecek....
 */
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {

        //1. Bu sınıfı miras alan tüm sınıflar, DbContext ile çalışmalı.
        protected DbContext dbContext;
        //2. Bu sınıftaki her IRepository metodu, T nesnesinden oluşan bir dbset ile çalışabilir.
        internal DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            /*
             * db'ye kayıt için iki seçenek var:
             * Doğrudan kayıt: Her "Add" çalıştığında db'ye kaydeder.
             * Bellekte beklet, toplu kaydet: Her "Add" çalıştığında bellekteki koleksiyona ekler. Toplu bir biçimde db'ye sonradan eklenir.
             * 
             */
            // 1. Yöntem isteniyorsa:
            dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            var TEntity = dbContext.Entry<T>(entity);
            TEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }


        public IList<T> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            //istenen özellikler (model - navigation property), virgül ile ayrılacak. 
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            query = query.Where(q => q.IsPublished == true);
            return query.ToList();
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}

