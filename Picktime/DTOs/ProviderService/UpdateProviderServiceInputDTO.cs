using Picktime.Helpers.Enums;

namespace Picktime.DTOs.ProviderService
{
    public class UpdateProviderServiceInputDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeOnly? ExpectedEstimatedTime { get; set; }
        public TimeOnly? ActualEstimatedTime { get; set; }
        public EServicesActions? Status { get; set; }
        public int? ProviderId { get; set; }
    }
}
