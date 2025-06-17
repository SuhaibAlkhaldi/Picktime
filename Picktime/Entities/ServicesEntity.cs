namespace Picktime.Entities
{
    public class ServicesEntity : SharedClass
    {
        public string Name { get; set; }
        public int UserCount {  get; set; }
        public string Description { get; set; }
        public string EstimatedTime { get; set; }
        public int ServiceProviderId { get; set; }
        public Providers ServiceProviders { get; set; }
        public ICollection<Booking> Bookings { get; set; }


    }
}
