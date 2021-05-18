using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
    /// <summary>
    /// Controladora das Requisições da Compra.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="vendaservice"></param>
        public CompraController(IVendaService vendaservice)
        {
            _vendaService = vendaservice;
        }

        /// <summary>
        /// Cria Uma Venda e Salva.
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Salvar(VendaDto venda)
        {
            try
            {
                var Venda = await _vendaService.Salvar(venda);
                return Ok("Venda Realizada Com Sucesso");
            }
            catch
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }
    }

}
