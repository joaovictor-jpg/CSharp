using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repository.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _banco;

        public UsuarioRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public async Task<List<UsuarioModel>> ListarContato()
        {
            return await _banco.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            await _banco.Usuario.AddAsync(usuario);
            await _banco.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> ListaPorId(int id)
        {
            return await _banco.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> BuscarPorLogin(string login)
        {
            return await _banco.Usuario.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<UsuarioModel> BuscarPorEmailELogin(string email, string login)
        {
            return await _banco.Usuario.FirstOrDefaultAsync(x => x.Email == email && x.Login == login);
        }

        public async Task<UsuarioModel> Alterar(UsuarioModel usuario)
        {
            var usuarioDB = await ListaPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _banco.Usuario.Update(usuarioDB);
            _banco.SaveChanges();

            return usuarioDB;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioDB = await ListaPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do usuário!");

            _banco.Usuario.Remove(usuarioDB);
            await _banco.SaveChangesAsync();

            return true;
        }
    }
}
