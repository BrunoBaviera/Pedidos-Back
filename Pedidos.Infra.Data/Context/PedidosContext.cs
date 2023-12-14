using Microsoft.EntityFrameworkCore;
using Pedidos.Core.Models;
using Pedidos.Infra.Data.Mappings;

namespace Pedidos.Infra.Data.Context
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions<PedidosContext> options) : base(options)
        {
            //.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
