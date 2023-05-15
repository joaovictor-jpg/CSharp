using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Usuario
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsuarioModel>> ListarContato();

        Task<UsuarioModel> ListaPorId(int id);

        Task<UsuarioModel> Adcionar(UsuarioModel usuario);

        Task<UsuarioModel> Alterar(UsuarioModel usuario);

        Task<bool> Apagar(int id);
    }
}
