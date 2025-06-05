using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Dtos.Product;
    public sealed record ProductResponseDto(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string CategoryName
     ):IDto;

