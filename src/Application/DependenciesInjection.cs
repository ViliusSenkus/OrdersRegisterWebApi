using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependenciesInjection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<OrdersRegisterService>();
        }
    }
}
