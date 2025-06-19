namespace Picktime.Entities
{
    public class Category : SharedClass
    {
        public string CategoryName { get; set; }
        public string Icon {  get; set; }
        public ICollection<Provider> ServiceProviders { get; set; }

    }
}
