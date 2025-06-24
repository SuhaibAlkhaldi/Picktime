namespace Picktime.DTOs.Coupon
{
    public class CouponDTO
    {
        public int LockUpItemId { get; set; }
        public string CouponName { get; set; }
        public int Points { get; set; }
        public float Discount { get; set; }
        public int LockUpTypeId { get; set; }
    }
}
