using Microsoft.Extensions.Options;
using Pedidos.Core.Interfaces;
using Pedidos.Core.Interfaces.Repositories;
using Pedidos.Core.Interfaces.Services;
using Pedidos.Core.Notifications;
using Pedidos.Core.Services;
using Pedidos.Global.Api.SwaggerConfig;
using Pedidos.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pedidos.Global.Api.DependencyInjection
{
    public static class DependencyInjectionRegister
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<INotifier, Notifier>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
