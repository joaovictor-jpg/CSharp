using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGeneric<UserFinancialSystem>
    {
        Task<IList<UserFinancialSystem>> ListarUsuariosSistema(int IdSistema);
        Task RemoverUsuarios(List<UserFinancialSystem> usuarios);
        Task<UserFinancialSystem> ObterUsuarioPorEmail(string emailUsuario);
    }
}
