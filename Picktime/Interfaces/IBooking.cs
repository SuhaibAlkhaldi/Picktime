using Picktime.DTOs.Booking;
using Picktime.DTOs.Errors;
using Picktime.Entities;

namespace Picktime.Interfaces
{
    public interface IBooking
    {
        Task<AppResponse> Create(CreateBookingDTO input);
        Task<int> GenerateTicket();
        Task<AppResponse<bool>> Complete(int bookingId);
        Task<AppResponse<List<BookingDTO>>> GetUserHistory(int userId);
    }
}
