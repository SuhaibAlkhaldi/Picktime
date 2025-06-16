namespace Picktime.Entities
{
    public class Providers : SharedClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public decimal AverageTime { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Services> Services { get; set; }
       
    }
}
