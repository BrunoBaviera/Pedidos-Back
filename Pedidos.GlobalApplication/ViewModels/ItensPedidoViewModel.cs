namespace Pedidos.GlobalApplication.ViewModels
{
    public class ItensPedidoViewModel : BaseViewModel
    {
        public Guid IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public decimal? ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public ProdutoViewModel? Produto { get; set; }

    }
}
