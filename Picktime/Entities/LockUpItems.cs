namespace Picktime.Entities
{
    public class LockUpItems : SharedClass
    {
        public int Points { get; set; }
        public float Discount { get; set; }
        public int LockUpTypeId { get; set; }
        public LockUpType LockUpType { get; set; }
    }
}
