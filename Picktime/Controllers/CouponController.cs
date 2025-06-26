using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Coupon;
using Picktime.Helpers.Enums;
using Picktime.Interfaces;
using Picktime.Middleware;

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
        [AuthorizeUserType(UserType.Client)]
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




        [AuthorizeUserType(UserType.Client)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCoupons()
        {
            try
            {
                var result = await _coupons.GetAllCoupons();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AuthorizeUserType(UserType.SystemAdmin)]
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



        [AuthorizeUserType(UserType.Client)]
        [HttpPost("[action]")]
        public async Task<IActionResult> RedeemCoupon(int lockUpItemId)
        {
            try
            {
                var result = await _coupons.RedeemCoupon(lockUpItemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [AuthorizeUserType(UserType.SystemAdmin)]
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




        [AuthorizeUserType(UserType.SystemAdmin)]
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
