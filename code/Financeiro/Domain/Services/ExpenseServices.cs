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
    }
}
