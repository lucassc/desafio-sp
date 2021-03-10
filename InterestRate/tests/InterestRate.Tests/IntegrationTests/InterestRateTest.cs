using FluentAssertions;
using InterestRate.Api;
using InterestRate.Api.Constants;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace InterestRate.Tests.IntegrationTests
{
    public class InterestRateTest
    {
        private readonly HttpClient _webApi;

        public InterestRateTest()
        {
            var webApiFactory = new WebApplicationFactory<Startup>();
            _webApi = webApiFactory.CreateDefaultClient();
        }

        [Fact(DisplayName = "GetInterestRoute should execute correctly")]
        public async Task GetInterestRoute_ShouldExecuteCorrectly()
        {
            var expectedResult = new RateResultDummy { Rate = InterestRates.MainInterestRate };

            var response = await _webApi.GetAsync(ControllerRoutes.InterestRateRoute);
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RateResultDummy>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expectedResult);
        }

        private class RateResultDummy
        {
            public decimal Rate { get; set; }
        }
    }
}