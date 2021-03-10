using InterestCalc.Api.Configurations;
using InterestCalc.Api.Infra.HttpRequests.InterestRate.Models;
using InterestCalc.Api.Infra.HttpRequests.Interfaces;
using InterestCalc.Api.InterestCalc.Interfaces;
using System.Threading.Tasks;

namespace InterestCalc.Api.Infra.HttpRequests.InterestRate
{
    public class InterestRateService : IInterestRateService
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly UrlsConfig _urlsConfig;

        public InterestRateService(IHttpRequestService httpRequestService,
                                   UrlsConfig urlsConfig)
        {
            _httpRequestService = httpRequestService;
            _urlsConfig = urlsConfig;
        }

        public async Task<decimal> GetInterestRate()
        {
            //add memory cache?
            var response = await _httpRequestService.GetJsonAsync<InterestRateRespose>(_urlsConfig.InterestRateQueryUrl);
            return response.Rate;
        }
    }
}