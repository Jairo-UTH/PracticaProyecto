using BackendTienda.Business;
using BackendTienda.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BackendTienda.DTOs.OrderDTOs;

namespace BackendTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderBusiness _service) : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            return Ok(await _service.Create(request));
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var url = $"{Request.Scheme}://{Request.Host}";

            return Ok(await _service.GetAll(url));
        }
    }
}