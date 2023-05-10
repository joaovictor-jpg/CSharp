using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Contato
{
    public interface IContatoRepositorio
    {

        Task<List<ContatoModel>> ListarContato();

        Task<ContatoModel> Adcionar(ContatoModel contato);
    }
}
