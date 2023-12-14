using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Controllers;
using Pedidos.Core.Interfaces;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Interfaces.Services;
using Pedidos.Core.Models;
using Pedidos.GlobalApplication.QueryModel;
using Pedidos.GlobalApplication.ViewModels;
using Pedidos.Shared.Utils;

namespace Pedidos.Global.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : MainController
    {
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pPedidoService, IPedidoRepository pPedidoRepository, IMapper pMapper, INotifier pNotificador) : base(pNotificador)
        {
            _pedidoService = pPedidoService;
            _pedidoRepository = pPedidoRepository;
            _mapper = pMapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPaginacao([FromQuery] PaginateQuery paginateQuery)
        {
            var lList = _mapper.Map<PagedList<PedidoViewModel>>(await _pedidoRepository.ObterTodos(paginateQuery.NumeroPagina, paginateQuery.TamanhoPagina));
            return CustomResponse(lList);
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var lList = _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.ObterTodos());
            return CustomResponse(lList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoViewModel>> ObterPorId(Guid id)
        {
            var pedidoViewModel = await ObterPedido(id);

            if (pedidoViewModel == null) return NotFound();

            return pedidoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoViewModel>> Adicionar([FromBody] PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedidoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != pedidoViewModel.Id)
            {
                NotifyError("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var pedido = await ObterPedido(id);

            if (pedido == null) return NotFound();



            await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedidoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var pedido = await ObterPedido(id);

            if (pedido == null) return NotFound();

            await _pedidoService.Remover(id);

            return CustomResponse();
        }

        private async Task<PedidoViewModel> ObterPedido(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedido(id));
        }

    }
}
