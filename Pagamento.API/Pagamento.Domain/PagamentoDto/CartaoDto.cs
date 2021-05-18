using Newtonsoft.Json;

namespace Pagamento.Domain.PagamentoDto
{
    public class CartaoDto
    {
        [JsonProperty(PropertyName = "titular")]
        public string Titular { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "data_expiracao")]
        public string DataExpiracao { get; set; }

        [JsonProperty(PropertyName = "bandeira")]
        public string Bandeira { get; set; }

        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }
    }
}
