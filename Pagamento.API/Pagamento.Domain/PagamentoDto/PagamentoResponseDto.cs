using Newtonsoft.Json;

namespace Pagamento.Domain.PagamentoDtos
{
    public class PagamentoResponseDto
    {
        [JsonProperty(PropertyName = "valor")]
        public double Valor { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; set; }
    }
}
