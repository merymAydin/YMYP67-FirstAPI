using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Dtos.Product
{
    public class UpdateProductRequestDto : IDto
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public bool isActive { get; init; } = true;
        public bool isDeleted { get; init; } = true;
    }
}
