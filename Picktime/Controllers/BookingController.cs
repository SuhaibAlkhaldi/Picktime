using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Booking;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBooking _bookingService;

        public BookingController(IBooking bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Complete(int bookingId)
        {
            try
            {
                var result = await _bookingService.Complete(bookingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserHistory(int userId)
        {
            try
            {
                var result = await _bookingService.GetUserHistory(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateBookingDTO input)
        {
            try
            {
                var result = await _bookingService.Create(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
