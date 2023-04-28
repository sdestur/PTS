using Business.Abstract;
using Entity.DTOs.MissionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelTakipSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        IMissionService _missionService;
        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpPost("MissionAdd")]
        public IActionResult Add([FromBody]MissionAddRequestDtos model)
        {
            var result = _missionService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("MissionGetAll")]
        public IActionResult GetAllMission()
        {
            var result = _missionService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("MissionGetById")]
        public IActionResult Get(int id)
        {
            var result = _missionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("MissionDelete")]
        public IActionResult Delete(int id)
        {
            var result = _missionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("MissionUpdate")]
        public IActionResult Update(MissionUpdateRequestDto model)
        {
            var result = _missionService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
