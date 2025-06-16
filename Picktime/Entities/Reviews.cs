namespace Picktime.Entities
{
    public class Reviews : SharedClass
    {
        public float Rate { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int ServiceProviderID { get; set; }
        public Users Users { get; set; }
        public Providers ServiceProviders { get; set; }

    }
}
