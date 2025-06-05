using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Dtos.Category;
public sealed record AddCategoryRequestDto : IDto
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

