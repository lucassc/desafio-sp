using InterestCalc.Api.InterestCalc.Interfaces;
using System;
using System.Threading.Tasks;

namespace InterestCalc.Api.InterestCalc.Services
{
    public class InterestCalculationService : IInterestCalculationService
    {
        private const double _hundredPercent = 1;
        private readonly IInterestRateService _interestRateService;

        public InterestCalculationService(IInterestRateService interestRateService) =>
            _interestRateService = interestRateService;

        public async Task<double> Calc(InterestCalcParameters parameters)
        {
            var rate = await _interestRateService.GetInterestRate();
            var rateToCalc = (double)rate + _hundredPercent;

            return parameters.InitialValue * Math.Pow(rateToCalc, parameters.Months);
        }
    }
}