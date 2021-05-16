using Domain.Entities;
using System;

namespace Domain.Entitys
{
    public class Venda : BaseEntity
    {
        public int IdProduto { get; set; }
        public int QtdeComprada { get; set; }
        public double ValorVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
