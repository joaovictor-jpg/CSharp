using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ICategory
{
    public interface InterfaceCategory : InterfaceGeneric<Category>
    {
        Task<IList<Category>> ListarCategoriaUsuarios(string email);
    }
}
