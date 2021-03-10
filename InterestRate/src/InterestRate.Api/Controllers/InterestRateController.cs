using InterestRate.Api.Constants;
using InterestRate.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InterestRate.Api.Controllers
{
    [ApiController]
    [Route(ControllerRoutes.InterestRateRoute)]
    public class InterestRateController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(InterestRateResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetInterestRate()
        {
            var response = (InterestRateResponse)InterestRates.MainInterestRate;
            return Ok(response);
        }
    }
}