using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using YMYP67_FirstAPI.Business.Concrete;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;

namespace YMYP67_FirstApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerManager _customerManager;
        public CustomersController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Customer listesi");
        }
    }
}