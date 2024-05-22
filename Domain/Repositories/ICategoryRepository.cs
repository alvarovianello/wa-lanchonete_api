using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> RegisterCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
    }
}
