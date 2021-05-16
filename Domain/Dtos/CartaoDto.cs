using Newtonsoft.Json;

namespace Domain.Dtos
{
    public class CartaoDto
    {
        [JsonProperty("titular")]
        public string Titular { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("data_expiracao")]
        public string DataExpiracao { get; set; }

        [JsonProperty("bandeira")]
        public string Bandeira { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }
    }
}

