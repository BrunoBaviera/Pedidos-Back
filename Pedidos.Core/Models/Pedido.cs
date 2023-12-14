namespace Pedidos.Core.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {

        }
        public Pedido(Guid Id, string NomeCliente, string EmailCliente, DateTime DataCriacao, bool Pago, decimal ValorTotal, List<ItensPedido>  ItensPedido)
        {
            this.Id = Id;
            this.NomeCliente = NomeCliente;
            this.EmailCliente = EmailCliente;
            this.DataCriacao = DataCriacao;
            this.Pago = Pago;
            this.ValorTotal = ValorTotal;
            this.ItensPedido = ItensPedido;
        }
        public string NomeCliente { get; private set; }
        public string EmailCliente { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Pago { get; private set; }
        public decimal? ValorTotal { get; set; }
        public List<ItensPedido>? ItensPedido { get; private set; }

        public void SetDataCricao()
        {
            DataCriacao = DateTime.Now;
        }

        public void LimparItensPedidos()
        {
            ItensPedido = null;
        }
    }
}
