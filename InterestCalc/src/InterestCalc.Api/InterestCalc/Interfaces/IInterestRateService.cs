using System.Threading.Tasks;

namespace InterestCalc.Api.InterestCalc.Interfaces
{
    public interface IInterestRateService
    {
        Task<decimal> GetInterestRate();
    }
}