using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Api.Resources;

namespace EmployeeManagement.Api.ResquestJSONs
{
    public class AddEmployeesJSON
    {
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "EXC001")]
        [JsonPropertyName("matricula")]
        public long RegistrationNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC002")]
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC003")]
        [JsonPropertyName("area")]
        public string Area { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC004")]
        [JsonPropertyName("cargo")]
        public string Role { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC005")]
        [JsonPropertyName("salario_bruto")]
        public string GrossSalary { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC006")]
        [JsonPropertyName("data_de_admissao")]
        public DateTime AdmissionDate { get; set; }
    }
}
