using AutoMapper;
using IntegraBrasil.DTOs;
using IntegraBrasil.Model;
using IntegraBrasil.Repository.BrasilApi;

namespace IntegraBrasil.Repository.Banco
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public BancoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos()
        {
            var banco = await _brasilApi.BuscarTodosOsBancos();
            return _mapper.Map<ResponseGenerico<List<BancoResponse>>>(banco);
        }
        public async Task<ResponseGenerico<BancoResponse>> BuscarBanco(string codigo)
        {
            var banco = await _brasilApi.BuscarBancoPorCodigo(codigo);
            return _mapper.Map<ResponseGenerico<BancoResponse>>(banco);
        }

    }
}
