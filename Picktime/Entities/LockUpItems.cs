using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class LockUpItems : SharedClass
    {
        public int Points { get; set; }
        public float Discount { get; set; }
        [ForeignKey("LockUpTypeId")]
        public int LockUpTypeId { get; set; }
        public LockUpType LockUpType { get; set; }
    }
}
