using Domain.Dtos;
using Domain.Entitys;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Service.Servicies
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoService repository)
        {
            _repository = (IProdutoRepository)repository;
        }

        public async Task<ProdutoDto> Salvar(ProdutoDto produtoDto)
        {
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                ValorUnitario = produtoDto.ValorUnitario,
                QtdeEstoque = produtoDto.QtdeEstoque,
            };
            await _repository.Salvar(produto);
            produtoDto.Id = produto.Id;

            return produtoDto;
        }
    
        public async Task<ProdutoDetailsDto> Buscar(int id)
        {
            var produto = await _repository.Buscar(id);

            if (produto == null)
                throw new NullReferenceException();

            Venda ultimaVenda = produto.Venda.FirstOrDefault();

            var produtoDetails = new ProdutoDetailsDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                ValorUnitario = produto.ValorUnitario,
                QtdeEstoque = produto.QtdeEstoque
            };

            if (ultimaVenda != null)
            {
                produtoDetails.DataUltimaVenda = ultimaVenda.DataVenda;
                produtoDetails.ValorUltimaVenda = ultimaVenda.ValorVenda;
            }

            return produtoDetails;
        }

        public async Task<IEnumerable<ProdutoDto>> BuscarTodos()
        {
            var produtos = await _repository.BuscarTodos();
            var ProdutosDto = new List<ProdutoDto>();

            foreach (var produto in produtos)
            {
                var produtoDto = new ProdutoDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    ValorUnitario = produto.ValorUnitario,
                    QtdeEstoque = produto.QtdeEstoque
                };
                ProdutosDto.Add(produtoDto);
            }

            return ProdutosDto;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
