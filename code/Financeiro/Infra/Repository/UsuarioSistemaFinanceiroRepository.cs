using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository
{
    public class UsuarioSistemaFinanceiroRepository : RepositoryGenerics<UserFinancialSystem>, InterfaceUsuarioSistemaFinanceiro
    {
        public Task<IList<UserFinancialSystem>> ListarUsuariosSistema(int IdSistema)
        {
            throw new NotImplementedException();
        }

        public Task<UserFinancialSystem> ObterUsuarioPorEmail(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task RemoverUsuarios(List<UserFinancialSystem> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
