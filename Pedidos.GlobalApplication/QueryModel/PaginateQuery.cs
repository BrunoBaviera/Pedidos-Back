namespace Pedidos.GlobalApplication.QueryModel
{
    public class PaginateQuery
    {
        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }

        public PaginateQuery()
        {
        }

        public PaginateQuery(int numeroPagina, int tamanhoPagina)
        {
            NumeroPagina = numeroPagina;
            TamanhoPagina = tamanhoPagina;
        }

    }
}
