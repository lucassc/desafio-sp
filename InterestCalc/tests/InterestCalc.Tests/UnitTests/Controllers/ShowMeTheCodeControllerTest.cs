using AutoFixture;
using FluentAssertions;
using InterestCalc.Api.Configurations;
using InterestCalc.Api.Controllers;
using InterestCalc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace InterestCalc.Tests.UnitTests.Controllers
{
    public class ShowMeTheCodeControllerTest
    {
        private readonly UrlsConfig _urlsConfig;
        private readonly ShowMeTheCodeController _controller;

        public ShowMeTheCodeControllerTest()
        {
            var fixture = new Fixture();
            _urlsConfig = fixture.Create<UrlsConfig>();

            _controller = new ShowMeTheCodeController(_urlsConfig);
        }

        [Fact(DisplayName = "GetRepositoryUrl should return url where this code is commited")]
        public void GetRepositoryUrl_ShouldReturnUrlWhereThisCodeIsCommited()
        {
            var expectedResult = new RepositoryUrlResponse(_urlsConfig.GitHubUrl);

            var result = (OkObjectResult)_controller.GetRepositoryUrl();

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var resultValue = result.Value.As<RepositoryUrlResponse>();
            resultValue.Should().NotBeNull();
            resultValue.Should().BeEquivalentTo(expectedResult);
        }
    }
}