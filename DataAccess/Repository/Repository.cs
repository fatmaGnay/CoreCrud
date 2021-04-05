using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext DbContext;
        private readonly DbSet<T> DbSet; // tanımladık
        public Repository(DbContext dbContext)//peoje açılır açılmaz
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();//değer verdik.
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Get ile çekip sildiğimiz için linq ile liste dönmek yerine direk remove ile direk o veriyi silebiliriz çünkü gelen belli bir veri
        /// Belli bir veri olmasaydı linq ile liste dönemk zorunda kalacaktık çünkü birden fazla veri geleceği için remove çalışmaz.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        /// find methodu ID üzerinden ulaşır
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Şarta göre listeleyip bize liste veriyor
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> IRepository<T>.GetAll(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> iQueryable = DbSet 
               .Where(condition);
            return iQueryable;
        }
    }
}
