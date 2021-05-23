using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitSharing.Api.Models.RequestJSONs;
using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using ProfitSharing.Domain.Resources;
using System;
using System.Threading.Tasks;

namespace ProfitSharing.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProfitSharingCalculatorController : ControllerBase
    {
        private readonly IProfitSharingService _profitSharingService;
        private readonly ILogger _logger;
        public ProfitSharingCalculatorController(IProfitSharingService profitSharingService, ILogger<ProfitSharingCalculatorController> logger)
        {
            _profitSharingService = profitSharingService;
            _logger = logger;
        }

        [HttpPost("CalculateProfitSharing")]
        public async Task<IActionResult> Post(CalculateProfitSharingJSON calculateProfitSharingJSON)
        {
            try
            {
                ProfitSharingResultDTO profitSharingResultDTO = await _profitSharingService.CalculateProfitSharing(calculateProfitSharingJSON.AvailableSum);
                return Ok(profitSharingResultDTO);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Messages.EXC000);
            }
        }
    }
}
