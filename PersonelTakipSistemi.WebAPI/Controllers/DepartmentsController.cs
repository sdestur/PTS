using Business.Abstract;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.CompanyDtos;
using Entity.DTOs.DepartmentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelTakipSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("AddDepartment")]
        public IActionResult Add([FromQuery] DepartmentAddRequestDto model)
        {
            var result = _departmentService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllDepartment")]
        public IActionResult GetAllDepartment()
        {
            var result = _departmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GeyByIdDepartment")]
        public IActionResult Get(int id) 
        {
            var result = _departmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("DepartmentUpdate")]
        public IActionResult Update([FromBody] DepartmentUpdateRequestDto model)
        {
            var result = _departmentService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
