using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitSharing.Domain.DTOs
{
    public class ProfitSharingParticipant
    {
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public decimal ResultingIndividualProfitSharingSum { get; set; }
    }
}
