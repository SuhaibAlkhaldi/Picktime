using Picktime.DTOs.Errors;
using Picktime.DTOs.ProviderService;

namespace Picktime.Interfaces
{
    public interface IProviderServiceService
    {
        public Task<AppResponse<ServiceDTO>> AddService(AddProviderServiceInputDTO input);
        public Task<AppResponse<ServiceDTO>> UpdateService(UpdateProviderServiceInputDTO input);
        public Task<AppResponse> DeleteService(int serviceId);
    }
}
