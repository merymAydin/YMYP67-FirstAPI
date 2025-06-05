using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Business.Abstract;
public interface IGenericService<T> where T : class, IEntity, new()
{
    void Insert(T entity);
    void Modify(T entity);
    void Remove(T entity);
    T GetById(int id);
    List<T> GetList();
    IQueryable<T> GetAllCategoryWithProducts();
}