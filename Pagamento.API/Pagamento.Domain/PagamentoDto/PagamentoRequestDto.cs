using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Pagamento.Domain.PagamentoDto
{
    public class PagamentoRequestDto
    {
        [Required]
        public double Valor { get; set; }

        [Required]
        public CartaoDto Cartao { get; set; }
    }
}
