using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Concrete
{
    public class Person:BaseEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
