using Picktime.Heplers.Enums;

namespace Picktime.DTOs
{
    public class RequestCalculateAverageServiceTimeDTO
    {
        public int providerId { set; get; }
        public EServicesActions Status { get; set; }
    }
}
