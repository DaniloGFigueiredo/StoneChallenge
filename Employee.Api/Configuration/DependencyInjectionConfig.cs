using EmployeeManagement.Api.ModelMappers;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EmployeeManagement.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services, IConfiguration configuration)
        {          
            services.AddScoped <IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeManagerMapper, EmployeeManagerMapper>();
            services.ConfigureRepositoryServices(configuration);
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfig>();
            return services;
        }
    }
}
