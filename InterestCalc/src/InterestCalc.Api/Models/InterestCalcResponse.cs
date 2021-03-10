using System;

namespace InterestCalc.Api.Models
{
    public class InterestCalcResponse
    {
        public InterestCalcResponse(double calcResult) =>
            CalcResult = Truncate(calcResult);

        public double CalcResult { get; }

        private double Truncate(double num)
        {
            double y = Math.Pow(10, 2);
            return Math.Truncate(num * y) / y;
        }
    }
}