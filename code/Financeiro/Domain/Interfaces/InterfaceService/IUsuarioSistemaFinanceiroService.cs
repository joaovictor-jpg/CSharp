using Entities.Entities;

namespace Domain.Interfaces.InterfaceService
{
    public interface IUsuarioSistemaFinanceiroService
    {
        Task CadastrarUsuarioSistemaFinanceiro(UserFinancialSystem userFinancialSystem);
    }
}
