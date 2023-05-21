using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repository.Contato
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _banco;

        public ContatoRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public async Task<List<ContatoModel>> ListarContato(int usuarioId)
        {
            return await _banco.Contato.Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<ContatoModel> Adcionar(ContatoModel contato)
        {
            await _banco.Contato.AddAsync(contato);
            await _banco.SaveChangesAsync();

            return contato;
        }

        public async Task<ContatoModel> ListaPorId(int id)
        {
            return await _banco.Contato.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContatoModel> Alterar(ContatoModel contato)
        {
            var contatoDB = await ListaPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _banco.Contato.Update(contatoDB);
            _banco.SaveChanges();

            return contatoDB;
        }

        public async Task<bool> Apagar(int id)
        {
            var contatoDB = await ListaPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

            _banco.Contato.Remove(contatoDB);
            await _banco.SaveChangesAsync();

            return true;
        }
    }
}
