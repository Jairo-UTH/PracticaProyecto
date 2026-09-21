using BackendTienda.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(CategoryBusiness _service) : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

    }
}

