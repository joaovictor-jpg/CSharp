using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AlterarSenhaModel alterarSenha)
        {
            try
            {
                var usuariLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Id = usuariLogado.Id;
                if(ModelState.IsValid)
                {
                    await _usuarioRepositorio.AlterarSenha(alterarSenha);
                    TempData["MessagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }
                return View("Index", alterarSenha);
            }
            catch (Exception ex)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente, detalhe de erro: {ex.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
