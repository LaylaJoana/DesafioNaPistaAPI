using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> Salvar(ProdutoDto produto);
        Task<IEnumerable<ProdutoDto>> BuscarTodos();
        Task<ProdutoDetailsDto> Buscar(int id);
        Task Delete(int id);
    }
}
