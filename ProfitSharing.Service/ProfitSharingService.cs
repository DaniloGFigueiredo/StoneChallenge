using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitSharing.Service
{
    public class ProfitSharingService : IProfitSharingService
    {
        private readonly IEmployeeManagementClient _employeeManagementClient;

        public ProfitSharingService(IEmployeeManagementClient employeeManagementClient)
        {
            _employeeManagementClient = employeeManagementClient;
        }
        public async Task CalculateProfiSharing()
        {
            List<EmployeeDTO> employees = await _employeeManagementClient.GetAllEmployees();
        }
    }
}
