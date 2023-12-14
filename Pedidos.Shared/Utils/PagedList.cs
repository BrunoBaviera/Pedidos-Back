namespace Pedidos.Shared.Utils
{
    public class PagedList<T>
    {
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public List<T> Itens { get; set; }
        public PagedList()
        {
            Itens = new List<T>();
        }
    }
}
