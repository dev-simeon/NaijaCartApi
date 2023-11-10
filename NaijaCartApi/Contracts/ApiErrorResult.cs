using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NaijaCartApi.Contracts
{
    internal class ApiErrorResult : ObjectResult
    {
        public ApiErrorResult(int code, string? message) : base(null)
        {
            StatusCode = code;
            Value = new
            {
                Code = StatusCode,
                Message = message,
            };
        }

        public ApiErrorResult(Exception? ex) : base(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
            Value = new
            {
                Code = StatusCode,
                Message = ex?.Message ?? "Unknown exception",
            };
        }

        public ApiErrorResult(ModelStateDictionary modelState) : base(null)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            Value = new
            {
                Code = StatusCode,
                Message = "Validation Failed",
                Errors = modelState.Keys
                        .SelectMany(key => modelState[key]!.Errors
                        .Select(x => new { Field = key, Message = x.ErrorMessage }))
                        .ToList(),
            };
        }
    }
}
