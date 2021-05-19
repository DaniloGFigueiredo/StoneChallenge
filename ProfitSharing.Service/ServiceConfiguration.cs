using Microsoft.Extensions.DependencyInjection;
using ProfitSharing.Infrastructure.Integrations.Clients;
using Microsoft.Extensions.Configuration;
using ProfitSharing.Domain.Interfaces;

namespace ProfitSharing.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmployeeManagementClientSettings>(
            configuration.GetSection(nameof(EmployeeManagementClientSettings)));
            services.AddScoped<IEmployeeManagementClient, EmployeeManagementClient>();
            return services;         
        }
    }
}
