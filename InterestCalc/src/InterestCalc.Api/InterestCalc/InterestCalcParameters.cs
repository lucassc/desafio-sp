using InterestCalc.Api.InterestCalc.Exceptions;

namespace InterestCalc.Api.InterestCalc
{
    public class InterestCalcParameters
    {
        public InterestCalcParameters(int months, double initialValue)
        {
            if (months <= 0)
            {
                throw new InvalidInterestCalcParametersException(details: $"Invalid {nameof(months)} parameter value: {months}");
            }

            if (initialValue <= 0)
            {
                throw new InvalidInterestCalcParametersException(details: $"Invalid {nameof(initialValue)} parameter value: {months}");
            }

            Months = months;
            InitialValue = initialValue;
        }

        public int Months { get; }
        public double InitialValue { get; }
    }
}