using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProfitSharing.Domain.Interfaces;
using ProfitSharing.Service;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProfitSharing.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProfitSharingService, ProfitSharingService>();
            services.ConfigureServices(configuration);
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfig>();

            return services;
        }
    }
}
