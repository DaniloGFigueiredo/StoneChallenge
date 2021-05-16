using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.ResquestJSONs
{
    public class EmployeeJSON
    {
        [JsonPropertyName("matricula")]
        [Required(ErrorMessage = "ERRO")] 
        public long RegistrationNumber { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("cargo")]
        public string Role { get; set; }

        [JsonPropertyName("salario_bruto")]
        public decimal GrossSalary { get; set; }

        [JsonPropertyName("data_de_admissao")]
        public decimal AdmissionDate { get; set; }
    }
}
