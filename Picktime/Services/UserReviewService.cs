using Picktime.Context;
using Picktime.DTOs;
using Picktime.DTOs.Provider;
using Picktime.Heplers;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class UserReviewService : IUserReview
    {
        private readonly PickTimeDbContext _context;

        public UserReviewService(PickTimeDbContext context)
        {
            _context = context;
        }



        public async Task<AppResponse> DeleteReview(int reviewId)
        {
            try
            {
                if (reviewId <= 0 || reviewId == null)
                    return AppResponse.Error(new Error { Message = "Invalid provider ID." });

                var review = await _context.UserReviewServices.FindAsync(reviewId);
                if (review == null)
                    return AppResponse.Error(new Error { Message = "Not Found" });

                _context.UserReviewServices.Remove(review);
                await _context.SaveChangesAsync();

                return AppResponse.Success();

            }
            catch (Exception ex)
            {
                return AppResponse.Error(new Error { Message = ErrorKeys.ErrorInDeleteUserReview, Category = "UserReview" });

            }
        }
    }
}
