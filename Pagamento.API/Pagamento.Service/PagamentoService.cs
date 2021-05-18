using Pagamento.Domain.Interfaces;
using Pagamento.Domain.PagamentoDto;
using Pagamento.Domain.PagamentoDtos;
using System.Threading.Tasks;

namespace Pagamento.Service
{
    public class PagamentoService : IPagamentoService
    {
        public async Task<PagamentoResponseDto> AutorizarPagamento(PagamentoRequestDto pagamentorequestDto)
        {
            var pagamentoresponse = new PagamentoResponseDto
            {
                Valor = pagamentorequestDto.Valor,
                Estado = pagamentorequestDto.Valor > 100 ? "APROVADO" : "REJEITADO"
            };
            return pagamentoresponse;
        }
    }
}
