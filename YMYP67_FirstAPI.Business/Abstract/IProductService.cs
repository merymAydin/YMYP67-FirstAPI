using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Concrete;

namespace YMYP67_FirstAPI.Business.Abstract
{
    public interface IProductService : IGenericService<Product> 
    {
        List<Product> GetProductByCategory(int categoryId);
        List<Product> GetProductByPriceRange(decimal minPrice,decimal maxPrice);
        List<Product> GetProductsInStock();
        List<Product> GetProductsOutOfStock();
        IQueryable<Product> GetAllQueryable();
    }
}
