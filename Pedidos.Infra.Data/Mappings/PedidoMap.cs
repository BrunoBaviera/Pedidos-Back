using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Core.Models;

namespace Pedidos.Infra.Data.Mappings
{
    internal class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("pedidoid");

            builder.Property(e => e.NomeCliente)
            .HasColumnName("nomeCliente")
            .HasColumnType("varchar(60)").IsRequired(true);

            builder.Property(e => e.NomeCliente)
            .HasColumnName("nomeCliente")
            .HasColumnType("varchar(60)").IsRequired(true);

            builder.Property(e => e.DataCriacao)
            .HasColumnName("datacriacao")
            .HasColumnType("datetime").IsRequired(true);

            builder.Property(e => e.Pago)
            .HasColumnName("pago")
            .HasColumnType("bit").IsRequired(true);

            builder.Ignore(e => e.ValorTotal);

            var navigationItensPedido = builder.Metadata.FindNavigation(nameof(Pedido.ItensPedido));
            navigationItensPedido.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
