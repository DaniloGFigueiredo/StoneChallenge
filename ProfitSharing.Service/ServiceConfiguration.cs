using Microsoft.Extensions.DependencyInjection;
using ProfitSharing.Infrastructure.Integrations.Clients;
using Microsoft.Extensions.Configuration;
using ProfitSharing.Domain.Interfaces;
using Polly;
using System;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace ProfitSharing.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureClientServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.Configure<EmployeeManagementClientSettings>(
            configuration.GetSection(nameof(EmployeeManagementClientSettings)));
            services.AddSingleton<IEmployeeManagementClientSettings>(sp => sp.GetRequiredService<IOptions<EmployeeManagementClientSettings>>().Value);

            var timeOutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(16);
            services.AddHttpClient<IEmployeeManagementClient, EmployeeManagementClient>().AddTransientHttpErrorPolicy(
            p => p.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(15)
            })).AddPolicyHandler(timeOutPolicy); ;

            return services;         
        }
    }
}
