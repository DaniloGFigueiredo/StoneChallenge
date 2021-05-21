using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfitSharing.Domain.DTOs
{
    public class ProfitSharingParticipant
    {
        [JsonPropertyName("matricula")]
        public string RegistrationNumber { get; set; }
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("valor_da_participacão")]
        public string ResultingIndividualProfitSharingSum { get; set; }
    }
}
