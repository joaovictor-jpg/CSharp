using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository
{
    public class CategoryRepository : RepositoryGenerics<Category>, InterfaceCategory
    {
        public Task<IList<Category>> ListarCategoriaUsuarios(string email)
        {
            throw new NotImplementedException();
        }
    }
}
