using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class CategoryRepository : RepositoryGenerics<Category>, InterfaceCategory
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public CategoryRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Category>> ListarCategoriaUsuarios(string email)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await (
                        from s in banco.FinancialSystem
                        join c in banco.Categorie on s.Id equals c.IdSystem
                        join us in banco.UserFinancialSystem on s.Id equals us.IdSystem
                        where us.EmailUser.Equals(email) && us.SystemCurrent
                        select c
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
