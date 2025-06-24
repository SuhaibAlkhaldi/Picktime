using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Coupon;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockUpItemController : ControllerBase
    {
        private ILockUpItem _lockUpItem;

        public LockUpItemController(ILockUpItem lockUpItem)
        {
            _lockUpItem = lockUpItem;
        }



        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCoupon(AddCouponInputDTO input)
        {
            try
            {
                var result = await _lockUpItem.AddCoupon(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponInputDTO input)
        {
            try
            {
                var result = await _lockUpItem.UpdateCoupon(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            try
            {
                var result = await _lockUpItem.DeleteCoupon(couponId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
