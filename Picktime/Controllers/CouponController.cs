using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Coupon;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICoupon _coupons;

        public CouponController(ICoupon coupons)
        {
            _coupons = coupons;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPoints(int userId)
        {
            try
            {
                var result = await _coupons.GetAllPoints(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCoupon(AddCouponInputDTO input)
        {
            try
            {
                var result = await _coupons.AddCoupon(input);
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
                var result = await _coupons.UpdateCoupon(input);
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
                var result = await _coupons.DeleteCoupon(couponId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
