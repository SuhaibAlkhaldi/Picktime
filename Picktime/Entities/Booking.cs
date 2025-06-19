using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Booking : SharedClass
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal ExpectedArrivalTime { get; set; }
        public int TicketNumber { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Users { get; set; }
        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public ProviderService ServicesEntity { get; set; }
    }
}
