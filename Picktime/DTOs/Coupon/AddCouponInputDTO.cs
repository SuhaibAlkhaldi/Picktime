using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs.Coupon
{
    public class AddCouponInputDTO
    {
        public string CouponName { get; set; }
        public int Points { get; set; }
        public float Discount { get; set; }
        public int LockUpTypeId { get; set; }
    }
}
