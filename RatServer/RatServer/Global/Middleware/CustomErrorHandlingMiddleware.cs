using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RatServer.Global.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RatServer.Global.Middleware
{
    public static class RequestErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder CustomErrorHandling(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorHandlingMiddleware>();
        }
    }
    public class CustomErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;
        public CustomErrorHandlingMiddleware(RequestDelegate next, ILogger<CustomErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is NotImplementedException)
            {
                code = HttpStatusCode.NotImplemented;
            }
            else if (exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (exception is ArgumentNullException)
            {
                code = HttpStatusCode.BadRequest;
            }

            if (exception is RewardSystemException httpStatusCodeEx)
            {
                if (httpStatusCodeEx.StatusCode == 400)
                {
                    code = HttpStatusCode.BadRequest;
                }
                if (httpStatusCodeEx.StatusCode == 401)
                {
                    code = HttpStatusCode.Unauthorized;
                }
                if (httpStatusCodeEx.StatusCode == 404)
                {
                    code = HttpStatusCode.NotFound;
                }
            }

            logger.LogError($"Application: {exception.Message}", exception.StackTrace);
            RewardSystemException error = new((int)code, exception.Message);
            string result = JsonConvert.SerializeObject(new { error });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}