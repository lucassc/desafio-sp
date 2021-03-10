using System.Threading.Tasks;

namespace InterestCalc.Api.Infra.HttpRequests.Interfaces
{
    public interface IHttpRequestService
    {
        Task<T> GetJsonAsync<T>(string url);
    }
}