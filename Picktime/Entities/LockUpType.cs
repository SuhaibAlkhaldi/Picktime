namespace Picktime.Entities
{
    public class LockUpType : SharedClass
    {
        public string Name { get; set; }
        public ICollection<LockUpItems> Items { get; set; }
    }
}
