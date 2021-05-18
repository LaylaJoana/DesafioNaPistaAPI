using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entitys
{
    public class Produto : BaseEntity
    {
        public Produto()
        {
            Venda = new List<Venda>();
        }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int QtdeEstoque { get; set; }
        public virtual List<Venda> Venda { get; set; }
    }
}
