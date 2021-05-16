using Domain.Entitys;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> Salvar(Venda venda);
    }
}
