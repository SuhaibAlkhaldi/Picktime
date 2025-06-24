using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs.Category;
using Picktime.DTOs.Errors;
using Picktime.DTOs.ProviderService;
using Picktime.Entities;
using Picktime.Heplers.Error;
using Picktime.Heplers.Image;
using Picktime.Interfaces;
using SendGrid.Helpers.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Error = Picktime.DTOs.Errors.Error;

namespace Picktime.Services
{
    public class CategoryService : ICategory
    {
        private readonly PickTimeDbContext _context;

        public CategoryService(PickTimeDbContext context)
        {
            _context = context;
        }



        public async Task<AppResponse<GetCategoriesOutputDTO>> GetOneCategory(int categoryId)
        {
            try
            {
                var category = _context.Categories.Where(x => x.Id == categoryId).Select(c => new GetCategoriesOutputDTO
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Icon = c.Icon
                }).FirstOrDefault();

                if (category == null)
                    return AppResponse<GetCategoriesOutputDTO>.Error(new Error { Message = "Category Not Found" });
                return new AppResponse<GetCategoriesOutputDTO>
                {
                    Data = category
                };
            }
            catch (Exception ex)
            {
                return AppResponse<GetCategoriesOutputDTO>.Error(new Error { Message = ErrorKeys.ErrorInGetCategory , Category="Category" });
            }
        }



        public async Task<AppResponse<List<GetCategoriesOutputDTO>>> GetAllCategories()
        {
            try
            {
                var category = _context.Categories.Select(c => new GetCategoriesOutputDTO
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Icon = c.Icon
                }).ToList();
                return new AppResponse<List<GetCategoriesOutputDTO>>
                {
                    Data = category
                };
            }
            catch (Exception ex)
            {
                return AppResponse<List<GetCategoriesOutputDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetCategory, Category = "Category" });
            }
        }



        public async Task<AppResponse<CategoryOutputDTO>> AddCategory(AddCategoryInputDTO request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.CategoryName))
                {
                    return AppResponse<CategoryOutputDTO>.Error(new Error { Message = "Please Enter Category Name" });
                }
                bool exist = _context.Categories.Any(x => x.CategoryName == request.CategoryName);
                if (exist)
                {
                    return AppResponse<CategoryOutputDTO>.Error(new Error { Message = "Category Already Exist" });
                }
                string? imagePath = null;

                if (request.Icon != null)
                {
                    imagePath = await ImageHelper.SaveImageAsync(request.Icon);
                }
                var addCategory = new Category
                {
                    CategoryName = request.CategoryName,
                    Icon = imagePath
                };
                await _context.Categories.AddAsync(addCategory);
                await _context.SaveChangesAsync();
                return new AppResponse<CategoryOutputDTO>
                {
                    Data = new CategoryOutputDTO
                    {
                        Id = addCategory.Id,
                        CategoryName = request.CategoryName,
                        Icon = imagePath
                    }
                };
            }
            catch (Exception ex)
            {
                return AppResponse<CategoryOutputDTO>.Error(new Error { Message = ErrorKeys.ErrorInCreateCategories, Category = "Category" });
            }
        }


        public async Task<AppResponse<CategoryOutputDTO>> UpdateCategory(UpdateCategoryInputDTO request)
        {
            try
            {
                var category = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
                if (category == null)
                {
                    return AppResponse<CategoryOutputDTO>.Error(new Error { Message = "Category Not Found" });
                }

                category.CategoryName = request.CategoryName ?? category.CategoryName;
                category.Icon = request.Icon ?? category.Icon;
                _context.Update(category);
                await _context.SaveChangesAsync();
                return new AppResponse<CategoryOutputDTO>
                {
                    Data = new CategoryOutputDTO
                    {
                        Id = request.Id,
                        CategoryName = request.CategoryName,
                        Icon = request.Icon
                    }
                };
            }
            catch (Exception ex)
            {
                return AppResponse<CategoryOutputDTO>.Error(new Error { Message = ErrorKeys.ErrorInUpdateCategory, Category = "Category" });
            }
        }



        public async Task<AppResponse> DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                    return AppResponse.Error(new Error { Message = "Invalid Category ID." });

                var category = await _context.Categories.FindAsync(categoryId);
                if (category == null)
                    return AppResponse.Error(new Error { Message = "Category not found." });

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return AppResponse.Success();
            }
            catch (Exception ex)
            {
                return AppResponse<AppResponse>.Error(new Error { Message = ErrorKeys.ErrorInDeleteCategory, Category = "Category" });
            }
        }

    }
}
