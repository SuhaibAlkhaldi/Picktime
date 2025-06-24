using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private IUserReview _review;

        public UserReviewController(IUserReview review)
        {
            _review = review;
        }



        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            try
            {
                var result = await _review.DeleteReview(reviewId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    } 
}
