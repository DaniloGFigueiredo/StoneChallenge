using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfitSharing.Api.Models.RequestJSONs;
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
        [HttpPost("CalculateProfitSharing")]
        public ActionResult Post(CalculateProfitSharingJSON calculateProfitSharingJSON)
        {

            return Ok();
        }
    }
}
