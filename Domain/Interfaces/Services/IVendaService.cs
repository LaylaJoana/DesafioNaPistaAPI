using Domain.Dtos;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IVendaService
    {
        Task<VendaDto> Salvar(VendaDto venda);
    }
}
