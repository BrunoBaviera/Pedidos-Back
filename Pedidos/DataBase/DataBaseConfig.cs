using Microsoft.EntityFrameworkCore;
using Pedidos.Infra.Data.Context;

namespace Pedidos.Global.Api.DataBase
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PedidosContext>((provider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                //options.UseInMemoryDatabase("Pedidos");
            });

        }
    }
}
