using Domain.Dtos;
using Domain.Entitys;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra.CrossCutting.GatewayPagamento;
using Infra.CrossCutting.Pagamento;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _repositoryProduto;
        private readonly IConfiguration _configuration;

        public VendaService(IVendaRepository repository, IProdutoRepository repositoryProduto, IConfiguration configuration)
        {
            _repository = repository;
            _repositoryProduto = repositoryProduto;
            _configuration = configuration;
        }

        public async Task<VendaDto> Salvar(VendaDto vendaDto)
        {
            if (!Util.ValidarNumeroCartao(vendaDto.Cartao.Numero))
            {
                throw new Exception();
            }

            var produto = await _repositoryProduto.BuscarSingle(vendaDto.ProdutoId);

            if (!ValidarEstoque(produto, vendaDto.QtdeComprada))
            {
                throw new Exception();
            }

            var valorCompra = vendaDto.QtdeComprada * produto.ValorUnitario;
            await AutorizarPagamento(vendaDto.Cartao, valorCompra);

            var venda = new Venda
            {
                DataVenda = DateTime.Now,
                IdProduto = vendaDto.ProdutoId,
                QtdeComprada = vendaDto.QtdeComprada,
                ValorVenda = produto.ValorUnitario,
            };

            await _repository.Salvar(venda);
            BaixarEstoque(produto, vendaDto.QtdeComprada);

            vendaDto.Id = venda.Id;

            return vendaDto;
        }

        private async void BaixarEstoque(Produto produto, int qtdeComprada)
        {
            produto.QtdeEstoque -= qtdeComprada;
            await _repositoryProduto.Atualizar(produto);
        }

        private bool ValidarEstoque(Produto produto, int qtdeComprada)
        {
            if (produto == null || produto.QtdeEstoque < qtdeComprada)
            {
                return false;
            }

            return true;
        }

        private async Task AutorizarPagamento(CartaoDto cartaoDto, double valor)
        {
            var pagamentoSem = new PagamentoRequestDto
            {
                Cartao = cartaoDto,
                Valor = valor
            };
            var gatewayPagamento = new GatewayPagamento(_configuration);
            var autorizarPagamento = await gatewayPagamento.AutorizarPagamento(pagamentoSem);

            if (autorizarPagamento == null || !autorizarPagamento.Estado.Equals("APROVADO"))
            {
                throw new Exception();
            }
        }
    }
}
