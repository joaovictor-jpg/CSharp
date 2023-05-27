using IntegraBrasil.DTOs;
using IntegraBrasil.Model;
using System.Dynamic;
using System.Text.Json;

namespace IntegraBrasil.Repository.BrasilApi
{
    public class BrasilApiRest : IBrasilApi
    {
        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var response = new ResponseGenerico<EnderecoModel>();

            using(var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse  = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if(responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

                return response;
            }
        }
        public Task<ResponseGenerico<List<BancoModel>>> BuscarTodosOsBancos()
        {
            throw new NotImplementedException();
        }
        public Task<ResponseGenerico<BancoModel>> BuscarBancoPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
