using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Interfaces.Services;
using Pedidos.Core.Models;

namespace Pedidos.Core.Services
{
    public class PedidoService: IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task Adicionar(Pedido pedido)
        {
            //if (!ExecutarValidacao(new PedidoValidation(), pedido)) return;

            pedido.SetDataCricao();

            pedido.ItensPedido.ForEach(f => f.LimparProdutos());

            await _pedidoRepository.Adicionar(pedido);
        }

        public async Task Atualizar(Pedido pedido)
        {
            pedido.LimparItensPedidos();
            await _pedidoRepository.Atualizar(pedido);
        }

        public async Task Remover(Guid id)
        {
            await _pedidoRepository.Remover(id);
        }
    }
}
