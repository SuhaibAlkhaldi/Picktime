using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface ICategory
    {
        public Task<List<GetAllCategoriesOutputDTO>> GetAllCategories();
    }
}
