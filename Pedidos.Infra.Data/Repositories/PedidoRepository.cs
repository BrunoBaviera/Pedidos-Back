using Microsoft.EntityFrameworkCore;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Models;
using Pedidos.Infra.Data.Context;
using Pedidos.Infra.Data.Extensions;
using Pedidos.Shared.Utils;

namespace Pedidos.Infra.Data.Repositories
{
    public class PedidoRepository: BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(PedidosContext context)
           : base(context)
        { }

        public override async Task<PagedList<Pedido>> ObterTodos(int numeroPagina, int tamanhoPagina)
        {
            var queryable = DbSet.AsNoTracking();

            queryable = queryable.Include(p => p.ItensPedido).ThenInclude(p => p.Produto);

            queryable = queryable.Select(p => new Pedido(
                p.Id,
                p.NomeCliente,
                p.EmailCliente,
                p.DataCriacao,
                p.Pago,
                p.ItensPedido.Sum(s => s.Quantidade * s.Produto.Valor),
                p.ItensPedido.Select(s => new ItensPedido(s.Id, s.IdProduto, s.Quantidade, s.Produto.NomeProduto, s.Produto.Valor)).ToList()));

            return await queryable.PaginateAsync(numeroPagina, tamanhoPagina);
        }

        public override async Task<List<Pedido>> ObterTodos()
        {
            var queryable = DbSet.AsNoTracking();

            queryable = queryable.Include(p => p.ItensPedido).ThenInclude(p => p.Produto);

            queryable = queryable.Select(p => new Pedido(
                p.Id,
                p.NomeCliente,
                p.EmailCliente,
                p.DataCriacao,
                p.Pago,
                p.ItensPedido.Sum(s => s.Quantidade * s.Produto.Valor),
                p.ItensPedido.Select(s => new ItensPedido(s.Id, s.IdProduto, s.Quantidade, s.Produto.NomeProduto, s.Produto.Valor)).ToList()));

            return await queryable.ToListAsync();
        }

        public async Task<Pedido> ObterPedido(Guid id)
        {
            return await DbSet.AsNoTracking().Include(f => f.ItensPedido).ThenInclude(p => p.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
