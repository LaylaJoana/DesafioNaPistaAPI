using Newtonsoft.Json;

namespace Domain.Dtos
{
    public class PagamentoDto
    {
        [JsonProperty("valor")]  
        public double Valor { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }
    }
}
