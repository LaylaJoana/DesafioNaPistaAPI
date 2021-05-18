using Newtonsoft.Json;
using System;

namespace Domain.Dtos
{
    public  class ProdutoDetailsDto
    {
     
        public int Id { get; set; }
        public string Nome { get; set; }
 
        public double ValorUnitario { get; set; }

        public int QtdeEstoque { get; set; }

        public DateTime? DataUltimaVenda { get; set; }

        public double ValorUltimaVenda { get; set; }
    }
}
