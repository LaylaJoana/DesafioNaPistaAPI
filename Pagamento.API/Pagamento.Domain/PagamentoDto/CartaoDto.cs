using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Pagamento.Domain.PagamentoDto
{
    public class CartaoDto
    {
        [Required]
        public string Titular { get; set; }

        [Required]
        public string Numero { get; set; }
   
        public string DataExpiracao { get; set; }
  
        public string Bandeira { get; set; }

        public string Cvv { get; set; }
    }
}
