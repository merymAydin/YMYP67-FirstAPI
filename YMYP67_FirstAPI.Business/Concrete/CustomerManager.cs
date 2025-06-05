using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;
using YMYP67_FirstAPI.Entities.Concrete;

namespace YMYP67_FirstAPI.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IQueryable<Customer> GetAllCategoryWithProducts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}