using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.Interfaces;
using Picktime.Services;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICopouns _copouns;

        public CouponController(ICopouns copouns)
        {
            _copouns = copouns;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPoints(int userId)
        {
            try
            {
                var result = await _copouns.GetAllPoints(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
