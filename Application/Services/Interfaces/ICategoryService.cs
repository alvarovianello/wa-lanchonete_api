using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IActionResult> RegisterCategory(Category category);
        Task<IActionResult> GetCategoryById(int id);
        Task<IActionResult> GetCategoryByName(string name);
    }
}
