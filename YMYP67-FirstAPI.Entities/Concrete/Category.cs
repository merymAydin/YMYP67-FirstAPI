using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Concrete
{
    public sealed class Category: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public List<Product> Products { get; set; } = new();
    }
}
