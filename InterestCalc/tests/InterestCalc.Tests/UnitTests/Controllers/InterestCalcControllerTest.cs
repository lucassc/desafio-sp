using AutoFixture;
using FluentAssertions;
using InterestCalc.Api.Controllers;
using InterestCalc.Api.InterestCalc;
using InterestCalc.Api.InterestCalc.Interfaces;
using InterestCalc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace InterestCalc.Tests.UnitTests.Controllers
{
    public class InterestCalcControllerTest
    {
        private readonly Mock<IInterestCalculationService> _interestCalculationService;
        private readonly Mock<ILogger<InterestCalcController>> _logger;
        private readonly Fixture _fixture;
        private readonly InterestCalcController _controller;
        private int _months;
        private readonly double _initialValue;

        public InterestCalcControllerTest()
        {
            _fixture = new Fixture();
            _months = _fixture.Create<int>();
            _initialValue = _fixture.Create<double>();
            _interestCalculationService = new Mock<IInterestCalculationService>(MockBehavior.Strict);
            _logger = new Mock<ILogger<InterestCalcController>>(MockBehavior.Strict);

            _controller = new InterestCalcController(_interestCalculationService.Object, _logger.Object);
        }

        [Fact(DisplayName = "GetInterestCalcResult should return interest calc result")]
        public async Task GetInterestCalcResult_ShouldReturnInterestCalcResult()
        {
            var expectedResult = _fixture.Create<InterestCalcResponse>();
            _interestCalculationService
                .Setup(s => s.Calc(It.Is<InterestCalcParameters>(p => p.Months == _months && p.InitialValue == _initialValue)))
                .ReturnsAsync(expectedResult.CalcResult);

            var result = (OkObjectResult)await _controller.GetInterestCalcResult(_months, _initialValue);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var resultValue = result.Value.As<InterestCalcResponse>();
            resultValue.Should().NotBeNull();
            resultValue.Should().BeEquivalentTo(expectedResult);
            _interestCalculationService.VerifyAll();
        }

        [Fact(DisplayName = "GetInterestCalcResult when an error occurred should log")]
        public void GetInterestCalcResult_WhenAnErrorOccurred_ShouldLog()
        {
            var exception = new Exception("_teste_");
            _interestCalculationService
                .Setup(s => s.Calc(It.IsAny<InterestCalcParameters>()))
                .Throws(exception);
            _logger
                .Setup(x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.Is<Exception>(ex => ex == exception),
                    It.Is<Func<It.IsAnyType, Exception, string>>((_, __) => true)));

            Func<Task<IActionResult>> func = async () =>
                await _controller.GetInterestCalcResult(_months, _initialValue);

            func.Should().ThrowExactly<Exception>().WithMessage(exception.Message);
            Mock.VerifyAll(_interestCalculationService, _logger);
        }
    }
}