using InterestRate.Api.Constants;
using InterestRate.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterestRate.Api.Controllers
{
    [ApiController]
    [Route("v1/interest-rate")]
    public class InterestRateController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetInterestRate()
        {
            var response = (InterestRateResponse)InterestRates.MainInterestRate;
            return Ok(response);
        }
    }
}