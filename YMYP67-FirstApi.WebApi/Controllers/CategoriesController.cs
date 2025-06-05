using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.Business.Concrete;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;
using YMYP67_FirstAPI.Entities.Concrete;
using YMYP67_FirstAPI.Entities.Dtos.Category;

namespace YMYP67_FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _categoryManager.GetAllCategoryWithProducts();
            if (response == null || !response.Any())
            {
                return NotFound("no categories found");
            }

            //var responseData = new List<Object>();
            //foreach (var category in response)
            //{
            //    var data = new
            //    {
            //        category.Id,
            //        category.Name,
            //        category.Description,
            //        category.IsActive,
            //        Products = category.Products.Select(p => new
            //        {
            //            Name = p.Name,
            //            Price = p.Price,
            //            Stock = p.Stock,
            //            Description = p.Description,
            //            CategoryId = p.CategoryId
            //        }).ToList()
            //    };
            //    responseData.Add(data);
            //}



            //var responseData = response.Select(c => new
            //{
            //    c.Id,
            //    c.Name,
            //    c.Description,
            //    c.IsActive,
            //    Products = c.Products.Select(p => new
            //    {
            //        p.Id,
            //        p.Name,
            //        p.Price
            //    }).ToList()
            //}).ToList();

            List<CategoryResponseDTO> categoryDto = new();
            foreach (var category in response)
            {
                CategoryResponseDTO dto = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
                categoryDto.Add(dto);
            }
            return Ok(categoryDto);
        }
        [HttpPost]
        public IActionResult Create(AddCategoryRequestDto dto)
        {
            Category category = new()
            {
                Name = dto.Name,
                Description = dto.Description
            };
            _categoryManager.Insert(category);
            return Ok(category);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound($"category with id {id} not found");
            }
            return Ok(category); 
        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryRequestDto dto)
        {
            Category category = new()
            {
                Id = dto.Id,
                Name = dto.name,
                Description = dto.description,
                IsActive = dto.isDeleted
            };
            _categoryManager.Modify(category);
            return Ok(category);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateByID(int id,Category category)
        {
            Category response = _categoryManager.GetById(id);
            if(category == null)
            {
                return NotFound($"category with id {id} not found");
            }
            response.Name=category.Name;
            response.Description=category.Description;
            response.IsActive=category.IsActive;
            _categoryManager.Modify(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _categoryManager.GetById(id);
            if(category == null)
            {
                return NotFound($"Category with ID {id} not found");
            }
            _categoryManager.Remove(category);
            return Ok($"Category with ID {id} deleted succesfully");
        }
    }
}