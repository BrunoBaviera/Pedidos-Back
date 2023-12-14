using Pedidos.Core.Models;

namespace Pedidos.Core.Interfaces.Services
{
    public interface IPedidoService
    {
        Task Adicionar(Pedido pedido);
        Task Atualizar(Pedido pedido);
        Task Remover(Guid id);
    }
}
