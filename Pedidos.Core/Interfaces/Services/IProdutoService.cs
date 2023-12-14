using Pedidos.Core.Models;

namespace Pedidos.Core.Interfaces.Services
{
    public interface IProdutoService
    {
        Task Adicionar(Produto pedido);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
