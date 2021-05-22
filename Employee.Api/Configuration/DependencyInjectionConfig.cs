using EmployeeManagement.Api.ModelMappers;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services, IConfiguration configuration)
        {          
            services.AddScoped <IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeManagerMapper, EmployeeManagerMapper>();
            services.ConfigureRepositoryServices(configuration);
            return services;
        }
    }
}
