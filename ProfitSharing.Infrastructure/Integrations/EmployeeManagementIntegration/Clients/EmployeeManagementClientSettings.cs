using ProfitSharing.Domain.Interfaces;

namespace ProfitSharing.Infrastructure.Integrations.Clients
{
    public class EmployeeManagementClientSettings : IEmployeeManagementClientSettings
    {
        public string AccessKey { get; set; }
        public string URI { get; set; }
    }
}
