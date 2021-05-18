using Pagamento.Domain.PagamentoDto;
using Pagamento.Domain.PagamentoDtos;
using System.Threading.Tasks;

namespace Pagamento.Domain.Interfaces
{
    public interface IPagamentoService
    {
        Task<PagamentoResponseDto> AutorizarPagamento(PagamentoRequestDto pagamento);
    }
}
