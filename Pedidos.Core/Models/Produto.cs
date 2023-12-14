namespace Pedidos.Core.Models
{
    public class Produto : BaseModel
    {
        public string NomeProduto { get; private set; }
        public decimal Valor { get; private set; }
        public  List<ItensPedido>? ItensPedido { get; private set; }
    }
}
