using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.Entities.Dtos.Category;
//record gelen değerleri kontrol eder 
public sealed record CategoryResponseDTO : IDto
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;
    //init= readOnly bir daha set yapamazsın yani değiştiremezsin
    public string Description { get; init; } = string.Empty;
}