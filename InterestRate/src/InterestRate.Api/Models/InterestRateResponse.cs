namespace InterestRate.Api.Models
{
    public class InterestRateResponse
    {
        public InterestRateResponse(decimal rate) => Rate = rate;

        public decimal Rate { get; }

        public static explicit operator InterestRateResponse(decimal rate) =>
            new(rate);
    }
}