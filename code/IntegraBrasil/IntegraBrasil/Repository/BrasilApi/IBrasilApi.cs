using IntegraBrasil.DTOs;
using IntegraBrasil.Model;

namespace IntegraBrasil.Repository.BrasilApi
{
    public interface IBrasilApi
    {
        Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep);
        Task<ResponseGenerico<List<BancoModel>>> BuscarTodosOsBancos();
        Task<ResponseGenerico<BancoModel>> BuscarBancoPorCodigo(string codigo);
    }
}
