using GYG.RestAbstract.Models.Responses;

namespace GYG.RestAbstract.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            while (context.Exception?.InnerException != null)
            {
                context.Exception = context.Exception.InnerException;
            }

            _logger.LogError(context.Exception, "There was a problem while processing your request.");

            ErrorResponse errorResponse = new ErrorResponse
            {
                AdditionalInfo = context.Exception?.Message,
                ErrorCode = "InternalServerError"
            };
            errorResponse.AddErrorMessage("There was a problem while processing your request.");

            var objectResult = new ObjectResult(errorResponse) { StatusCode = 500 };

            context.Result = objectResult;
        }
    }
}
