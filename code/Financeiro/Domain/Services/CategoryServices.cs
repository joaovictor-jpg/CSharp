using Domain.Interfaces.ICategory;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;

namespace Domain.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly InterfaceCategory _interfaceCategory;

        public CategoryServices(InterfaceCategory interfaceCategory)
        {
            _interfaceCategory = interfaceCategory;
        }


        public async Task AdcionarCategoria(Category category)
        {
            var valid = category.PropertyIsValidString(category.Name, "Name");
            if (valid) await _interfaceCategory.Add(category);
        }

        public async Task AtualizarCategoria(Category category)
        {
            var valid = category.PropertyIsValidString(category.Name, "Name");
            if(valid) await _interfaceCategory.Update(category);
        }
    }
}
