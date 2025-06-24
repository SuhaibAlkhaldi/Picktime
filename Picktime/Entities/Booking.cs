using Picktime.Heplers.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Booking : SharedClass
    {
        public string Description { get; set; }
        public EServicesActions Status { get; set; } // used enum (EServicesActions) values
        public DateTime ExpectedArrivalTime { get; set; }
        public int TicketNumber { get; set; }
        public bool IsReviewed { get; set; } = false;
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Users { get; set; }
public int ProviderServiceId { get; set; }

   [ForeignKey("ProviderServiceId")]
   public ProviderService ProviderService { get; set; }
    }
}
