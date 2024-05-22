using Application.Services.Interfaces;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> RegisterCategory(Category category)
        {
            try
            {
                var returnGetCategoryByName = await _categoryRepository.GetCategoryByName(category.Name);

                if (returnGetCategoryByName != null)
                    return new ResultObject(HttpStatusCode.AlreadyReported, new { Warn = "O nome de categoria informado já possui cadastro" });

                var returnRegisterCategory = await _categoryRepository.RegisterCategory(category);

                if (returnRegisterCategory == null)
                    return new ResultObject(HttpStatusCode.BadRequest, new { Error = "Houve um erro ao realizar o cadastro da categoria" });

                return new ResultObject(HttpStatusCode.OK, new { Success = "Categoria cadastrada com sucesso" });

            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryById(id);

                if (category == null)
                    return new ResultObject(HttpStatusCode.NotFound, new { Info = "Categoria não encontrada" });
                else
                    return new ResultObject(HttpStatusCode.OK, category);
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> GetCategoryByName(string name)
        {
            Category category = new Category();

            try
            {
                category = await _categoryRepository.GetCategoryByName(name);

                if (category == null)
                    return new ResultObject(HttpStatusCode.NotFound, new { Info = "Categoria não encontrada" });
                else
                    return new ResultObject(HttpStatusCode.OK, category);
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }
    }
}
