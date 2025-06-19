using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface IProviderService
    {
        public Task<List<GetProviderOutputDTO>> GetProviderDetails(int id);
        public Task<List<GetProviderOutputDTO>> GetAllProvider();
        public Task<AverageServiceTimePerMinuteDTO> CalculateAverageServiceTime(RequestCalculateAverageServiceTimeDTO requestDTO);
        public Task<float> CalculateRatingByServiceProvider(RequestCalculateRatingByServiceProviderDTO requestDTO);
    }
}
