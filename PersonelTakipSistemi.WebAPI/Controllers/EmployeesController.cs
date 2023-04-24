using Business.Abstract;
using Entity.DTOs.EmployeeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelTakipSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("PersonelEkleme")]
        public IActionResult EmployeeAdd([FromQuery] EmployeeAddRequestDto model)
        {
            var result = _employeeService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
