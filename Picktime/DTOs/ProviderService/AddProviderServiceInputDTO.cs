using Picktime.Heplers.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs.ProviderService
{
    public class AddProviderServiceInputDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly ExpectedEstimatedTime { get; set; }
        public TimeOnly ActualEstimatedTime { get; set; }
        public EServicesActions Status { get; set; }
        public int ProviderId { get; set; }
    }
}
