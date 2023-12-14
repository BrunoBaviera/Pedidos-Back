using Microsoft.EntityFrameworkCore;
using Pedidos.Shared.Utils;

namespace Pedidos.Infra.Data.Extensions
{
    public static class PagedListExtension
    {
        public static async Task<PagedList<T>> PaginateAsync<T>(this IQueryable<T> query, int numeroPagina, int tamanhoPagina) where T : class
        {
            numeroPagina = (numeroPagina <= 0) ? 1 : numeroPagina + 1;
            var pagedList = new PagedList<T>
            {
                PaginaAtual = numeroPagina,
                TamanhoPagina = tamanhoPagina
            };

            var startPage = (numeroPagina - 1) * tamanhoPagina;
            pagedList.Itens = await query
                                .Skip(startPage)
                                .Take(tamanhoPagina).ToListAsync();

            pagedList.TotalRegistros = query.Count();

            return pagedList;
        }
    }
}
