using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinancialSistemController : ControllerBase
    {
        private readonly InterfaceFinancialSistem _interfaceFinancialSistem;
        private readonly IFinancialSystemService _financialSystemService;

        public FinancialSistemController(InterfaceFinancialSistem interfaceFinancialSistem, IFinancialSystemService financialSystemService)
        {
            _interfaceFinancialSistem = interfaceFinancialSistem;
            _financialSystemService = financialSystemService;
        }

        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuer)
        {
            return await _interfaceFinancialSistem.ListaSistemasUsuario(emailUsuer);
        }

        [HttpPost("/api/AdicionarFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> AdicionarFinancialSystem(SistemaFinancieiroModelModel sistemaFinancieiroModelModel)
        {
            var financialSystem = new FinancialSystem();

            financialSystem.Name = sistemaFinancieiroModelModel.nome;
            financialSystem.Month = sistemaFinancieiroModelModel.mes;
            financialSystem.Year = sistemaFinancieiroModelModel.ano;
            financialSystem.Dayclosure = sistemaFinancieiroModelModel.diaFechamento;
            financialSystem.GenerateExpenseCopy = sistemaFinancieiroModelModel.gerarCopiaDespesa;
            financialSystem.CopyMonth = sistemaFinancieiroModelModel.copiaMes;
            financialSystem.CopyYear = sistemaFinancieiroModelModel.copiaAno;

            await _financialSystemService.AdicionarFinancialSystem(financialSystem);

            return Task.FromResult(financialSystem);
        }

        [HttpPut("/api/AtualizarFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> AtualizarFinancialSystem(FinancialSystem financialSystem)
        {
            await _financialSystemService.AtualizarFinancialSystem(financialSystem);
            return Task.FromResult(financialSystem);
        }

        [HttpGet("/api/GetEntityById")]
        [Produces("application/json")]
        public async Task<object> GetEntityById(int id)
        {
            return await _interfaceFinancialSistem.GetEntityById(id);
        }

        [HttpDelete("/api/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var sistemaFinanceiro = await _interfaceFinancialSistem.GetEntityById(id);
                await _interfaceFinancialSistem.Delete(sistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
