using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs.Booking;
using Picktime.DTOs.Category;
using Picktime.DTOs.Errors;
using Picktime.Entities;
using Picktime.Helpers.Enums;
using Picktime.Helpers.Error;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class BookingService : IBooking
    {


        private readonly PickTimeDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingService(PickTimeDbContext context , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }



        // make the service complete 
        public async Task<AppResponse<bool>> Complete(int bookingId)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(bookingId);
                if (booking == null)
                    return AppResponse<bool>.Error(new Error { Message = "false" });

                booking.Status = EServicesActions.Completed;
                await _context.SaveChangesAsync();

                return AppResponse<bool>.Error(new Error { Message = "true" });
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error(new Error { Message = ErrorKeys.ErrorInBookingComplete, Category = "Booking" });
            }
            
        }

        public async Task<AppResponse> Create(CreateBookingDTO input)
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

                var ticketNumber = await GenerateTicket();

                var booking = new Booking
                {
                    Description = input.Description,
                    UserId = userId,
                    ProviderServiceId = input.ServiceId,
                    TicketNumber = ticketNumber,
                    Status = EServicesActions.InProgress,
                    ExpectedArrivalTime = input.ExpectedArrivalTime
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return AppResponse.Success();
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error(new Error { Message = ErrorKeys.ErrorInCreatingBooking, Category = "Booking" });

            }
        }


        //public async Task<string> Create(CreateBookingDTO input)
        //{

        //    try
        //    {
        //        var ticketNumber = await GenerateTicket();
        //        var booking = new Booking()
        //        {
        //            Description = input.Description,
        //            UserId = input.UserId, // from token 
        //            ProviderServiceId = input.ServiceId, // from the id of the srvice
        //            TicketNumber = ticketNumber,
        //            Status = EServicesActions.InProgress,
        //            ExpectedArrivalTime = input.ExpectedArrivalTime,

        //        };
        //        _context.Bookings.Add(booking);
        //        await _context.SaveChangesAsync();
        //        return $"Booking created successfully. Your ticket number is {ticketNumber}";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"ERROR: {ex.Message} \n\n INNER: {ex.InnerException?.Message}";
        //    }
        //}

        public async Task<int> GenerateTicket()
        {
            var lastTicket = await _context.Bookings.OrderByDescending(b => b.TicketNumber).Select(b => b.TicketNumber).FirstOrDefaultAsync();

            return lastTicket + 1;
        }

        //get the history of all services for specific user
        public async Task<AppResponse<List<BookingDTO>>> GetUserHistory(int userId)
        {
            try
            {
                var bookingHistory = await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.ProviderServices)
                .Select(b => new BookingDTO
                {
                    Id = b.Id,
                    Description = b.Description,
                    ExpectedArrivalTime = b.ExpectedArrivalTime,
                    ProviderServiceName = b.ProviderServices.Name
                })
                .ToListAsync();

                return new AppResponse<List<BookingDTO>>
                {
                    Data = bookingHistory
                };
            }
            catch (Exception ex)
            {
                return AppResponse<List<BookingDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetUserHistory, Category = "Booking" });

            }
            
        }
        public async Task<string> ActivateBooking(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);

            if (booking == null)
                return "Booking not found.";

            if (booking.Status != EServicesActions.InProgress)
                return $"Cannot activate booking. Current status: {booking.Status}";

            booking.Status = EServicesActions.Active;
            booking.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return "Booking activated successfully.";
        }

    }
}
