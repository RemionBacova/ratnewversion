using Microsoft.AspNetCore.Builder;
using RatServer.Core.Models;

namespace RatServer.Core.Middleware
{
    public static class ApiResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiResponseExtension(this IApplicationBuilder builder, ApiResponseOptions options = default)
        {
            options ??= new ApiResponseOptions();
            return builder.UseMiddleware<ApiResponseMiddleware>(options);
        }
    }
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionExtension(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
