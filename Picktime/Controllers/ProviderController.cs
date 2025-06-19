using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs;
using Picktime.Interfaces;
using System.Management;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }



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

    }
}
