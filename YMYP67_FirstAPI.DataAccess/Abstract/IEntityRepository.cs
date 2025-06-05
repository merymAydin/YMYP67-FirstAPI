using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity ,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //GetAll() metodu, filtreleme yapılmadan tüm verileri döndürür.filter null filtre yok demek ztn
        //GetAll(category) metodu belirli bir ürüne ait tüm ürünleri döndürür
        IQueryable<T> GetAllQueryable(Expression<Func<T,bool>>? filter = null);
    }
}