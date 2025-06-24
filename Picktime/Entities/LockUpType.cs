namespace Picktime.Entities
{
    public class LockUpType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<LockUpItems> Items { get; set; }
    }
}
