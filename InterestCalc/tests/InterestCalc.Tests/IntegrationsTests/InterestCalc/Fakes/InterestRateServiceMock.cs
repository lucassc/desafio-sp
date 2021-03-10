using InterestCalc.Api.InterestCalc.Interfaces;
using System.Threading.Tasks;

namespace InterestCalc.Tests.IntegrationsTests.InterestCalc.Fakes
{
    public class InterestRateServiceMock : IInterestRateService
    {
        public Task<decimal> GetInterestRate()
        {
            return Task.FromResult(0.01m);
        }
    }
}