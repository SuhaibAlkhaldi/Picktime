namespace Picktime.DTOs.Booking
{
    public class CreateBookingDTO
    {
        //public int UserId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public DateTime ExpectedArrivalTime { get; set; }
    }
}
