using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs.Coupon
{
    public class UpdateCouponInputDTO
    {
        public int Id { get; set; }
        public string? CouponName { get; set; }
        public int? Points { get; set; }
        public float? Discount { get; set; }
        public int? LockUpTypeId { get; set; }
    }
}
