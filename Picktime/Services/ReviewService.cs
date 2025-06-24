using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.DTOs.Category;
using Picktime.DTOs.Errors;
using Picktime.DTOs.Review;
using Picktime.Entities;
using Picktime.Heplers.Enums;
using Picktime.Heplers.Error;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class ReviewService : IReview
    {
        private readonly PickTimeDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReviewService(PickTimeDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<string> CalculateTimeOfService(int serviceId)
        {
            try
            {
                var bookings = await _context.Bookings
                 .Where(b => b.ProviderServiceId == serviceId)
                 .ToListAsync();

                if (!bookings.Any())
                    return "0";

                float totalMinutes = bookings
                    .Sum(b => (float)(b.UpdatedDate - b.CreationDate).TotalMinutes);

                return $"{totalMinutes} Minutes";
            }
            catch 
            {

                return "Error When Calculate Time Of Service";
            }
            
        }



        public async Task<AppResponse> CreateReview(CreateReviewDTO input)
        {
            try
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("UserId");

                if (userIdClaim == null)
                {
                    return AppResponse.Error(new Error { Message = "User is not authenticated. Please sign in." });
                }

                int userId = int.Parse(userIdClaim.Value);
                var user = await _context.Users.FindAsync(userId);

                if (user == null || !user.IsLoggedIn)
                {
                    return AppResponse.Error(new Error { Message = "User is not signed in." });
                }
                //Check if the booking is completed and isreviwed  
                var booking = await _context.Bookings
               .FirstOrDefaultAsync(b =>
                   b.UserId == userId &&
                   b.ProviderServiceId == input.ProviderServiceId &&
                   b.Status == EServicesActions.Completed &&
                   b.IsReviewed == false);


                if (booking == null)
                    return AppResponse.Error(new Error { Message = "You must complete the service before submitting a review.." });

                // Create review
                var review = new UserReview
                {
                    UserId = userId,
                    ProviderServiceId = input.ProviderServiceId,
                    Rate = input.Rate,
                    Comment = input.Comment
                };

                await _context.UserReviewServices.AddAsync(review);

                //Update booking 
                booking.IsReviewed = true;

                // Give reward points (assume 10)
                var userPoint = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (userPoint == null)
                    return AppResponse.Error(new Error { Message = "User not found." });


                userPoint.Points += 10;
                await _context.SaveChangesAsync();

                return AppResponse.Success("Review submitted successfully.You earned 10 reward points.");
            }
            catch 
            {
                return AppResponse.Error(new Error { Message = ErrorKeys.ErrorInCreateReviews, Category = "Review" });
            }
            
          
        }

        

        public async Task<AppResponse<List<GetAllReviwesDTO>>> GetAllReviwes(int ServiceId)
        {
            try
            {
                var reviews = await _context.UserReviewServices
                               .Where(r => r.ProviderServiceId == ServiceId)
                               .Include(r => r.Users)
                               .Select(r => new GetAllReviwesDTO
                               {
                                   username = r.Users.FirstName + " " + r.Users.LastName,
                                   Rate = r.Rate,
                                   Comment = r.Comment
                               }).ToListAsync();

                return new AppResponse<List<GetAllReviwesDTO>>
                {
                    Data = reviews

                };
            }
            catch (Exception ex)
            {
                return AppResponse<List<GetAllReviwesDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetReviews, Category = "Review" });

            }

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
