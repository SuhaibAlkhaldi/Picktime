using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picktime.DTOs.Category;
using Picktime.Helpers.Enums;
using Picktime.Interfaces;
using Picktime.Middleware;

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



        [AuthorizeUserType(UserType.Client)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneCategory(int categoryId)
        {
            try
            {
                var categories = await _category.GetOneCategory(categoryId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AuthorizeUserType(UserType.Client)]
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

        [AuthorizeUserType(UserType.SystemAdmin)]
        [AuthorizeUserType(UserType.CategoryCreator)]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(AddCategoryInputDTO input)
        {
            try
            {
                var categories = await _category.AddCategory(input);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [AuthorizeUserType(UserType.SystemAdmin)]
        [AuthorizeUserType(UserType.CategoryCreator)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryInputDTO input)
        {
            try
            {
                var categories = await _category.UpdateCategory(input);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AuthorizeUserType(UserType.SystemAdmin)]
        [AuthorizeUserType(UserType.CategoryCreator)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var categories = await _category.DeleteCategory(categoryId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
