using Entities.Entities;

namespace Domain.Interfaces.InterfaceService
{
    public interface IExpenseService
    {
        Task AdicionarExpense(Expense expense);
        Task AtualizarExpense(Expense expense);
    }
}
