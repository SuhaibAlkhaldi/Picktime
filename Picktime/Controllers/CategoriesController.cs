using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.Interfaces;

namespace Picktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _category.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
