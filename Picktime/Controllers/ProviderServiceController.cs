using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Provider;
using Picktime.DTOs.ProviderService;
using Picktime.Helpers.Enums;
using Picktime.Interfaces;
using Picktime.Middleware;

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




        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
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



        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
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





        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
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
