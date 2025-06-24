using Picktime.DTOs.Errors;
using Picktime.DTOs.Review;

namespace Picktime.Interfaces
{
    public interface IReview
    {
        Task<AppResponse> CreateReview(CreateReviewDTO input);
        Task<AppResponse<List<GetAllReviwesDTO>>> GetAllReviwes(int ServiceId);
        Task<string> CalculateTimeOfService(int ServiceId);
        Task<AppResponse> DeleteReview(int reviewId);
    }
}
