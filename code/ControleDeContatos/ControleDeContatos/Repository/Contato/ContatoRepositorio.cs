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

        public async Task<List<ContatoModel>> ListarContato()
        {
            return await _banco.Contato.ToListAsync();
        }

        public async Task<ContatoModel> Adcionar(ContatoModel contato)
        {
            await _banco.Contato.AddAsync(contato);
            await _banco.SaveChangesAsync();

            return contato;
        }

    }
}
