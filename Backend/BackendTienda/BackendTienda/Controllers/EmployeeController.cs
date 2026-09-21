using BackendTienda.Feautures.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _service.GetAll();
            return Ok(employees);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var employee = await _service.GetById(Id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployee request)
        {
            await _service.Add(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployee request)
        {
            await _service.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.Delete(Id);
            return Ok();
        }

    }
}
