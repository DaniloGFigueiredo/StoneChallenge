using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfitSharing.Domain.Interfaces;
using ProfitSharing.Service;

namespace ProfitSharing.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProfitSharingService, ProfitSharingService>();
            services.ConfigureServices(configuration);
            
            return services;
        }
    }
}
