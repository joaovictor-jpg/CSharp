using Domain.Interfaces.InterfaceService;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroServices : IUsuarioSistemaFinanceiroService
    {

        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServices(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioSistemaFinanceiro(UserFinancialSystem userFinancialSystem)
        {
            await _interfaceUsuarioSistemaFinanceiro.Add(userFinancialSystem);
        }
    }
}
