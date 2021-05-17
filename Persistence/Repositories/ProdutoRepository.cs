using Domain.Entitys;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Produto> Salvar(Produto produto)
        {
            return await _unitOfWork.Add(produto);
        }

        public async Task<IQueryable<Produto>> BuscarTodos()
        {
            return await _unitOfWork.FindAll<Produto>(a => a.QtdeEstoque >= 0);
        }

        public async Task<Produto> Buscar(int id)
        {
            return await Task.FromResult(_unitOfWork.DbSet<Produto>()
                 .Include(p => p.Venda)
                 .FirstOrDefault(a => a.Id == id));
        }

        public async Task<Produto> BuscarSingle(int id)
        {
            return await _unitOfWork.FindById<Produto>(id);
        }

        public async Task Atualizar(Produto produto)
        {
            await _unitOfWork.Update(produto);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Delete<Produto>(id);
        }
    }
}
