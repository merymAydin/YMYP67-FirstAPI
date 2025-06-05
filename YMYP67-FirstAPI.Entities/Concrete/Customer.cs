using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Concrete
{
    public sealed class Customer : BaseEntity 
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; } 
        public string Email { get; set; } 
    }
}