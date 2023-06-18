using Entities.Entities;

namespace Domain.Interfaces.InterfaceService
{
    public interface ICategoryService
    {
        Task AdcionarCategoria(Category category);
        Task AtualizarCategoria(Category category);
    }
}
