using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfiguration
{
    public class VendaModelConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("venda");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IdProduto).HasColumnName("id_produto");

            builder.Property(e => e.QtdeComprada).HasColumnName("qtde_comprada");

            builder.Property(e => e.ValorVenda).HasColumnName("valor_venda");

            builder.Property(e => e.DataVenda).HasColumnName("data_venda");

            builder.HasOne(d => d.Produto)
               .WithMany(p => p.Venda)
               .HasForeignKey(d => d.IdProduto)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("fk_venda_produto");
        }
    }
}
