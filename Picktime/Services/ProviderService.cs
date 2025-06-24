using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.DTOs.Auth;
using Picktime.DTOs.Category;
using Picktime.DTOs.Provider;
using Picktime.Entities;
using Picktime.Heplers;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class ProviderService : IProvider
    {
        private readonly PickTimeDbContext _context;

        public ProviderService(PickTimeDbContext context)
        {
            _context = context;
        }
        public async Task<AppResponse<AverageServiceTimePerMinuteDTO>> CalculateAverageServiceTime(RequestCalculateAverageServiceTimeDTO requestDTO)
        {
            try
            {
                if (requestDTO.providerId == 0)
                    return AppResponse<AverageServiceTimePerMinuteDTO>.Error(new Error { Message = "Please Enter A Valid Id." });
                var calculatedSummationTimeDTO = await _context.Providers.Where(x => x.Id == requestDTO.providerId)
                    .Select(s => new AverageServiceTimePerMinuteDTO
                    {
                        ActualEstimatedTime = s.ProviderServices.Where(x => x.Status == requestDTO.Status).Average(x => x.ActualEstimatedTime.Minute + (x.ActualEstimatedTime.Second * 0.1)),
                        ExpectedEstimatedTime = s.ProviderServices.Where(x => x.Status == requestDTO.Status).Average(x => x.ExpectedEstimatedTime.Minute + (x.ExpectedEstimatedTime.Second * 0.1))
                    }).SingleOrDefaultAsync();

                if (calculatedSummationTimeDTO == null)
                {
                    return new AppResponse<AverageServiceTimePerMinuteDTO>
                    {
                        Data = new AverageServiceTimePerMinuteDTO
                        {
                            ActualEstimatedTime = 0,
                            ExpectedEstimatedTime = 0
                        }
                    };

                }
                return new AppResponse<AverageServiceTimePerMinuteDTO>
                {
                    Data = calculatedSummationTimeDTO
                };
                
            }
            catch (Exception ex)
            {
                return AppResponse<AverageServiceTimePerMinuteDTO>.Error(new Error { Message = ErrorKeys.ErrorInCalculateAverageServiceTime, Category = "Provider" });
            }
        }

        public async Task<AppResponse<float>> CalculateRatingByServiceProvider(RequestCalculateRatingByServiceProviderDTO requestDTO)
        {
            try
            {
                if (requestDTO.ServiceProviderId == 0)
                    throw new Exception("Please Enter A Valid Id");
                var result = await _context.ProviderServices
                            .Where(x =>
                                    x.Id == requestDTO.ServiceProviderId
                                    && requestDTO.Status.HasValue ? x.Status == requestDTO.Status : true
                                    && requestDTO.DateFrom.HasValue ? x.CreationDate >= requestDTO.DateFrom : true
                                    && requestDTO.DateTo.HasValue ? x.CreationDate <= requestDTO.DateTo : true
                                    )
                            .Select(s => (float?)s.UserReviewServices.Average(x => x.Rate))
                            .FirstOrDefaultAsync() ?? 0f;
                return new AppResponse<float>()
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return AppResponse<float>.Error(new Error { Message = ErrorKeys.ErrorInCalculateRatingByServiceProvider, Category = "Provider" });

            }
        }

        public async Task<AppResponse<List<GetProviderOutputDTO>>> GetAllProvider()
        {
            try
            {
                var provider = await _context.Providers.Select(x => new GetProviderOutputDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Logo = x.Logo,
                    CategoryId = x.CategoryId
                }).ToListAsync();
                if (provider == null)
                {
                    throw new Exception("Something Went Wrong");
                }
                return new AppResponse<List<GetProviderOutputDTO>>
                {
                    Data = provider
                };

            }
            catch (Exception ex)
            {
                return AppResponse<List<GetProviderOutputDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetProvider, Category = "Provider" });

            }
        }

        public async Task<AppResponse<List<GetProviderOutputDTO>>> GetProviderDetails(int id)
        {
            try
            {
                var findProvider = _context.Providers.Find(id);
                if (id <= 0 || id == null || findProvider == null)
                {
                    return  AppResponse<List<GetProviderOutputDTO>>.Error(new Error { Message = "There is no Provider with given ID" });
                }
                else
                {
                    var provider = await _context.Providers.Where(x => x.Id == id)
                        .Select(x => new GetProviderOutputDTO
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Logo = x.Logo,
                            CategoryId = x.CategoryId
                        }).ToListAsync();
                    if (provider == null)
                    {
                        return AppResponse<List<GetProviderOutputDTO>>.Error(new Error { Message = "Something Went Wrong" });
                    }
                    return new AppResponse<List<GetProviderOutputDTO>>
                    {
                        Data = provider
                    };
                }

            }
            catch (Exception ex)
            {
                return AppResponse<List<GetProviderOutputDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetProvider, Category = "Provider" });
            }
        }




        public async Task<AppResponse<GetProviderOutputDTO>> AddProvider(AddProviderInputDTO input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }
                bool exist = _context.Providers.Any(x => x.Name == input.Name);
                if (exist)
                {
                    return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = "Provider Already Exist" });

                }
                var addProvider = new Provider
                {
                    Name = input.Name,
                    Description = input.Description,
                    Logo = input.Logo,
                    CategoryId = input.CategoryId,
                };
                await _context.Providers.AddAsync(addProvider);
                await _context.SaveChangesAsync();
                return new AppResponse<GetProviderOutputDTO>
                {
                    Data = new GetProviderOutputDTO
                    {
                        Id = addProvider.Id,
                        Name = input.Name,
                        Description = input.Description,
                        Logo = input.Logo,
                        CategoryId = input.CategoryId
                    }
                };

            }
            catch (Exception ex)
            {
                return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = ErrorKeys.ErrorInAddProvider, Category = "Provider" });
            }
        }



        public async Task<AppResponse<GetProviderOutputDTO>> UpdateProvider(UpdateProviderInputDTO request)
        {
            try
            {
                var provider = _context.Providers.Where(x => x.Id == request.Id).FirstOrDefault();
                if (provider == null)
                {
                    return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = "Provider Not Found" });
                }

                provider.Name = string.IsNullOrWhiteSpace(request.Name) ? provider.Name : request.Name;
                provider.Description = string.IsNullOrWhiteSpace(request.Description) ? provider.Description : request.Description;
                provider.Logo = string.IsNullOrWhiteSpace(request.Logo) ? provider.Logo : request.Logo;
                if (request.CategoryId.HasValue)
                {
                    provider.CategoryId = request.CategoryId.Value;
                }
                _context.Update(provider);
                await _context.SaveChangesAsync();
                return new AppResponse<GetProviderOutputDTO>
                {
                    Data = new GetProviderOutputDTO
                    {
                        Id = provider.Id,
                        Name = provider.Name,
                        Description = provider.Description,
                        Logo = provider.Logo,
                        CategoryId = provider.CategoryId
                    }
                    
                };

            }
            catch (Exception ex)
            {
                return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = ErrorKeys.ErrorInUpdateProvider, Category = "Provider" });

            }
        }



        public async Task<AppResponse> RemoveProvider(int providerId)
        {
            try
            {
                if (providerId <= 0 || providerId == null)
                    return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = "Invalid provider ID." });

                var provider = await _context.Providers.FindAsync(providerId);
                if (provider == null)
                    return AppResponse<GetProviderOutputDTO>.Error(new Error { Message = "Provider not found." });

                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();

                return AppResponse.Success();

            }
            catch (Exception ex)
            {
                return  AppResponse.Error(new Error { Message = ErrorKeys.ErrorInDeleteProvider, Category = "Provider" });

            }
        }
    }
}
