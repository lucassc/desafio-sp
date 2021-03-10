using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace InterestCalc.Api.InterestCalc.Exceptions
{
    [Serializable]
    public class InvalidInterestCalcParametersException : Exception
    {
        public InvalidInterestCalcParametersException(string details)
            : base("Invalid interest calculation parameters")
            => Details = details;

        [ExcludeFromCodeCoverage]
        protected InvalidInterestCalcParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Details { get; }
    }
}