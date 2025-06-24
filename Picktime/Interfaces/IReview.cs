using Picktime.DTOs.Review;

namespace Picktime.Interfaces
{
    public interface IReview
    {
        Task<string> CreateReview(CreateReviewDTO input);
        Task<List<GetAllReviwesDTO>> GetAllReviwes(int ServiceId);
        Task<string> CalculateTimeOfService(int ServiceId);
    }
}
