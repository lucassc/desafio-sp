using FluentAssertions;
using InterestCalc.Api.InterestCalc;
using InterestCalc.Api.InterestCalc.Exceptions;
using System;
using Xunit;

namespace InterestCalc.Tests.UnitTests.InterestCalc
{
    public class InterestCalcParametersTest
    {
        [Theory(DisplayName = "When valid values should create a parameter instance")]
        [InlineData(1, 1)]
        [InlineData(1, 100)]
        [InlineData(1, 100.01)]
        public void WhenValidValues_ShouldCreateAParameterInstance(int months, double initialValue)
        {
            var parameters = new InterestCalcParameters(months, initialValue);

            parameters.Months.Should().Be(months);
            parameters.InitialValue.Should().Be(initialValue);
        }

        [Theory(DisplayName = "When invalid values should throw an exception")]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void WhenInvalidValues_ShouldThrowAnException(int months, double initialValue)
        {
            Func<InterestCalcParameters> func = () => new InterestCalcParameters(months, initialValue);

            func.Should().ThrowExactly<InvalidInterestCalcParametersException>();
        }
    }
}