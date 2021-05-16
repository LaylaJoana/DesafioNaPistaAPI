using Newtonsoft.Json;
using System;

namespace Domain.Dtos
{
    public  class ProdutoDetailsDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor_unitario")]
        public double ValorUnitario { get; set; }

        [JsonProperty("qtde_estoque")]
        public int QtdeEstoque { get; set; }

        [JsonProperty("data_ultima_venda")]
        public DateTime DataUltimaVenda { get; set; }

        [JsonProperty("valor_ultima_venda")]
        public double ValorUltimaVenda { get; set; }
    }
}
