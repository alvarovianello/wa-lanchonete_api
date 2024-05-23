using Application.Contracts.Request.RequestCategory;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces
{
    public interface ICategoryService
    {
        ValueTask<IActionResult> RegisterCategory(CategoryPostRequest categoryRequest);
        Task<IActionResult> GetCategoryById(int id);
        Task<IActionResult> GetCategoryByName(string name);
        Task<IActionResult> GetAllCategories();
        Task<IActionResult> UpdateCategory(CategoryPutRequest categoryPutRequest);
    }
}
