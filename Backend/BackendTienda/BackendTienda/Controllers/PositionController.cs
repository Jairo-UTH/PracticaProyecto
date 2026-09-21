using BackendTienda.Feautures.Employees;
using BackendTienda.Feautures.Positions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController(PositionService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var positions = await _service.GetAll();
            return Ok(positions);
        }
    }
}