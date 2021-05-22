using Microsoft.Extensions.DependencyInjection;
using ProfitSharing.Infrastructure.Integrations.Clients;
using Microsoft.Extensions.Configuration;
using ProfitSharing.Domain.Interfaces;
using Polly;
using System;
using Microsoft.Extensions.Options;

namespace ProfitSharing.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)//todo: mudar nome
        {
            services.Configure<EmployeeManagementClientSettings>(
            configuration.GetSection(nameof(EmployeeManagementClientSettings)));
            services.AddSingleton<IEmployeeManagementClientSettings>(sp => sp.GetRequiredService<IOptions<EmployeeManagementClientSettings>>().Value);
            services.AddHttpClient<IEmployeeManagementClient, EmployeeManagementClient>(cfg => { cfg.Timeout = new TimeSpan(0, 0, 5);}).AddTransientHttpErrorPolicy(
            p => p.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(15)
            })); ;
          
            return services;         
        }
    }
}
