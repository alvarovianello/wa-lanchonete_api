using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LanchoneteDbContext context) : base(context) { }

        public async Task RegisterCategory(Category category)
        {
            await CreateAsync(category);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Expression<Func<Category, bool>> predicate = entity => entity.Id == id;
            return await GetSingleAsync(predicate);
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            Expression<Func<Category, bool>> predicate = entity => entity.Name == name;
            return await GetSingleAsync(predicate);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await GetAllAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            await UpdateAsync(category);
        }
    }
}
