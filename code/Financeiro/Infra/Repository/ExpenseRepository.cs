using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ExpenseRepository : RepositoryGenerics<Expense>, InterfaceExpense
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public ExpenseRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Expense>> ListarDespesasUsuario(string emailUsuario)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await (
                        from s in banco.FinancialSystem
                        join c in banco.Categorie on s.Id equals c.IdSystem
                        join us in banco.UserFinancialSystem on s.Id equals us.IdSystem
                        join d in banco.Expense on c.Id equals d.IdCategory
                        where us.EmailUser.Equals(emailUsuario) && s.Month == d.Month && s.Year == d.Year
                        select d
                    ).AsTracking().ToListAsync();
            }
        }

        public async Task<IList<Expense>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await(
                        from s in banco.FinancialSystem
                        join c in banco.Categorie on s.Id equals c.IdSystem
                        join us in banco.UserFinancialSystem on s.Id equals us.IdSystem
                        join d in banco.Expense on c.Id equals d.IdCategory
                        where us.EmailUser.Equals(emailUsuario) && d.Month < DateTime.Now.Month && !d.PaidOut
                        select d
                    ).AsTracking().ToListAsync();
            }
        }
    }
}
