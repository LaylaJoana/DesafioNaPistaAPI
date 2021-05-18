using Domain.Entitys;
using Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendaRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Venda> Salvar(Venda venda)
        {
            return await _unitOfWork.Add(venda);
        }
    }
}
