using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }
    }
}