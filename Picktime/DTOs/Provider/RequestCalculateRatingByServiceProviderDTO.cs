using Picktime.Heplers.Enums;

namespace Picktime.DTOs.Provider
{
    public class RequestCalculateRatingByServiceProviderDTO
    {
        public int ServiceProviderId {  get; set; }
        public EServicesActions? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
