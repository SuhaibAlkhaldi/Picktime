using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class ProviderService : IProviderService
    {
        private readonly PickTimeDbContext _context;

        public ProviderService(PickTimeDbContext context)
        {
            _context = context;
        }
        public async Task<AverageServiceTimePerMinuteDTO> CalculateAverageServiceTime(RequestCalculateAverageServiceTimeDTO requestDTO)
        {
            try
            {
                if (requestDTO.providerId == 0)
                    throw new Exception("Please Enter A Valid Id");
                var calculatedSummationTimeDTO = await _context.Providers.Where(x => x.Id == requestDTO.providerId)
                    .Select(s => new AverageServiceTimePerMinuteDTO
                    {
                        ActualEstimatedTime = s.ProviderServices.Where(x=> x.Status == requestDTO.Status).Average(x=>x.ActualEstimatedTime.Minute + (x.ActualEstimatedTime.Second * 0.1)),
                        ExpectedEstimatedTime  = s.ProviderServices.Where(x => x.Status == requestDTO.Status).Average(x=>x.ExpectedEstimatedTime.Minute + (x.ExpectedEstimatedTime.Second * 0.1))
                    }).SingleOrDefaultAsync();

                if (calculatedSummationTimeDTO == null)
                {
                    return new AverageServiceTimePerMinuteDTO
                    {
                        ActualEstimatedTime = 0,
                        ExpectedEstimatedTime =0
                    };

                }
                return calculatedSummationTimeDTO; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<float> CalculateRatingByServiceProvider(RequestCalculateRatingByServiceProviderDTO requestDTO)
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
                return result
;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetProviderOutputDTO>> GetAllProvider()
        {
            try
            {
                var provider = await _context.Providers.Select(x => new GetProviderOutputDTO
                {
                    Name = x.Name,
                    Description = x.Description,
                    Logo = x.Logo,
                    CategoryId = x.CategoryId
                }).ToListAsync();
                if (provider == null)
                {
                    throw new Exception("Something Went Wrong");
                }
                return provider;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetProviderOutputDTO>> GetProviderDetails(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("There is no Provider with given ID ");
                }
                else
                {
                    var provider = await _context.Providers.Where(x => x.Id == id)
                        .Select(x => new GetProviderOutputDTO
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Logo = x.Logo,
                            CategoryId = x.CategoryId
                        }).ToListAsync();
                    if (provider == null)
                    {
                        throw new Exception("Something Went Wrong");
                    }
                    return provider;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
