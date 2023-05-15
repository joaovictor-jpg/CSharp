﻿using ControleDeContatos.Models;
using ControleDeContatos.Repository.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
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
    }
}
