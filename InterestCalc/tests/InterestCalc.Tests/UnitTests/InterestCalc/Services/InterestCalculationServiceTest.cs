using FluentAssertions;
using InterestCalc.Api.InterestCalc;
using InterestCalc.Api.InterestCalc.Interfaces;
using InterestCalc.Api.InterestCalc.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace InterestCalc.Tests.UnitTests.InterestCalc.Services
{
    public class InterestCalculationServiceTest
    {
        private readonly Mock<IInterestRateService> _interestRateService;
        private readonly InterestCalculationService _service;

        public InterestCalculationServiceTest()
        {
            _interestRateService = new Mock<IInterestRateService>(MockBehavior.Strict);

            _service = new InterestCalculationService(_interestRateService.Object);
        }

        [Theory(DisplayName = "Calc should execute the correct calc")]
        [InlineData(1, 100, 0.01, 101)]
        [InlineData(1, 100, 0.02, 102)]
        [InlineData(10, 200, 0.02, 243.79888399895145)]
        [InlineData(12, 100, 0.02, 126.82417945625456)]
        public async Task CalcShouldExecuteTheCorrectCalc(int months, double initialValue, decimal interestRate, double expectedResult)
        {
            var parameters = new InterestCalcParameters(months, initialValue);
            _interestRateService
                .Setup(s => s.GetInterestRate())
                .ReturnsAsync(interestRate);

            var result = await _service.Calc(parameters);

            result.Should().Be(expectedResult);
            _interestRateService.VerifyAll();
        }
    }
}