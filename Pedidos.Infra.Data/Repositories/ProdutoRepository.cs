using Microsoft.EntityFrameworkCore;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Models;
using Pedidos.Infra.Data.Context;

namespace Pedidos.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PedidosContext context)
           : base(context)
        {

        }

        public async Task<Produto> ObterProduto(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
