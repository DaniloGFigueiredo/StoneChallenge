using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitSharing.Domain.DTOs
{
    public class ProfitSharingResultDTO
    {
        public ProfitSharingResultDTO()
        {
            ProfitSharingParticipantList = new List<ProfitSharingParticipant>();
        }
        public List<ProfitSharingParticipant> ProfitSharingParticipantList { get; set; }
        public decimal ResultingProfitSharingSum { get; set; }
    }
}
