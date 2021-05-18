using Newtonsoft.Json;

namespace Pagamento.Domain.PagamentoDto
{
    public class PagamentoRequestDto
    {
        [JsonProperty(PropertyName = "valor")]
        public double Valor { get; set; }

        [JsonProperty(PropertyName = "cartao")]
        public CartaoDto Cartao { get; set; }
    }
}
