using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static ProfitSharing.Domain.Enums.Enum;

namespace ProfitSharing.Domain.DTOs
{
    public class EmployeeDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("registrationNumber")]
        public long RegistrationNumber { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("area")]
        public EmployeeArea Area { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("grossSalary")]
        public decimal GrossSalary { get; set; }
        [JsonPropertyName("admissionDate")]
        public DateTime AdmissionDate { get; set; }
    }
}
