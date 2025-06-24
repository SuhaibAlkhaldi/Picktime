using Picktime.DTOs.Category;
using Picktime.DTOs.Errors;

namespace Picktime.Interfaces
{
    public interface ICategory
    {
        public Task<AppResponse<GetCategoriesOutputDTO>> GetOneCategory(int categoryId);
        public Task<AppResponse<List<GetCategoriesOutputDTO>>> GetAllCategories();
        public Task<AppResponse<CategoryOutputDTO>> AddCategory(AddCategoryInputDTO input);
        public Task<AppResponse<CategoryOutputDTO>> UpdateCategory(UpdateCategoryInputDTO input);
        public Task<AppResponse> DeleteCategory(int categoryId);
    }
}
