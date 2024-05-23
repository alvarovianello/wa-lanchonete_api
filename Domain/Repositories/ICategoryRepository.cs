using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task RegisterCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<IEnumerable<Category>> GetAllCategories();
        Task UpdateCategory(Category category);
        
    }
}
