using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.Entities.Concrete;

namespace YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfGenericRepository<Person>, IPersonDal
    {
        public EfPersonDal(FirstApiContext context) : base(context)
        {
        }
    }
}
