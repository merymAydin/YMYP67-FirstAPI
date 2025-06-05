using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;
using YMYP67_FirstAPI.Entities.Concrete;
using YMYP67_FirstAPI.Entities.Dtos.Category;

namespace YMYP67_FirstAPI.Business.Concrete;
public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public Category GetById(int id)
    {
        return _categoryDal.Get(c => c.Id == id);
    }

    public List<Category> GetList()
    {
        return _categoryDal.GetAll();
    }

    public IQueryable<Category> GetAllQueryable()
    {
        return _categoryDal.GetAllQueryable();
    }

    public void Insert(Category entity)
    {

        _categoryDal.Add(entity);
    }

    public void Modify(Category entity)
    {
        entity.UpdateAt = DateTime.Now; // Güncelleme tarihini ayarla
        _categoryDal.Update(entity);
    }

    public void Remove(Category entity)
    {
        _categoryDal.Delete(entity);
    }

    public List<Category> GetAllCategoryWithProducts()
    {
        return _categoryDal.GetAllQueryable().Include(c => c.Products).ToList();

    }

    IQueryable<Category> IGenericService<Category>.GetAllCategoryWithProducts()
    {
        throw new NotImplementedException();
    }
} 