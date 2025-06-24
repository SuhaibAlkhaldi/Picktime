namespace Picktime.DTOs.Booking
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ExpectedArrivalTime { get; set; }
        public string ProviderServiceName { get; set; }
    }
}
