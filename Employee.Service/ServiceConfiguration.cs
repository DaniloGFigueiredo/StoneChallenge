using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices (this IServiceCollection services, IConfiguration configuration)
        {         
            services.Configure<EmployeeRepositorySettings>(
            configuration.GetSection(nameof(EmployeeRepositorySettings)));

            services.AddSingleton<IEmployeeRepositorySettings>(sp => sp.GetRequiredService<IOptions<EmployeeRepositorySettings>>().Value);

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}