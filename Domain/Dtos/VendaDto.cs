using Newtonsoft.Json;

namespace Domain.Dtos
{
    public class VendaDto
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("produto_id")]
        public int ProdutoId { get; set; }

        [JsonProperty("qtde_comprada")]
        public int QtdeComprada { get; set; }

        [JsonProperty("cartao")]
        public CartaoDto Cartao { get; set; }
    }
}
