using Picktime.Heplers.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{

    public class ProviderService : SharedClass

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly ExpectedEstimatedTime { get; set; }
        public TimeOnly ActualEstimatedTime { get; set; }
        public EServicesActions Status { get; set; }

        [ForeignKey("ProviderId")] 
        public int ProviderId { get; set; } 
        public Provider Providers { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<UserReviewService> UserReviewServices { get; set; }


    }
}
