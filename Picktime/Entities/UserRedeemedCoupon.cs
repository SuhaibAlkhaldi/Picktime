using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class UserRedeemedCoupon:SharedClass
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("LockUpItemId")]
        public int LockUpItemId { get; set; } 

        public DateTime RedeemedAt { get; set; }

        public User User { get; set; }
        public LockUpItems LockUpItem { get; set; }
    }
}
