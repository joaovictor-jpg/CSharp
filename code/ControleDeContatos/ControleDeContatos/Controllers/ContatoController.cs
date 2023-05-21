using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Contato;
using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Helper;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _repositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio repositorio, ISessao session)
        {
            _repositorio = repositorio;
            _sessao = session;

        }

        public async Task<IActionResult> Index()
        {
            var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var contatos = await _repositorio.ListarContato(usuarioLogado.Id);

            return View(contatos);
        }

        public IActionResult Criar() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ContatoModel contatoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel idUsuario = _sessao.BuscarSessaoDoUsuario();
                    contatoModel.UsuarioId = idUsuario.Id;

                    await _repositorio.Adcionar(contatoModel);
                    TempData["MessagemSucesso"] = "Contato salvo com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contatoModel);
            }
            catch(Exception erro)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Editar(int id)
        {
            var contato = await _repositorio.ListaPorId(id);
            return View(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    var contatoModel = await _repositorio.Alterar(contato);
                    TempData["MessagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ApagarConfirmacao(int id) {
            var contato = await _repositorio.ListaPorId(id);
            return View(contato);
        }

        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _repositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MessagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MessagemErro"] = "Ops, não conseguimos apagar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MessagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
