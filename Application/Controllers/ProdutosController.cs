using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Application.Controllers
{
    /// <summary>
    /// Controladora das Requisições do Produto.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="produtoservice"></param>
        public ProdutosController(IProdutoService produtoservice)
        {
            _produtoService = produtoservice;
        }

        /// <summary>
        ///  Salva um Produto na Base de Dados.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Salvar(ProdutoDto produto)
        {
            try
            {
                var Produto = await _produtoService.Salvar(produto);
                return Ok("Produto Cadastrado");
            }
            catch
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }

        /// <summary>
        /// Lista todos os produtos cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> BuscarTodos()
        {
            try
            {
                var produtos = await _produtoService.BuscarTodos();
                return new JsonResult(produtos.ToList());
            }
            catch
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }

        /// <summary>
        /// Retorna um Produto Detalhado pelo seu id (Identificador).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDetailsDto>> Buscar(int id)
        {
            try
            {
                var Produto = await _produtoService.Buscar(id);
                return new JsonResult(Produto);
            }
            catch(System.Exception ex)
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }

        /// <summary>
        /// Remove um Produto Passando o seu id(Identificador).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoService.Delete(id);
                return Ok("Produto excluído com sucesso.");
            }
            catch
            {
                return BadRequest("Ocorreu um erro desconhecido.");
            }
        }

    }
}
