using EmployeeManagement.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Api.Models.RequestJSONs
{
    public class RemoveEmployeesJSON
    {
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "EXC001")]
        [JsonPropertyName("matricula")]
        public long RegistrationNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages),
        ErrorMessageResourceName = "EXC002")]
        [JsonPropertyName("nome")]
        public string Name { get; set; }
    }
}
