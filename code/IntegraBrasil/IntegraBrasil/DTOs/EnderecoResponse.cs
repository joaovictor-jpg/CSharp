using System.Text.Json.Serialization;

namespace IntegraBrasil.DTOs
{
    public class EnderecoResponse
    {
        public string? Cep { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public int? Regiao { get; set; }
        public string? Rua { get; set; }
        [JsonIgnore]
        public string? Service { get; set; }
    }
}
