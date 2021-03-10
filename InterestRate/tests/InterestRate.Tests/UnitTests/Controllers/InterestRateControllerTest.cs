using FluentAssertions;
using InterestRate.Api.Constants;
using InterestRate.Api.Controllers;
using InterestRate.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace InterestRate.Tests.UnitTests.Controllers
{
    public class InterestRateControllerTest
    {
        private readonly InterestRateController _controller;

        public InterestRateControllerTest() => _controller = new InterestRateController();

        [Fact(DisplayName = "GetInterestRate should return correct rate")]
        public void GetInterestRate_ShouldReturnCorrectRate()
        {
            var result = (OkObjectResult)_controller.GetInterestRate();

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var resultValue = result.Value.As<InterestRateResponse>();
            resultValue.Should().NotBeNull();
            resultValue.Rate.Should().Be(InterestRates.MainInterestRate);
        }
    }
}