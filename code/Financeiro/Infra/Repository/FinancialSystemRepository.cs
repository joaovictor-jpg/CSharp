using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSistem
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public FinancialSystemRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FinancialSystem>> ListaSistemasUsuario(string emailUsuario)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await (
                        from s in banco.FinancialSystem
                        join us in banco.UserFinancialSystem on s.Id equals us.IdSystem
                        where us.EmailUser.Equals(emailUsuario)
                        select s
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
