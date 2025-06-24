using Picktime.DTOs.Errors;
using Picktime.DTOs.Provider;

namespace Picktime.Interfaces
{
    public interface IProvider
    {
        public Task<AppResponse<List<GetProviderOutputDTO>>> GetProviderDetails(int id);
        public Task<AppResponse<List<GetProviderOutputDTO>>> GetAllProvider();
        public Task<AppResponse<AverageServiceTimePerMinuteDTO>> CalculateAverageServiceTime(RequestCalculateAverageServiceTimeDTO requestDTO);
        public Task<AppResponse<float>> CalculateRatingByServiceProvider(RequestCalculateRatingByServiceProviderDTO requestDTO);
        public Task<AppResponse<GetProviderOutputDTO>> AddProvider(AddProviderInputDTO input);
        public Task<AppResponse<GetProviderOutputDTO>> UpdateProvider(UpdateProviderInputDTO input);
        public Task<AppResponse> RemoveProvider(int providerId);
    }
}
