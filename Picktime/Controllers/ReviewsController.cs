using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Review;
using Picktime.Entities;
using Picktime.Interfaces;
using Picktime.Services;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReview _IReview;

        public ReviewsController(IReview review)
        {
            _IReview = review;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CalculateTimeOfService(int ServiceId)
        {
            try
            {
                var result = await _IReview.CalculateTimeOfService(ServiceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReviwes(int ServiceId)
        {
            try
            {
                var result = await _IReview.GetAllReviwes(ServiceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview(CreateReviewDTO input)
        {
            try
            {
                var result = await _IReview.CreateReview(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
