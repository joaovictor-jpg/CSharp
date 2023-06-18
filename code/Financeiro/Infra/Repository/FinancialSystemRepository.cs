using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository
{
    public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSistem
    {
        public Task<IList<FinancialSystem>> ListaSistemasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
