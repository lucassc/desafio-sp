using System.Threading.Tasks;

namespace InterestCalc.Api.InterestCalc.Interfaces
{
    public interface IInterestCalculationService
    {
        Task<double> Calc(InterestCalcParameters parameters);
    }
}