namespace Pedidos.GlobalApplication.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get;  set; }
        public decimal? ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItensPedidoViewModel>? ItensPedido { get; set; }
    }
}
