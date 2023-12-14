using Pedidos.GlobalApplication.AutoMapper;

namespace Pedidos.Global.Api.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(
                typeof(MappingProfile));
        }
    }
}
