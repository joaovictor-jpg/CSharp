using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Usuario
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsuarioModel>> ListarContato();

        Task<UsuarioModel> ListaPorId(int id);

        Task<UsuarioModel> Adcionar(UsuarioModel contato);

        Task<UsuarioModel> Alterar(UsuarioModel contato);

        Task<bool> Apagar(int id);
    }
}
