using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class CategoryService : ICategory
    {
        private readonly PickTimeDbContext _context;

        public CategoryService(PickTimeDbContext context)
        {
            _context = context;
        }




        public async Task<List<GetAllCategoriesOutputDTO>> GetAllCategories()
        {
            try
            {
                var category =  _context.categories.Select(c => new GetAllCategoriesOutputDTO
                {
                    CategoryName = c.CategoryName,
                    Icon = c.Icon
                }).ToList();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
