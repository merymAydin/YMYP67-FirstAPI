using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.Entities.Concrete;


namespace YMYP67_FirstAPI.Business.Concrete;
public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IQueryable<Product> GetAllCategoryWithProducts()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetAllQueryable()
    {
        return _productDal.GetAllQueryable();
    }

    public Product GetById(int id)
    {
        return _productDal.Get(p => p.Id == id);
    }

    public List<Product> GetList()
    {
        return _productDal.GetAllQueryable().Include(p =>p.Category).ToList();
    }
    public List<Product> GetProductByCategory(int categoryId)
    {
        return _productDal.GetAll(p => p.CategoryID == categoryId);
    }

    public List<Product> GetProductByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _productDal.GetAll(p => p.Price >= minPrice && p.Price <= maxPrice);
    }

    public List<Product> GetProductsInStock()
    {
        return _productDal.GetAll(p => p.Stock > 0);
    }

    public List<Product> GetProductsOutOfStock()
    {
        return _productDal.GetAll(p => p.Stock == 0);
    }

    public void Insert(Product entity)
    {
        _productDal.Add(entity);
    }

    public void Modify(Product entity)
    {
        _productDal.Update(entity);

    }

    public void Remove(Product entity)
    {
        _productDal.Delete(entity);
    }
}