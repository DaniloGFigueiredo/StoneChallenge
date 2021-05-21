using Microsoft.Extensions.Logging;
using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ProfitSharing.Infrastructure.Integrations.Clients
{
    public class EmployeeManagementClient : IEmployeeManagementClient
    {
        private HttpClient _client;
        private readonly ILogger<EmployeeManagementClient> _logger;
        private string URI;
        private string AccessKey;
        public EmployeeManagementClient(IEmployeeManagementClientSettings settings, HttpClient client, ILogger<EmployeeManagementClient>logger)
        {
            URI = settings.URI;
            AccessKey = settings.AccessKey;
            _client = client;
            _logger = logger;
        }
        public async Task <List<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(25));
                using var responseStream = await _client.GetStreamAsync(URI, cancellationTokenSource.Token);
                List<EmployeeDTO> GetAllEmployees = await JsonSerializer.DeserializeAsync<List<EmployeeDTO>>(responseStream);
                
                return  GetAllEmployees;
            }
            catch (TaskCanceledException ce)
            {
                _logger.LogError(ce, $"O tempo de espera não pode ser maior que 25 segundos e portanto a requisição foi finalizada");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Não foi possivel conectar com a EmployeeManagementAPI");
                return null;
            }
        }
             
    }
}
