using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Core.Models;

namespace Pedidos.Infra.Data.Mappings
{
    internal class ItensPedidoMap : IEntityTypeConfiguration<ItensPedido>
    {
        public void Configure(EntityTypeBuilder<ItensPedido> builder)
        {
            builder.ToTable("ItensPedido");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("itempedidoid");

            builder.Property(e => e.IdPedido)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("pedidoid")
            .HasColumnType("uniqueidentifier").IsRequired(true);

            builder.Property(e => e.IdProduto)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("produtoid")
            .HasColumnType("uniqueidentifier").IsRequired(true);

            builder.Property(e => e.Quantidade)
            .HasColumnName("quantidade")
            .HasColumnType("numeric(14)").IsRequired(true);

            builder.HasOne(e => e.Pedido)
            .WithMany(m => m.ItensPedido)
            .HasForeignKey(e => e.IdPedido)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Produto)
            .WithMany(p => p.ItensPedido)
            .HasForeignKey(f => f.IdProduto)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(e => e.ValorUnitario);
            builder.Ignore(e => e.NomeProduto);
        }
    }
}
