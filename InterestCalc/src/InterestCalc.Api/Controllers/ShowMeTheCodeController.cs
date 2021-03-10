using InterestCalc.Api.Configurations;
using InterestCalc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InterestCalc.Api.Controllers
{
    [ApiController]
    [Route("v1/show-me-the-code")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly UrlsConfig _urlsConfig;

        public ShowMeTheCodeController(UrlsConfig urlsConfig) => _urlsConfig = urlsConfig;

        [HttpGet]
        [ProducesResponseType(typeof(RepositoryUrlResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetRepositoryUrl()
        {
            var response = new RepositoryUrlResponse(_urlsConfig.GitHubUrl);
            return Ok(response);
        }
    }
}