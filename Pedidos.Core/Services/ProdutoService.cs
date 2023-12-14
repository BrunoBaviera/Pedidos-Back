using Pedidos.Core.Interfaces;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Interfaces.Services;
using Pedidos.Core.Models;

namespace Pedidos.Core.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        public ProdutoService(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, INotifier notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            if (_pedidoRepository.Buscar(p => p.ItensPedido.Any(s => s.IdProduto == id)).Result.Any())
            {
                Notificar("Já existem pedidos com o produto informado.");
                return;
            }

            await _produtoRepository.Remover(id);
        }
    }
}
