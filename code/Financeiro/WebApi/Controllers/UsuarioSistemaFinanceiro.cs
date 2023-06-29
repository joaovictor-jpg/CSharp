using Domain.Interfaces.InterfaceService;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiro : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _usuarioSistemaFinanceiroService;

        public UsuarioSistemaFinanceiro(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroService usuarioSistemaFinanceiroService)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroService = usuarioSistemaFinanceiroService;
        }

        [HttpGet("/api/ListarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarioSistema(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroService.CadastrarUsuarioSistemaFinanceiro(
                        new UserFinancialSystem
                        {
                            IdSystem = idSistema,
                            EmailUser = emailUsuario,
                            Administrator = false,
                            SystemCurrent = true,
                        }
                    );
            }
            catch( Exception ex )
            {
                return Task.FromException( ex );
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinaceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);
                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinaceiro);
            }
            catch (Exception ex )
            {
                return Task.FromException(ex);
            }

            return Task.FromResult(true);
        }
    }
}
