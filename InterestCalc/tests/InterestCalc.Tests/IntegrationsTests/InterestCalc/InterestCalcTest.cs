using FluentAssertions;
using InterestCalc.Api.Configurations.Constants;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace InterestCalc.Tests.IntegrationsTests.InterestCalc
{
    public class InterestCalcTest
    {
        private readonly HttpClient _webApi;

        public InterestCalcTest()
        {
            var webApiFactory = new WebAppFactory();
            _webApi = webApiFactory.CreateDefaultClient();
        }

        [Theory(DisplayName = "InterestCalc should return the correct result")]
        [InlineData(1, 100, 101)]
        [InlineData(2, 200, 204.02)]
        [InlineData(10, 200.09, 221.02)]
        public async Task InterestCalc_ShouldReturnTheCorrectResult(int months, decimal initialValue, decimal expectedValue)
        {
            var expectedResult = new InterestCalcResponseDummy { CalcResult = expectedValue };
            var url = $"{ControllerRoutes.InterestCalcRoute }?months={months}&initialValue={initialValue:f}";

            var response = await _webApi.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<InterestCalcResponseDummy>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact(DisplayName = "InterestCalc when paramerts invalid should return BadRequest")]
        public async Task InterestCalc_WhenParamertsInvalid_ShouldReturnBadRequest()
        {
            var months = -1;
            var initialValue = -10;
            var url = $"{ControllerRoutes.InterestCalcRoute }?months={months}&initialValue={initialValue:f}";

            var response = await _webApi.GetAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private class InterestCalcResponseDummy
        {
            public decimal CalcResult { get; set; }
        }
    }
}