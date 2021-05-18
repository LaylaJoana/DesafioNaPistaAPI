using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ProdutoDto
    {

        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public double ValorUnitario { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int QtdeEstoque { get; set; }

    }
}
