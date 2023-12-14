using Microsoft.EntityFrameworkCore;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Models;
using Pedidos.Infra.Data.Context;
using Pedidos.Infra.Data.Extensions;
using Pedidos.Shared.Utils;
using System.Linq.Expressions;

namespace Pedidos.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
    {
        protected readonly PedidosContext Db;
        protected readonly DbSet<T> DbSet;
        protected BaseRepository(PedidosContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<T?> ObterPorId(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<PagedList<T>> ObterTodos(int numeroPagina, int tamanhoPagina)
        {
            var queryable = DbSet.AsNoTracking();

            return await queryable.PaginateAsync(numeroPagina, tamanhoPagina);
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            var queryable = DbSet.AsNoTracking();

            return await queryable.ToListAsync();
        }

        public virtual async Task Adicionar(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
