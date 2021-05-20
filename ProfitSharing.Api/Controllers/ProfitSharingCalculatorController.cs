using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfitSharing.Api.Models.RequestJSONs;
using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitSharing.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("[controller]")]
    [ApiController]
    public class ProfitSharingCalculatorController : ControllerBase
    {
        private readonly IProfitSharingService _profitSharingService;
        public ProfitSharingCalculatorController(IProfitSharingService profitSharingService)
        {
            _profitSharingService = profitSharingService;
        }


        [HttpPost("CalculateProfitSharing")]
        public async Task<IActionResult> Post(CalculateProfitSharingJSON calculateProfitSharingJSON)
        {
            ProfitSharingResultDTO profitSharingResultDTO = await _profitSharingService.CalculateProfitSharing(calculateProfitSharingJSON.AvailablelSum);
            return null;
        }
    }
}
