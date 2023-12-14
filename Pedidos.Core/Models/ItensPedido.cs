namespace Pedidos.Core.Models
{
    public class ItensPedido : BaseModel
    {
        public ItensPedido()
        {

        }
        public ItensPedido(Guid IdPedido, Guid IdProduto, int Quantidade, string NomeProduto, decimal ValorUnitario)
        {
            this.IdPedido = IdPedido;
            this.IdProduto = IdProduto;
            this.Quantidade = Quantidade;
            this.NomeProduto = NomeProduto;
            this.ValorUnitario = ValorUnitario;
        }
        public Guid IdPedido { get; private set; }
        public Guid IdProduto { get; private set; }
        public int Quantidade { get; private set; }
        public string? NomeProduto { get; private set; }
        public decimal? ValorUnitario { get; private set; }
        public Pedido Pedido { get; private set; }
        public Produto? Produto { get; private set; }

        public void LimparProdutos()
        {
            Produto = null;
        }
    }
}
