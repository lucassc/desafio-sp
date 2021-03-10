using InterestCalc.Api.InterestCalc.Interfaces;
using InterestCalc.Api.InterestCalc.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InterestCalc.Api.IoC
{
    public static class DomainDependenciesExtensions
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services) =>
            services
                .AddScoped<IInterestCalculationService, InterestCalculationService>();
    }
}