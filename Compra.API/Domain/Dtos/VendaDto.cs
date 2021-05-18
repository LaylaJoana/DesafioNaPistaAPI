using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class VendaDto
    {
      
        public int? Id { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Range(0, int.MaxValue)]
        public int QtdeComprada { get; set; }
        [Required]
        public CartaoDto Cartao { get; set; }
    }
}
