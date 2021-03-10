using InterestCalc.Api;
using InterestCalc.Api.InterestCalc.Interfaces;
using InterestCalc.Tests.IntegrationsTests.InterestCalc.Fakes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InterestCalc.Tests.IntegrationsTests
{
    public class WebAppFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var descriptor =
                    new ServiceDescriptor(
                        typeof(IInterestRateService),
                        typeof(InterestRateServiceMock),
                        ServiceLifetime.Transient);
                services.Replace(descriptor);
            });
        }
    }
}