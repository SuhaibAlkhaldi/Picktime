using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface IUserReview
    {
        public Task<AppResponse> DeleteReview(int reviewId);
    }
}
