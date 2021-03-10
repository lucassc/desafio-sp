using InterestCalc.Api.InterestCalc.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace InterestCalc.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidInterestCalcParametersException)
            {
                context.Result = new ObjectResult(new { BadRequest = context.Exception.Message })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else
            {
                context.Result = new ObjectResult(new { context.Exception.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}