using Domain.Dtos;
using Domain.Entitys;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra.CrossCutting.Pagamento;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _repositoryProduto;
        public VendaService(IVendaRepository repository, IProdutoRepository repositoryProduto)
        {
            _repository = repository;
            _repositoryProduto = repositoryProduto;
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

            //await Autorizar Pagamento

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
    }
}
