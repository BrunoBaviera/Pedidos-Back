using AutoMapper;
using Pedidos.Core.Models;
using Pedidos.GlobalApplication.ViewModels;
using Pedidos.Shared.Utils;

namespace Pedidos.GlobalApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<PagedList<Pedido>, PagedList<PedidoViewModel>>();

            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<PagedList<Produto>, PagedList<ProdutoViewModel>>();

            CreateMap<ItensPedido, ItensPedidoViewModel>().ReverseMap();
            CreateMap<PagedList<ItensPedido>, PagedList<ItensPedidoViewModel>>();
        }
    }
}
