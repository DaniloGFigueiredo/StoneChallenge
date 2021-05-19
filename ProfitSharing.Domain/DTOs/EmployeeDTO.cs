using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProfitSharing.Domain.Enums.Enum;

namespace ProfitSharing.Domain.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; private set; }
        public long RegistrationNumber { get; set; }
        public string Name { get; set; }
        public EmployeeArea Area { get; set; }
        public string Role { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
