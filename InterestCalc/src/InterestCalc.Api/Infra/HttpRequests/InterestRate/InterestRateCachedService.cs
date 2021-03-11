using InterestCalc.Api.Configurations;
using InterestCalc.Api.Infra.HttpRequests.Interfaces;
using InterestCalc.Api.InterestCalc.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace InterestCalc.Api.Infra.HttpRequests.InterestRate
{
    public class InterestRateCachedService : InterestRateService, IInterestRateService
    {
        private const int CacheTimeToExpireInMinutos = 10;
        private readonly IMemoryCache _memoryCache;

        public InterestRateCachedService(IHttpRequestService httpRequestService,
                                         IMemoryCache memoryCache,
                                         UrlsConfig urlsConfig) : base(httpRequestService, urlsConfig)
            => _memoryCache = memoryCache;

        public override async Task<decimal> GetInterestRate()
        {
            var key = nameof(InterestRateCachedService);
            return await _memoryCache.GetOrCreateAsync(key, cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheTimeToExpireInMinutos);
                return base.GetInterestRate();
            });
        }
    }
}