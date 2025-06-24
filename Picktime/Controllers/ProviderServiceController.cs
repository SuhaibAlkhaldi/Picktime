using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Provider;
using Picktime.DTOs.ProviderService;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderServiceController : ControllerBase
    {
        private IProviderServiceService _service;

        public ProviderServiceController(IProviderServiceService service)
        {
            _service = service;
        }




        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddService(AddProviderServiceInputDTO input)
        {
            try
            {
                var result = await _service.AddService(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateService(UpdateProviderServiceInputDTO input)
        {
            try
            {
                var result = await _service.UpdateService(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }





        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            try
            {
                var result = await _service.DeleteService(serviceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
