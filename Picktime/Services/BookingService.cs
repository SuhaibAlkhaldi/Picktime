using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Entities;
using Picktime.Heplers.Enums;
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
        public async Task<bool> Complete(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            booking.Status = EServicesActions.Completed;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string> Create(CreateBookingDTO input)
        {
            try
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

                return $"Booking created successfully. Your ticket number is {ticketNumber}";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message} \n\n INNER: {ex.InnerException?.Message}";
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
        public async Task<List<BookingDTO>> GetUserHistory(int userId)
        {
            var bookingHistory = await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.ProviderService)
                .Select(b => new BookingDTO
                {
                    Id = b.Id,
                    Description = b.Description,
                    ExpectedArrivalTime = b.ExpectedArrivalTime,
                    ProviderServiceName = b.ProviderService.Name
                })
                .ToListAsync();

            return bookingHistory;
        }

    }
}
