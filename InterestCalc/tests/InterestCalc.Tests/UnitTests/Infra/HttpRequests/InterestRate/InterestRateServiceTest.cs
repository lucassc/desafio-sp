using AutoFixture;
using FluentAssertions;
using InterestCalc.Api.Configurations;
using InterestCalc.Api.Infra.HttpRequests.InterestRate;
using InterestCalc.Api.Infra.HttpRequests.InterestRate.Models;
using InterestCalc.Api.Infra.HttpRequests.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace InterestCalc.Tests.UnitTests.Infra.HttpRequests.InterestRate
{
    public class InterestRateServiceTest
    {
        private readonly UrlsConfig _urlsConfig;
        private readonly Mock<IHttpRequestService> _httpRequestService;
        private readonly InterestRateService _service;
        private readonly Fixture _fixture;

        public InterestRateServiceTest()
        {
            _fixture = new Fixture();
            _urlsConfig = _fixture.Create<UrlsConfig>();
            _httpRequestService = new Mock<IHttpRequestService>();

            _service = new InterestRateService(
                _httpRequestService.Object,
                _urlsConfig);
        }

        [Fact(DisplayName = "GetInterestRate should use the correct url and return value correctly")]
        public async Task GetInterestRate_ShouldUseTheCorrectUrlAndReturnValueCorrectly()
        {
            var response = _fixture.Create<InterestRateRespose>();
            _httpRequestService
                .Setup(s => s.GetJsonAsync<InterestRateRespose>(_urlsConfig.InterestRateQueryUrl))
                .ReturnsAsync(response);

            var result = await _service.GetInterestRate();

            result.Should().Be(response.Rate);
            _httpRequestService.VerifyAll();
        }
    }
}