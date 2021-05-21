using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}
