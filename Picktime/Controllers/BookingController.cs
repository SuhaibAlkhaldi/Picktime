using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Booking;
using Picktime.Helpers.Enums;
using Picktime.Interfaces;
using Picktime.Middleware;

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

        [AuthorizeUserType(UserType.Client)]
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

        [AuthorizeUserType(UserType.Client)]
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
        [AuthorizeUserType(UserType.Client)]
        [HttpGet("[action]")]
        public async Task<IActionResult> ActivateBooking(int bookingId)
        {
            try
            {
                var result = await _bookingService.ActivateBooking(bookingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [AuthorizeUserType(UserType.Client)]
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
