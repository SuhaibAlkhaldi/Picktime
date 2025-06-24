using Picktime.DTOs.Coupon;
using Picktime.DTOs.Errors;

namespace Picktime.Interfaces
{
    public interface ICoupon
    {
        Task<AppResponse<PointsSummaryDTO>> GetAllPoints(int userId);
        Task<AppResponse<CouponDTO>> AddCoupon(AddCouponInputDTO input);
        Task<AppResponse<CouponDTO>> UpdateCoupon(UpdateCouponInputDTO input);
        Task<AppResponse> DeleteCoupon(int couponId);
    }
}
