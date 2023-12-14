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
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository pProdutoRepository, IProdutoService pProdutoService, IMapper pMapper, INotifier pNotificador) : base(pNotificador)
        {
            _produtoRepository = pProdutoRepository;
            _produtoService = pProdutoService;
            _mapper = pMapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPaginacao([FromQuery] PaginateQuery paginateQuery)
        {
            var lList = _mapper.Map<PagedList<ProdutoViewModel>>(await _produtoRepository.ObterTodos(paginateQuery.NumeroPagina, paginateQuery.TamanhoPagina));
            return CustomResponse(lList);
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var lList = _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return CustomResponse(lList);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != produtoViewModel.Id)
            {
                NotifyError("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var pedido = await ObterProduto(id);

            if (pedido == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse();
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProduto(id));
        }

    }
}
