using ControleDeContatos.Models;
using ControleDeContatos.Repository.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {

        public readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuarioDB = await _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuarioDB != null)
                    {
                        if(usuarioDB.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MessagemErro"] = "Senha inválida. Por favo, tente novamente";
                    }
                    TempData["MessagemErro"] = "Usuário e/ou senha inválida(s). Por favor, tente novamente";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
