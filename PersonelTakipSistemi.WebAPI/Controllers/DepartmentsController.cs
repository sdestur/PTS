using Business.Abstract;
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
        [HttpPost("DepartmentAdd")]
        public IActionResult Add([FromQuery] DepartmentAddRequestDto model)
        {
            var result = _departmentService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
