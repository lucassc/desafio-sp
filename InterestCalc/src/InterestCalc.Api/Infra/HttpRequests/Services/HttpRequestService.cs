using Flurl.Http;
using InterestCalc.Api.Infra.HttpRequests.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterestCalc.Api.Infra.HttpRequests.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly ILogger<HttpRequestService> _logger;

        public HttpRequestService(ILogger<HttpRequestService> logger) => _logger = logger;

        public async Task<T> GetJsonAsync<T>(string url)
        {
            try
            {
                return await DoGetJsonAsync<T>(url);
            }
            catch (FlurlHttpException ex)
            {
                var message = ex.Call.Completed
                    ? await ex.GetResponseStringAsync()
                    : ex.Message;

                throw new HttpRequestException($"Wasn't possible execute request on '{url}'. Message: {message} ");
            }
        }

        public async Task<T> DoGetJsonAsync<T>(string url)
        {
            var retryPolicy = Policy.Handle<FlurlHttpException>()
                 .WaitAndRetryAsync(retryCount: 1,
                                    retryAttempt => TimeSpan.FromSeconds(1),
                                    (ex, time) => LogOnRetry(ex, time));

            var respose = await retryPolicy.ExecuteAsync(
                () => url.GetJsonAsync<T>());

            return respose;
        }

        private void LogOnRetry(Exception ex, TimeSpan time) =>
            _logger.LogWarning(ex, $"Could get interest rate after {time.TotalSeconds:n1}s ({ex.Message})");
    }
}