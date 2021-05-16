using Newtonsoft.Json;

namespace Domain.Dtos
{
    public class ProdutoDto
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor_unitario")]
        public double ValorUnitario { get; set; }

        [JsonProperty("qtde_estoque")]
        public int QtdeEstoque { get; set; }

    }
}
