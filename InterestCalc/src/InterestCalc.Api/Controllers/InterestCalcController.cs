using InterestCalc.Api.Configurations.Constants;
using InterestCalc.Api.InterestCalc;
using InterestCalc.Api.InterestCalc.Interfaces;
using InterestCalc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace InterestCalc.Api.Controllers
{
    [ApiController]
    [Route(ControllerRoutes.InterestCalcRoute)]
    public class InterestCalcController : ControllerBase
    {
        private readonly IInterestCalculationService _interestCalculationService;
        private readonly ILogger<InterestCalcController> _logger;

        public InterestCalcController(IInterestCalculationService interestCalculationService,
                                      ILogger<InterestCalcController> logger)
        {
            _interestCalculationService = interestCalculationService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(InterestCalcResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInterestCalcResult([FromQuery] int months, [FromQuery] double initialValue)
        {
            try
            {
                var result = await DoGetInterestRate(months, initialValue);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Occurred an error at interest calc. Message: {ex.Message}");
                throw;
            }
        }

        private async Task<InterestCalcResponse> DoGetInterestRate(int months, double initialValue)
        {
            var parameters = new InterestCalcParameters(months, initialValue);
            var result = await _interestCalculationService.Calc(parameters);
            return new InterestCalcResponse(result);
        }
    }
}