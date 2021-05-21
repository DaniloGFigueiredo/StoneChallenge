using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProfitSharing.Domain.DTOs
{
    public class ProfitSharingResultDTO
    {
        public ProfitSharingResultDTO()
        {
            ProfitSharingParticipantList = new List<ProfitSharingParticipant>();
        }
        [JsonPropertyName("participacoes")]
        public List<ProfitSharingParticipant> ProfitSharingParticipantList { get; set; }

        [JsonPropertyName("total_de_funcionarios")]
        public int TotalParticipants { get; set; }

        [JsonPropertyName("total_distribuido")]
        public string SharedSum { get; set; }

        [JsonPropertyName("total_disponibilizado")]
        public string TotalAvailableSum { get; set; }

        [JsonPropertyName("saldo_total_disponibilizado")]
        public string BalanceSum { get; set; }

    }
}
