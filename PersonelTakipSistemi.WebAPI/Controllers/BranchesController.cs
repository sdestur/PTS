using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelTakipSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        IBranchService _branchService;
        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpPost("BranchAdd")]
        public IActionResult Add([FromBody] BranchAddRequestDto model)
        {
            var result = _branchService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("BranchGetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _branchService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("BranchGetAll")]
        public IActionResult GetAll()
        {
            var result = _branchService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllQ")]
        public IActionResult GetAllQ()
        {
            var result = _branchService.GetAllQ();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("BranchDelete")]
        public IActionResult Delete(int id)
        {
            var result = _branchService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("BranchUpdate")]
        public IActionResult Update([FromBody] BranchUpdateRequestDto model)
        {
            var result = _branchService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
