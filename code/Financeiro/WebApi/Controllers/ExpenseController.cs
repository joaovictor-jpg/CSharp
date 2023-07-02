using Domain.Interfaces.IExpense;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly InterfaceExpense _interfaceExpense;
        private readonly IExpenseService _expenseService;

        public ExpenseController(InterfaceExpense interfaceExpense, IExpenseService expenseService)
        {
            _interfaceExpense = interfaceExpense;
            _expenseService = expenseService;
        }

        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuario(string email)
        {
            return await _interfaceExpense.ListarDespesasUsuario(email);
        }

        [HttpPost("/api/AdicionarExpense")]
        [Produces("application/json")]
        public async Task<object> AdicionarExpense(ExpenseInputModel expenseInputModel)
        {
            Expense expense = new Expense();
            
            expense.Name = expenseInputModel.Name;
            expense.Valor = expenseInputModel.Valor;
            expense.Month = expenseInputModel.Month;
            expense.Year = expenseInputModel.Year;
            expense.EnumTypeExpense = expenseInputModel.EnumTypeExpense;
            expense.RegisterDate = expenseInputModel.RegisterDate;
            expense.UpdateDate = expenseInputModel.UpdateDate;
            expense.PaymentDate = expenseInputModel.PaymentDate;
            expense.MaturityDate = expenseInputModel.MaturityDate;
            expense.PaidOut = expenseInputModel.PaidOut;
            expense.LateExpense = expenseInputModel.LateExpense;
            expense.IdCategory = expenseInputModel.IdCategory;

            await _expenseService.AdicionarExpense(expense);
            return expense;
        }

        [HttpPut("/api/AtualizarExpense")]
        [Produces("application/json")]
        public async Task<object> AtualizarExpense(Expense expense)
        {
            await _expenseService.AtualizarExpense(expense);
            return expense;
        }

        [HttpGet("/api/GetExpenseById")]
        [Produces("application/json")]
        public async Task<object> GetExpenseById(int id)
        {
            return await _interfaceExpense.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteExpense")]
        [Produces("application/json")]
        public async Task<object> DeleteExpense(int id)
        {
            try
            {
                var expense = await _interfaceExpense.GetEntityById(id);
                await _interfaceExpense.Delete(expense);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _expenseService.CarregaGraficos(emailUsuario);
        }
    }
}
