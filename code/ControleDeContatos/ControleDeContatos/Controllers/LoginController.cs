﻿using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {

        public readonly IUsuarioRepositorio _usuarioRepositorio;
        public readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {

            // Se usuário estiver logado, redireciona para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoDoUsuario(usuarioDB);
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