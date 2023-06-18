using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UsuarioSistemaFinanceiroRepository : RepositoryGenerics<UserFinancialSystem>, InterfaceUsuarioSistemaFinanceiro
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public UsuarioSistemaFinanceiroRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UserFinancialSystem>> ListarUsuariosSistema(int IdSistema)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UserFinancialSystems.Where(u => u.IdSystem == IdSistema).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UserFinancialSystem> ObterUsuarioPorEmail(string emailUsuario)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UserFinancialSystems.AsNoTracking().FirstOrDefaultAsync(u => u.EmailUser.Equals(emailUsuario));
            }
        }

        public async Task RemoverUsuarios(List<UserFinancialSystem> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
