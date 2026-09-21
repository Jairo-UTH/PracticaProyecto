using BackendTienda.Business;
using BackendTienda.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController (ProductBusiness _service) : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request)
        {
            return Ok(await _service.Create(request));
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] ReturnProductRequest request)
        {
            var url = $"{Request.Scheme}://{Request.Host}";
            var result = await _service.GetAll(url, request.categoryId);
            return Ok(result);
        }

    }
}
