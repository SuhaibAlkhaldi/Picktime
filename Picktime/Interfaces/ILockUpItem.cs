using Picktime.DTOs;
using Picktime.DTOs.Coupon;
using Picktime.Entities;

namespace Picktime.Interfaces
{
    public interface ILockUpItem
    {
        public Task<AppResponse<CouponDTO>> AddCoupon(AddCouponInputDTO input);
        public Task<AppResponse<CouponDTO>> UpdateCoupon(UpdateCouponInputDTO input);
        public Task<AppResponse> DeleteCoupon(int couponId);
    }
}
