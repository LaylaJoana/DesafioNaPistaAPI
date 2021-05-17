using Domain.Entitys;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> Salvar(Produto produto);
        Task<IQueryable<Produto>> BuscarTodos();
        Task<Produto> Buscar(int id);
        Task<Produto> BuscarSingle(int id);        
        Task Delete(int id);
        Task Atualizar(Produto produto);
    }
}
