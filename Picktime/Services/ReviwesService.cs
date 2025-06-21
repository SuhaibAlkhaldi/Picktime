using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs.Review;
using Picktime.Entities;
using Picktime.Heplers.Enums;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class ReviwesService : IReview
    {
        private readonly PickTimeDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReviwesService(PickTimeDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<string> CalculateTimeOfService(int serviceId)
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



        public async Task<string> CreateReview(CreateReviewDTO input)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("UserId");

            if (userIdClaim == null)
            {
                return "User is not authenticated. Please sign in.";
            }

            int userId = int.Parse(userIdClaim.Value);
            var user = await _context.Users.FindAsync(userId);

            if (user == null || !user.IsLoggedIn)
            {
                return "User is not signed in.";
            }
            //Check if the booking is completed and isreviwed  
            var booking = await _context.Bookings
           .FirstOrDefaultAsync(b =>
               b.UserId == userId &&
               b.ProviderServiceId == input.ProviderServiceId &&
               b.Status == EServicesActions.Completed &&
               b.IsReviewed == false);


            if (booking == null)
                throw new Exception("You must complete the service before submitting a review.");

            // Create review
            var review = new UserReviewService
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
                throw new Exception("User not found.");

            userPoint.Points += 10;
            await _context.SaveChangesAsync();

            return "Review submitted successfully. You earned 10 reward points.";
        }

        

        public async Task<List<GetAllReviwesDTO>> GetAllReviwes(int ServiceId)
        {
            var reviews = await _context.UserReviewServices
               .Where(r => r.ProviderServiceId == ServiceId)
               .Include(r => r.Users) 
               .Select(r => new GetAllReviwesDTO
               {
                   username = r.Users.FirstName + " " + r.Users.LastName,
                   Rate = r.Rate,
                   Comment = r.Comment
               })
               .ToListAsync();

            return reviews;
        }
    }
}
