using examAPI.Models.Category;

namespace examAPI.Infrastructure.Services.CategoryService;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategory();
    
    Task<Category> GetCategoryByName(string name);
    
    Task<bool> CreateCategory(Category category);
    
    Task<bool> UpdateCategory(Category category);
    
    Task<bool> DeleteCategory(string name);
}