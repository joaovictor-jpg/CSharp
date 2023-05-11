using ControleDeContatos.Models;
using ControleDeContatos.Repository.Contato;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _repositorio;

        public ContatoController(IContatoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IActionResult> Index()
        {

            var contatos = await _repositorio.ListarContato();

            return View(contatos);
        }

        public IActionResult Criar() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ContatoModel contatoModel)
        {
            await _repositorio.Adcionar(contatoModel);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Editar(int id)
        {
            var contato = await _repositorio.ListaPorId(id);
            return View(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ContatoModel contato)
        {
            var contatoModel = await _repositorio.Alterar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao() {
            return View();
        }
    }
}
