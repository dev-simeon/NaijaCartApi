using NaijaCartApi.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NaijaCartApi.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            // ex.ToExceptionless().Submit();

            if (ex is ArgumentException argEx)
            {
                // validation issues
                // Argument[Null|OutOfRange]Exception
                context.ModelState.AddModelError(argEx.ParamName ?? "unknown", argEx.Message);
                context.Result = new ApiErrorResult(context.ModelState);
                return;
            }

            if (ex is InvalidOperationException opEx)
            {
                context.Result = new ApiErrorResult(StatusCodes.Status400BadRequest, opEx.Message);
                return;
            }

            if (ex is NotFoundException keyEx)
            {
                // Not Found Exception
                context.Result = new ApiErrorResult(StatusCodes.Status404NotFound, keyEx.Message);
                return;
            }

            context.Result = new ApiErrorResult(ex);
            return;
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string? message = null) : base(message) { }
    }
}
