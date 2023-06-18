using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository
{
    public class ExpenseRepository : RepositoryGenerics<Expense>, InterfaceExpense
    {
        public Task<IList<Expense>> ListarDespesasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Expense>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
