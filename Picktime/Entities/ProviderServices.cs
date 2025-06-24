using Picktime.DTOs.Provider;
using Picktime.DTOs.ProviderService;
using Picktime.Heplers.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{

    public class ProviderServices : BaseEntity

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
        public ICollection<UserReview> UserReviewServices { get; set; }

       


    }
}
