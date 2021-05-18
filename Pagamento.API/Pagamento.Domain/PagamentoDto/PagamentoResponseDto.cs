using Newtonsoft.Json;

namespace Pagamento.Domain.PagamentoDtos
{
    public class PagamentoResponseDto
    {
        
        public double Valor { get; set; }
        public string Estado { get; set; }
    }
}
