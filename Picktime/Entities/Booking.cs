using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Booking : BaseEntity
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal ExpectedArrivalTime { get; set; }
        public int TicketNumber { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Users { get; set; }
        public int ProviderServiceId { get; set; }

        [ForeignKey("ProviderServiceId")]
        public ProviderServices ProviderService { get; set; }
    }
}
