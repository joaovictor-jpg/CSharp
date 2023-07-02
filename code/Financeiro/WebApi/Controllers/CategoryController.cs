using Domain.Interfaces.ICategory;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly InterfaceCategory _interfaceCategory;
        private readonly ICategoryService _categoryService;

        public CategoryController(InterfaceCategory interfaceCategory, ICategoryService categoryService)
        {
            _interfaceCategory = interfaceCategory;
            _categoryService = categoryService;
        }

        [HttpGet("/api/ListarCategoriaUsuarios")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriaUsuarios(string emailUser)
        {
            return await _interfaceCategory.ListarCategoriaUsuarios(emailUser);
        }

        [HttpPost("/api/AdcionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdcionarCategoria(CategoriaInputModel categoriaInputModel)
        {
            Category category = new Category();

            category.IdSystem = categoriaInputModel.idSystem;
            category.Name = categoriaInputModel.name;

            await _categoryService.AdcionarCategoria(category);
            return category;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Category category)
        {
            await _categoryService.AtualizarCategoria(category);
            return category;
        }

        [HttpGet("/api/GetCategoryById")]
        [Produces("application/json")]
        public async Task<object> GetCategoryById(int id)
        {
            return await _interfaceCategory.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var category = await _interfaceCategory.GetEntityById(id);
                await _interfaceCategory.Delete(category);
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
