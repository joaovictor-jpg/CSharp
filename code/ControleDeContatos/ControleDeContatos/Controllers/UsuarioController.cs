using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Contato;
using ControleDeContatos.Repository.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdimin]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly IContatoRepositorio _contatoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            List<UsuarioModel> usuario = await _usuarioRepositorio.ListarContato();
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioModel usuarioModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var usuario = await _usuarioRepositorio.Adcionar(usuarioModel);
                    TempData["MessagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuarioModel);
            }
            catch(Exception ex)
            {
                TempData["MessagemErro"] = $"Ops, não consiguimos cadastrar usuário, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ApagarConfirmacao(int id)
        {
            var usuario = await _usuarioRepositorio.ListaPorId(id);
            return View(usuario);
        }

        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _usuarioRepositorio.Apagar(id);
                if (apagado) TempData["MessagemSucesso"] = "Usuario apagado com sucesso!"; else TempData["MessagemErro"] = "Ops, não conseguimos apagar Usuario";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos apagar seu usuario, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioRepositorio.ListaPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioDTO usuarioDTO)
        {
            try
            {
                UsuarioModel usuario = null;
                if(ModelState.IsValid)
                {

                    usuario = new UsuarioModel()
                    {
                        Id = usuarioDTO.Id,
                        Nome = usuarioDTO.Nome,
                        Login = usuarioDTO.Login,
                        Email = usuarioDTO.Email,
                        Perfil = (Models.Enum.PerfilEnum)usuarioDTO.Perfil
                    };

                    usuario = await _usuarioRepositorio.Alterar(usuario);
                    TempData["MessagemSucesso"] = "Usuario atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch(Exception erro)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos atualizar contato seu usuário, tente novamente, detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ListarContatosPorUsuarioId(int id)
        {
            List<ContatoModel> contatos = await _contatoRepositorio.ListarContato(id);
            return PartialView("_ContatosUsuario", contatos);
        }
    }
}
