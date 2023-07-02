using Domain.Interfaces.IExpense;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;

namespace Domain.Services
{
    public class ExpenseServices : IExpenseService
    {

        private readonly InterfaceExpense _interfaceExpense;

        public ExpenseServices(InterfaceExpense interfaceExpense)
        {
            _interfaceExpense = interfaceExpense;
        }

        public async Task AdicionarExpense(Expense expense)
        {
            var date = DateTime.UtcNow;
            expense.RegisterDate = date;
            expense.Year = date.Year;
            expense.Month = date.Month;

            var valid = expense.PropertyIsValidString(expense.Name, "Name");

            if (valid) await _interfaceExpense.Add(expense);
        }

        public async Task AtualizarExpense(Expense expense)
        {
            var date = DateTime.UtcNow;
            expense.UpdateDate = date;

            if(expense.PaidOut) expense.PaymentDate = date;

            var valid = expense.PropertyIsValidString(expense.Name, "Name");

            if (valid) await _interfaceExpense.Update(expense);
        }

        public async Task<object> CarregaGraficos(string emailUser)
        {
            var despessasUsuario = await _interfaceExpense.ListarDespesasUsuario(emailUser);
            var despesasAnteriores = await _interfaceExpense.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUser);

            var despesas_naoPagasMesesAnteriores = despesasAnteriores.Any() ? despesasAnteriores.ToList().Sum(x => x.Valor) : 0;

            var despesas_pagas = despessasUsuario.Where(d => d.PaidOut && d.EnumTypeExpense == Entities.Enums.EnumTypeExpense.Contas).Sum(x => x.Valor);

            var despesas_pendentes = despessasUsuario.Where(d => !d.PaidOut && d.EnumTypeExpense == Entities.Enums.EnumTypeExpense.Contas).Sum(x => x.Valor);

            var investimentos = despessasUsuario.Where(d => d.EnumTypeExpense == Entities.Enums.EnumTypeExpense.Investimento).Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesas_pagas,
                despesas_pendentes = despesas_pendentes,
                despesas_naoPagasMesesAnteriores = despesas_naoPagasMesesAnteriores,
                investimentos = investimentos
            };
        }
    }
}
