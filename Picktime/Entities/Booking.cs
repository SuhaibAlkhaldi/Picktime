namespace Picktime.Entities
{
    public class Booking : SharedClass
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal ExpectedArrivalTime { get; set; }
        public int TicketNumber { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
        public int ServiceId { get; set; }
        public Service Services { get; set; }

    }
}
