using System.Dynamic;
using System.Net;

namespace IntegraBrasil.DTOs
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public T? DadosRetorn { get; set; }
        public ExpandoObject? ErroRetorno { get; set; }
    }
}
