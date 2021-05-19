using EmployeeManagement.Api.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProfitSharing.Api.Models.RequestJSONs
{
    public class CalculateProfitSharingJSON
    {
        [Range(0, double.MaxValue, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "EXC001")]
        [JsonPropertyName("total_disponibilizado")]
        public decimal AvailablelSum { get; set; }
    }
}
