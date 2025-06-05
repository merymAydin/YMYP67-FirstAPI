using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;


namespace YMYP67_FirstAPI.Entities.Concrete
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty ;
        public int CategoryID { get; set; }
        public Category? Category { get; set; } 
    }

}
