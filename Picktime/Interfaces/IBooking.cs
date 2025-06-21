using Picktime.DTOs;
using Picktime.Entities;

namespace Picktime.Interfaces
{
    public interface IBooking
    {
        Task<string> Create(CreateBookingDTO input);
        Task<int> GenerateTicket();
        Task<bool> Complete(int bookingId);
        public Task<List<BookingDTO>> GetUserHistory(int userId);
    }
}
