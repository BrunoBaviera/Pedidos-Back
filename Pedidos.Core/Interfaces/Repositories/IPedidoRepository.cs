using Pedidos.Core.Models;

namespace Pedidos.Core.Interfaces.Repositories
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<Pedido> ObterPedido(Guid id);
    }
}
