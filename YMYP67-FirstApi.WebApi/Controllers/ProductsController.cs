using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.Business.Concrete;
using YMYP67_FirstAPI.Entities.Concrete;
using YMYP67_FirstAPI.Entities.Dtos.Category;
using YMYP67_FirstAPI.Entities.Dtos.Product;

namespace YMYP67_FirsAPI.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productManager;
    public ProductsController(IProductService productManager)
    {
        _productManager = productManager;
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _productManager.Insert(product);
        var p = new
        {
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock,
            product.ImageUrl,
            product.CategoryID
        };
        return Ok(p);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        //include bağlantılı olduğu tabloyu ve bilgileri göstermeyi sağlıyor yani product category sınıfı ile birleşip öyle geliyor
        var response = _productManager.GetAllQueryable().Include(p => p.Category).ToList();

        List<ProductResponseDto> dtos = response.Select(p => new ProductResponseDto(p.Id,p.Name,p.Description,p.Price,p.Stock,p.Category.Name)).ToList();
        return Ok(dtos);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Product product = _productManager.GetById(id);
        if (product == null)
        {
            return NotFound($"category with id {id} not found");
        }
        return Ok(product);
    }


    [HttpPut]
    public IActionResult Update(UpdateProductRequestDto dto)
    {
        Product product = new()
        {
            Id = dto.Id,
            Name = dto.name,
            Description = dto.description,
            IsActive = dto.isDeleted
        };
        _productManager.Modify(product);
        return Ok(product);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateByID(int id, Product product)
    {
        Product response = _productManager.GetById(id);
        if (product == null)
        {
            return NotFound($"category with id {id} not found");
        }
        response.Name = product.Name;
        response.Description = product.Description;
        response.IsActive = product.IsActive;
        _productManager.Modify(response);
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Product product = _productManager.GetById(id);
        if (product == null)
        {
            return NotFound($"Category with ID {id} not found");
        }
        _productManager.Remove(product);
        return Ok($"Category with ID {id} deleted succesfully");
    }
}