using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Core.Models;

namespace Pedidos.Infra.Data.Mappings
{
    internal class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("produtoid");

            builder.Property(e => e.NomeProduto)
            .HasColumnName("nomeProduto")
            .HasColumnType("varchar(20)").IsRequired(true);


            builder.Property(e => e.Valor)
            .HasColumnName("valor")
            .HasColumnType("numeric(10, 2)").IsRequired(true);            
        }
    }
}
