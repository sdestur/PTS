using Business.Abstract;
using Entity.DTOs.AddressDtos;
using Entity.DTOs.BranchDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelTakipSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost("AddresAdd")]
        public IActionResult Add([FromBody] AddressAddRequestDto model)
        {
            var result = _addressService.Add(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("AddressDelete")]
        public IActionResult Delete(int id)
        {
            var result = _addressService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("BranchUpdate")]
        public IActionResult Update([FromBody] AddressUpdateRequestDto model)
        {
            var result = _addressService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("AddressGetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _addressService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
