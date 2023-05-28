using IntegraBrasil.DTOs;
using IntegraBrasil.Model;

namespace IntegraBrasil.Repository.Banco
{
    public interface IBancoService
    {
        Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos();
        Task<ResponseGenerico<BancoResponse>> BuscarBanco(string codigo);
    }
}
