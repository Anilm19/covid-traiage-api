using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models.Constants;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;
        public GlobalExceptionHandler(RequestDelegate next, ILoggerFactory logger)
        {
            this.logger = logger.CreateLogger<GlobalExceptionHandler>();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(new ResultResponseViewModel
            {
                Code = exception.HResult,
                Data = null,
                Message = exception.Message
            });
            context.Response.ContentType = "application/json";
            if (exception.HResult == 401)
            {
                logger.LogCritical(Errors.ERROR_CODE_GENERAL_EXCEPTION, exception,
                string.Format(Errors.ERROR_MESSAGE_GENERAL_EXCEPTION, exception.Message));
                context.Response.StatusCode = 401;
            }
            else if (exception.HResult == 404)
                context.Response.StatusCode = 404;
            else if (exception.HResult == 400)
            {
                logger.LogCritical(Errors.ERROR_CODE_GENERAL_EXCEPTION, exception,
                string.Format(Errors.ERROR_MESSAGE_GENERAL_EXCEPTION, exception.Message));
                context.Response.StatusCode = 400;
            }
            else
            {
                logger.LogCritical(Errors.ERROR_CODE_GENERAL_EXCEPTION, exception,
                string.Format(Errors.ERROR_MESSAGE_GENERAL_EXCEPTION, exception.Message));
                result = JsonConvert.SerializeObject(new ResultResponseViewModel
                {
                    Code = exception.HResult,
                    Data = null,
                    Message = exception.Message//"Something went wrong. Please try again later."
                });
                context.Response.StatusCode = 500;
            }
            return context.Response.WriteAsync(result);
        }
    }

}
