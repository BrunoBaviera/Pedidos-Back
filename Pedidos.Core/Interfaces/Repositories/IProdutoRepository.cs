using Pedidos.Core.Models;

namespace Pedidos.Core.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto> ObterProduto(Guid id);
    }
}
