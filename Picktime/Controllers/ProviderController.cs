using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Provider;
using Picktime.Helpers.Enums;
using Picktime.Interfaces;
using Picktime.Middleware;
using System.Management;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private IProvider _providerService;

        public ProviderController(IProvider providerService)
        {
            _providerService = providerService;
        }


        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProviderDetails(int id)
        {
            try
            {
                var result = await _providerService.GetProviderDetails(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProvider()
        {
            try
            {
                var result = await _providerService.GetAllProvider();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }





        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetCalculatedAverageServiceTime(RequestCalculateAverageServiceTimeDTO requestDTO)
        {
            try
            {
                var result = await _providerService.CalculateAverageServiceTime(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> CalculateRatingByServiceProvider(RequestCalculateRatingByServiceProviderDTO requestDTO)
        {
            try
            {
                var result = await _providerService.CalculateRatingByServiceProvider(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProvider(AddProviderInputDTO input)
        {
            try
            {
                var result = await _providerService.AddProvider(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProvider(UpdateProviderInputDTO input)
        {
            try
            {
                var result = await _providerService.UpdateProvider(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }





        [AuthorizeUserType(UserType.SystemAdmin, UserType.ProviderCreator)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveProvider(int providerId)
        {
            try
            {
                var result = await _providerService.RemoveProvider(providerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
