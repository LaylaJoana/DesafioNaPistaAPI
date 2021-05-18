using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfiguration
{
    public class ProdutoModelConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Nome)
               .HasColumnName("nome")
               .HasColumnType("varchar")
               .HasMaxLength(100);

            builder.Property(e => e.ValorUnitario)
                .HasColumnName("valor_unitario");

            builder.Property(e => e.QtdeEstoque)
                .HasColumnName("qtde_estoque");

        }
    }
}
