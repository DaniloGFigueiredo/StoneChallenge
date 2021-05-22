using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProfitSharing.Api.Models.RequestJSONs
{
    public class CalculateProfitSharingJSON
    {
        [Range(0, double.MaxValue, ErrorMessage = "Não é possível mandar valores negativos")]//todo: mudar para resource
        [JsonPropertyName("total_disponibilizado")]
        public decimal AvailableSum { get; set; }
    }
}
