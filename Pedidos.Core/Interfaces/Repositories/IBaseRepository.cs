using Pedidos.Core.Models;
using Pedidos.Shared.Utils;
using System.Linq.Expressions;

namespace Pedidos.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<PagedList<TEntity>> ObterTodos(int numeroPagina, int tamanhoPagina);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
