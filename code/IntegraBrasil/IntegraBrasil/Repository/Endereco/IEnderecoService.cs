using IntegraBrasil.DTOs;
using IntegraBrasil.Model;

namespace IntegraBrasil.Repository.Endereco
{
    public interface IEnderecoService
    {
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);
    }
}
