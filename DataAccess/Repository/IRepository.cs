using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class 
    {

        /// <summary>
        /// Ekleme için kullanılır
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Silmek için kullanılır
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Get methodu id üzerinden veriyi getirdik.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Güncellemek için kullanılır
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Model katmanımızda bulunan her T tipi için aşağıda tanımladığımız fonksiyonları gerçekleştirebilecek generic bir repository tanımlıyoruz.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> condition);
    }
}
