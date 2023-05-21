using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Contato
{
    public interface IContatoRepositorio
    {

        Task<List<ContatoModel>> ListarContato(int usuarioId);

        Task<ContatoModel> ListaPorId(int id);

        Task<ContatoModel> Adcionar(ContatoModel contato);

        Task<ContatoModel> Alterar(ContatoModel contato);

        Task<bool> Apagar(int id);
    }
}
