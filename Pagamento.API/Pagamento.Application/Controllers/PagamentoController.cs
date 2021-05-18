using Microsoft.AspNetCore.Mvc;
using Pagamento.Domain.Interfaces;
using Pagamento.Domain.PagamentoDto;
using System.Threading.Tasks;

namespace Pagamento.Application.Controllers
{
    /// <summary>
    /// Controladora de Pagamentos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        /// <summary>
        /// Autorizar um Pagamento.
        /// </summary>
        /// <param name="pagamentoRequest"></param>
        /// <returns></returns>
        [HttpPost("compras")]
        public async Task<ActionResult> AutorizarPagamento(PagamentoRequestDto pagamentoRequest)
        {
            try
            {
                var pagamentoResponse = await _pagamentoService.AutorizarPagamento(pagamentoRequest);
                return Ok(pagamentoResponse);
            }
            catch
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }
    }
}
