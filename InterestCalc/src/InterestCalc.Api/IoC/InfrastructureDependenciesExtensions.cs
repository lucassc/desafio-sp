using InterestCalc.Api.Configurations;
using InterestCalc.Api.Infra.HttpRequests.InterestRate;
using InterestCalc.Api.Infra.HttpRequests.Interfaces;
using InterestCalc.Api.Infra.HttpRequests.Services;
using InterestCalc.Api.InterestCalc.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterestCalc.Api.IoC
{
    public static class InfrastructureDependenciesExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddConfigurations(configuration)
                .AddHttpServices(configuration);

        private static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton(configuration.GetSection(UrlsConfig.ConfigSectionName).Get<UrlsConfig>());

        private static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddScoped<IHttpRequestService, HttpRequestService>()
                .AddScoped(typeof(IInterestRateService),
                           configuration.GetValue<bool>("CacheInterestRate")
                                ? typeof(InterestRateCachedService)
                                : typeof(InterestRateService));
    }
}