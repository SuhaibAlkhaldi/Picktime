using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.DTOs.Category;
using Picktime.DTOs.Provider;
using Picktime.DTOs.ProviderService;
using Picktime.Entities;
using Picktime.Heplers;
using Picktime.Interfaces;
using System.Runtime.CompilerServices;

namespace Picktime.Services
{
    public class ProviderServiceService : IProviderServiceService
    {
        private readonly PickTimeDbContext _context;

        public ProviderServiceService(PickTimeDbContext context)
        {
            _context = context;
        }

        public async Task<AppResponse<ServiceDTO>> AddService(AddProviderServiceInputDTO input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                if (string.IsNullOrEmpty(input.Name))
                {
                    return AppResponse<ServiceDTO>.Error(new Error { Message = "Please Enter Service Name" });
                }
                bool exist = _context.ProviderServices.Any(x => x.Name == input.Name);
                if (exist)
                {
                    return AppResponse<ServiceDTO>.Error(new Error { Message = "Service Already Exist" });
                }

                var addService = new ProviderServices
                {
                    Name = input.Name,
                    Description = input.Description,
                    ExpectedEstimatedTime = input.ExpectedEstimatedTime,
                    ActualEstimatedTime = input.ActualEstimatedTime,
                    Status = input.Status,
                    ProviderId = input.ProviderId,
                };
                
                await _context.ProviderServices.AddAsync(addService);
                await _context.SaveChangesAsync();
                return new AppResponse<ServiceDTO>
                {
                    Data = new ServiceDTO
                    {
                        Name = input.Name,
                        Description = input.Description,
                        ExpectedEstimatedTime = input.ExpectedEstimatedTime,
                        ActualEstimatedTime = input.ActualEstimatedTime,
                        Status = input.Status,
                        ProviderId = input.ProviderId
                    }
                    
                };

            }
            catch (Exception ex)
            {
                return AppResponse<ServiceDTO>.Error(new Error { Message = ErrorKeys.ErrorInAddProviderService, Category = "Service" });

            }

        }


        public async Task<AppResponse<ServiceDTO>> UpdateService(UpdateProviderServiceInputDTO input)
        {
            try
            {
                var service = _context.ProviderServices.Where(x => x.Id == input.Id).FirstOrDefault();
                if (service == null)
                {
                    return AppResponse<ServiceDTO>.Error(new Error { Message = "Service Not Found" });
                }

                service.Name = input.Name ?? service.Name;
                service.Description = input.Description ?? service.Description;
                service.ExpectedEstimatedTime = input.ExpectedEstimatedTime ?? service.ExpectedEstimatedTime;
                service.ActualEstimatedTime = input.ActualEstimatedTime ?? service.ActualEstimatedTime;
                service.Status = input.Status ?? service.Status;
                service.ProviderId = input.ProviderId ?? service.ProviderId;
                _context.Update(service);
                await _context.SaveChangesAsync();
                return new AppResponse<ServiceDTO>
                {
                    Data = new ServiceDTO
                    {
                        Id = service.Id,
                        Name = service.Name,
                        Description = service.Description,
                        ExpectedEstimatedTime = service.ExpectedEstimatedTime,
                        ActualEstimatedTime = service.ActualEstimatedTime,
                        Status = service.Status,
                        ProviderId = service.ProviderId
                    }
                };
            }
            catch (Exception ex)
            {
                return AppResponse<ServiceDTO>.Error(new Error { Message = ErrorKeys.ErrorInUpdateProviderService, Category = "Service" });

            }
        }



        public async Task<AppResponse> DeleteService(int serviceId)
        {
            try
            {
                if (serviceId <= 0 || serviceId == null)
                    return AppResponse.Error(new Error { Message = "Invalid provider ID." });

                var service = await _context.ProviderServices.FindAsync(serviceId);
                if (service == null)
                    return AppResponse.Error(new Error { Message = "Provider not found." });

                _context.ProviderServices.Remove(service);
                await _context.SaveChangesAsync();

                return AppResponse.Success();

            }
            catch (Exception ex)
            {
                return AppResponse<ServiceDTO>.Error(new Error { Message = ErrorKeys.ErrorInDeleteProviderService, Category = "Service" });

            }
        }
    }
}
