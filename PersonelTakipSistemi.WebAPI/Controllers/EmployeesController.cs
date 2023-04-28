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
        [HttpPost("EmployeeAdd")]
        public IActionResult EmployeeAdd([FromQuery] EmployeeAddRequestDto model)
        {
            var result = _employeeService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("EmployeeGetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("EmployeeUpdate")]
        public IActionResult EmployeeUpdate([FromBody] EmployeeRequestDto model)
        {
            var result = _employeeService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("EmployeeDelete")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("EmployeeGetById")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);
            if (result.Success)
            { 
                return Ok(result); 
            }
            return BadRequest(result);
        }


    }
}
