using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LanchoneteDbContext _context;
        public CategoryRepository(LanchoneteDbContext context)
        {
            _context = context;
        }

        public async Task<Category> RegisterCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return _context.Set<Category>().FirstOrDefault(c => c.Id.Equals(id));
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return _context.Set<Category>().FirstOrDefault(c => c.Name.Equals(name));
        }
    }
}
